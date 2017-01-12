from flask import Flask, render_template, session, redirect
app = Flask(__name__)
app.secret_key='key'

@app.route('/')
def display_index():
    try:
        session['counter'] += 1
    except KeyError:
        session['counter'] = 1
    return render_template('index.html')

@app.route('/reset', methods=['POST'])
def reset():
    session['counter'] = 1
    redirect('/')
app.run(debug=True)
