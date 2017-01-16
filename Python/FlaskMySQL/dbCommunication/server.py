from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key='key'
mysql = MySQLConnector(app, 'friendsdb')

#root route passes the friends table as a variable to index.html
@app.route('/')
def display_index():
    friends = mysql.query_db("SELECT * FROM friends;")
    return render_template('index.html', all_friends=friends)
#route for individual friends from the friends table
@app.route('/friends/<friend_id>/edit')
def show(friend_id):
    query = 'SELECT * FROM friends WHERE id = :specific_id'
    data = {'specific_id': friend_id}
    friends = mysql.query_db(query, data)
    return render_template('index.html', one_friend=friends[0])
#a route to add friends to the db
@app.route('/friends', methods=['post'])
def create():
    query = 'INSERT INTO friends (first_name, last_name, occupation, created_at, updated_at) VALUES (:first_name, :last_name, :occupation, NOW(), NOW())'
    data = {
        'first_name': request.form['first_name'],
        'last_name': request.form['last_name'],
        'occupation': request.form['occupation']
    }
    mysql.query_db(query, data)
    return redirect('/')
#a route to update friend entries
@app.route('/friends/<friend_id>/update', methods=['post'])
def update(friend_id):
    query = 'UPDATE friends SET first_name = :first_name, last_name = :last_name, occupation = :occupation, updated_at = NOW() WHERE id = %s' % friend_id
    data = {
        'first_name': request.form['first_name'],
        'last_name': request.form['last_name'],
        'occupation': request.form['occupation'],
        'id' : friend_id
    }
    mysql.query_db(query, data)
    return redirect('/')
#a route to remove friends from the db
@app.route('/friends/<friend_id>/delete', methods=['post'])
def destroy(friend_id):
    query = 'DELETE FROM friends WHERE id = %s' % friend_id
    data = {
        'id' : friend_id
    }
    mysql.query_db(query, data)
    return redirect('/')

app.run(debug=True)
