from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
from flask.ext.bcrypt import Bcrypt
import re
app = Flask(__name__)
app.secret_key = 'key' #change this
bcrypt = Bcrypt(app)

mysql = MySQLConnector(app, 'login_registration')

#regex variables to check new users against
REGEX_NAME = re.compile(r'^([a-zA-Z]){2,55}$')
REGEX_EMAIL = re.compile(r'^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$')
REGEX_PASS = re.compile(r'^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$')


#all routes go here
@app.route('/')
def display_index():
    return render_template('index.html')

@app.route('/register', methods=['post'])
def register_user():
    # data validation
    #var to check if anny errors have been thrown
    validation_error = True

    if not REGEX_NAME.match(request.form['first_name']):
        flash('First name may only contain letters', 'error')
        validation_error = False
    if not REGEX_NAME.match(request.form['last_name']):
        flash('Last name may only contain letters', 'error')
        validation_error = False
    if not REGEX_EMAIL.match(request.form['email']):
        flash('Please enter a valid email address.', 'error')
        validation_error = False
    if not REGEX_PASS.match(request.form['pass1']):
        flash('Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.', 'error')
        validation_error = False
    if not request.form['pass1'] == request.form['pass2']:
        flash('Passwords must match.', 'error')
        validation_error = False

    if validation_error == False:
        return redirect('/')

    query = "SELECT id FROM users WHERE email = '{}'".format(request.form['email'])
    userid = mysql.query_db(query)

    if len(userid)>0:
        flash('That email is already in use. Please use the login form.', 'error')
        return redirect('/')

    query = 'INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (:fname, :lname, :email, :pw_hash, NOW(), NOW())'
    data = {
        'fname': request.form['first_name'],
        'lname': request.form['last_name'],
        'email': request.form['email'],
        'pw_hash': bcrypt.generate_password_hash(request.form['pass1'])
    }
    mysql.query_db(query, data)

    #set session id so the user is auto logged in
    query = 'SELECT id FROM users WHERE email = "{}"'.format(request.form['email'])
    uid = mysql.query_db(query)
    session['id'] = request.form(['email'])
    return redirect('/success')

@app.route('/login', methods=['POST'])
def login():
    # data validation
    query = "SELECT * FROM users WHERE email = '{}'".format(request.form['email'])
    user = mysql.query_db(query)
    print user
    if len(user)<1:
        flash('We could not find that email. If you haven\'t registered, please use the registration form.', 'error')
        return redirect('/')

    if not bcrypt.check_password_hash(user[0]['password'], request.form['pass1']):
        flash('Please enter the correct password.', 'error')

    session['id'] = request.form['email']

    return redirect('/success')

@app.route('/success')
def display_profile():
    print session['id']
    query = 'SELECT * FROM users WHERE email = "{}"'.format(session['id'])
    user_data = mysql.query_db(query)
    print user_data
    user = user_data
    print user
    return render_template('profile.html', user = user)

@app.route('/clear', methods=['post'])
def clear_session():
    session.clear()
    return redirect('/')


# an example of running a query
print mysql.query_db("SELECT * FROM users")
app.run(debug=True)
