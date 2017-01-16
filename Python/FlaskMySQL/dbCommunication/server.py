from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key='key'
mysql = MySQLConnector(app, 'friendsdb')
#all routes go here
@app.route('/')
def display_index():
    friends = mysql.query_db("SELECT * FROM friends;")
    print(friends);
    return render_template('index.html', all_friends=friends)
@app.route('/friends', methods=['post'])
def create():
    #add a friend
    return redirect('/')
@app.route('/friends/<friend_id>')
def show(friend_id):
    query = 'SELECT * FROM friends WHERE id = :specific_id'
    data = {'specific_id': friend_id}
    friends = mysql.query_db(query, data)
    print(friends)
    return render_template('index.html', one_friend=friends[0])

app.run(debug=True)
