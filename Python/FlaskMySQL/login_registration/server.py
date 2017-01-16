from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
from flask.ext.bcrypt import Bcrypt
import re
app = Flask(__name__)
app.secret_key = 'key' #change this

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

    if not validation_error:
        return redirect('/')

    query = 'INSERT INTO users (first_name, last_name, email, created_at, updated_at) VALUES (:first_name, :last_name, :email, NOW(), NOW())'
    data = {
        'first_name': request.form['first_name'],
        'last_name': request.form['last_name'],
        'occupation': request.form['occupation']
    }
    mysql.query_db(query, data)
    return redirect('/')

# an example of running a query
print mysql.query_db("SELECT * FROM users")
app.run(debug=True)
