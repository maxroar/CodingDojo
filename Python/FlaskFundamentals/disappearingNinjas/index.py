from flask import Flask, render_template, redirect, request, session
app = Flask(__name__)
app.secret_key = 'key'

@app.route('/')
def display_index():
    return render_template('index.html')

@app.route('/ninja/<color>')
def display_turtles(color):
    if color == '':
        

app.run(debug=True)
