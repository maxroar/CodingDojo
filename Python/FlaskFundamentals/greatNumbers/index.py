from flask import Flask, render_template, redirect, request, session
import random
app = Flask(__name__)
app.secret_key = "key"



@app.route('/')
def display_index():
    if not 'randNum' in session:
        global headText
        headText = 'Guess the number!'
        session['randNum'] = random.randrange(1,101)
        session['guess_state'] = ''
    return render_template('index.html')

@app.route('/guess', methods=['POST'])
def guessSubmit():
    print(request.form['guess'])
    print(session['randNum'])

    try:
        session['guessNum'] = int(request.form['guess'])
    except ValueError:
        session['guessNum'] = False

    if session['guessNum']:
        session['error'] = ''
        if session['guessNum'] == session['randNum']:
            session['guess_state'] = 0
        elif session['guessNum'] > session['randNum']:
            session['guess_state'] = 1
        elif session['guessNum'] < session['randNum']:
            session['guess_state'] = 2
    else:
        session['error'] = 'Please enter a number between 1-100'
        session['guess_state'] = -1

    return redirect('/')

@app.route('/reset', methods=['POST'])
def reset():
    session.pop('randNum')
    return redirect('/')

app.run(debug=True)
