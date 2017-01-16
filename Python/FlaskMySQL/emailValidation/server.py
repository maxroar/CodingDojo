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
    emails = mysql.query_db('SELECT * FROM emails')
    return render_template('index.html', emails=emails)
@app.route('/success')
def display_success():
    emails = mysql.query_db('SELECT * FROM emails')
    return render_template('success.html', emails=emails)
@app.route('/add', methods=['post'])
def create():
    if not EMAIL_REGEX.match(request.form['email']):
        flash('Please enter a valid email address.', 'error')
        return redirect('/')
    query = 'INSERT INTO emails (email, created_at, updated_at) VALUES (:email, NOW(), NOW())'
    data = {
        'email': request.form['email']
    }
    mysql.query_db(query, data)
    flash('The email address you entered: %s is valid!' % request.form['email'], 'error')
    return redirect('/success')
# @app.route('/delete/<userid>', methods=['post'])
# def delete_entry():
#     query = 'DELETE FROM emails WHERE id = :id'
#     data = {
#         'id': userid
#     }
#     mysql.query_db(query, data)
#     flash('The user has been deleted.', 'error')
#     return redirect('/success')
app.run(debug=True)
