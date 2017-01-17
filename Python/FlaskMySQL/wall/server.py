from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
from flask.ext.bcrypt import Bcrypt
import re
app = Flask(__name__)
app.secret_key = 'key' #change this
bcrypt = Bcrypt(app)

mysql = MySQLConnector(app, 'the_wall2')

#regex variables to check new users against
REGEX_NAME = re.compile(r'^([a-zA-Z]){2,55}$')
REGEX_EMAIL = re.compile(r'^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$')
REGEX_PASS = re.compile(r'^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$')


#all routes go here
@app.route('/')
def display_index():
    if not 'user_id' in session:
        session['user_id'] = None
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
    userid = mysql.query_db(query)
    print userid
    user_id_value = userid[0]['id']
    session['user_id'] = user_id_value
    print session['user_id']
    return redirect('/wall')

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

    #set session id so the user is auto logged in
    query = 'SELECT id FROM users WHERE email = "{}"'.format(request.form['email'])
    userid = mysql.query_db(query)
    print userid
    user_id_value = userid[0]['id']
    session['user_id'] = user_id_value
    print session['user_id']

    return redirect('/wall')

@app.route('/wall')
def display_wall():
    if not 'user_id' in session:
        flash('You must be logged in to access the wall.', 'error')
        return redirect('index.html')

    query = 'SELECT * FROM users WHERE id = :uid'
    data = {'uid': session['user_id']}
    user = mysql.query_db(query, data)

    posts_query = 'SELECT posts.*, users.first_name, users.last_name FROM posts JOIN users ON posts.user_id = users.id'
    posts = mysql.query_db(posts_query)

    comment_query = 'SELECT comments.*, users.first_name, users.last_name FROM comments JOIN users ON comments.user_id = users.id'
    comments = mysql.query_db(comment_query)

    user = user[0]

    return render_template('wall.html', user=user, posts=posts, comments=comments)

@app.route('/clear')
def clear_session():
    session.clear()
    return redirect('/')

@app.route('/submit_post', methods=['post'])
def add_post():
    if len(request.form['new_post_text'])  < 1:
        flash('Post cannot be blank.', 'error')
        return redirect('/wall')

    query = 'INSERT INTO posts (text, user_id, created_at, updated_at) VALUES (:text, :uid, NOW(), NOW())'
    data = {
        'text': request.form['new_post_text'],
        'uid': session['user_id']
    }
    mysql.query_db(query, data)
    flash('GREAT SUCCESS', 'error')
    return redirect('/wall')

@app.route('/add_comment', methods=['post'])
def add_comment():
    if len(request.form['comment_text'])  < 1:
        flash('Comment cannot be blank.', 'error')
        return redirect('/wall')

    query = 'INSERT INTO comments (text, user_id, post_id, created_at, updated_at) VALUES (:text, :uid, :pid, NOW(), NOW())'
    data = {
        'text': request.form['comment_text'],
        'uid': session['user_id'],
        'pid': request.form['comment_post']
    }
    mysql.query_db(query, data)
    flash('GREAT SUCCESS', 'error')
    return redirect('/wall')

@app.route('/delete_post', methods=['post'])
def delete_post():
    #must delete comments related to post before deleting post due to foreign key errors
    query = 'DELETE FROM comments WHERE post_id = :pid'
    data = {'pid': request.form['del_post_id']}
    mysql.query_db(query, data)
    query = 'DELETE FROM posts WHERE id = :pid'
    mysql.query_db(query, data)
    return redirect('/wall')

@app.route('/delete_comment', methods=['post'])
def delete_comment():
    query = 'DELETE FROM comments WHERE id = :cid'
    data = {'cid': request.form['del_comment_id']}
    mysql.query_db(query, data)
    return redirect('/wall')

app.run(debug=True)
