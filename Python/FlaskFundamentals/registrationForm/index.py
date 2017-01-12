from flask import Flask, render_template, redirect, request, session, flash
import re
app = Flask(__name__)
app.secret_key = 'key'

EMAIL_REGEX = re.compile(r'^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$')
PASS_REGEX = re.compile(r'^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,25}$')

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

@app.route('/form_submit', methods=['POST'])
def on_submit():


    if len(request.form['email']) < 5 or not EMAIL_REGEX.match(request.form['email']):
        flash('Please enter a valid email', 'error')
        return redirect('/')
    elif len(request.form['first']) < 1 or not request.form['first'].isalpha():
        flash('Please enter a valid first name', 'error')
        return redirect('/')
    elif len(request.form['last']) < 1 or not request.form['last'].isalpha():
        flash('Please enter a valid last name', 'error')
        return redirect('/')
    elif len(request.form['pass1']) < 8 or not PASS_REGEX.match(request.form['pass1']):
        flash('Password must be at least 8 characters and include a capital letter and a number', 'error')
        return redirect('/')
    elif request.form['pass2'] != request.form['pass1']:
        flash('Passwords must match', 'error')
        return redirect('/')
    else:
        session['email'] = request.form['email']
        session['first'] = request.form['first']
        session['last'] = request.form['last']
        session['pass1'] = request.form['pass1']
        session['pass2'] = request.form['pass2']
        return render_template('success.html')

app.run(debug=True)
