from flask import Flask, render_template, redirect, request, session
app = Flask(__name__)
app.secret_key = 'key'

@app.route('/')
def display_index():
    return render_template('index.html')

@app.route('/ninja/<color>')
def display_turtles(color):
    return render_template('ninja.html', color=color)

app.run(debug=True)
