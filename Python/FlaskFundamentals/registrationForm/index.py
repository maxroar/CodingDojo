from flask import Flask, render_template, redirect, request, session, flash
app = Flask(__name__)
app.secret_key = 'key'

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')


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

@app.route('/form_submit')
def on_submit():
    session['email'] = request.form['email']
    session['first'] = request.form['first']
    session['last'] = request.form['last']
    session['pass1'] = request.form['pass1']
    session['pass2'] = request.form['pass2']

    if len(email) < 5 or email != EMAIL_REGEX:
        flash('Please enter a valid email', 'error')

app.run(debug=True)
