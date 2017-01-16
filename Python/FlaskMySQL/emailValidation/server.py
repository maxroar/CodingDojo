from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
import re
app = Flask(__name__)
app.secret_key = 'key' #change this

mysql = MySQLConnector(app, 'email_validation')

EMAIL_REGEX = re.compile(r'^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$')

#all routes go here
@app.route('/')
def display_index():
    return render_template('index.html', emails=emails)
@app.route('/add', methods=['post'])
def create():
    if not
    query = 'INSERT INTO emails (email, created_at, updated_at) VALUES (:email, NOW(), NOW())'
    data = {
        'email': request.form['email']
    }
    mysql.query_db(query, data)
    return redirect('/')
app.run(debug=True)
