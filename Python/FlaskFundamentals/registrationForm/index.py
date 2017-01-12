from flask import Flask, render_template, redirect, request, session, flash
app = Flask(__name__)
app.secret_key = 'key'

@app.route('/')
def display_index():
    if not 'email' in session:
        session['email'] = ''
    if not 'first_name' in session:
        session['first_name'] = ''
    if not 'last_name' in session:
        session['last_name'] = ''
    if not 'pass1' in session:
        session['pass1'] = ''
    if not 'pass2' in session:
        session['pass2'] = ''

    return render_template('index.html')

app.run(debug=True)
