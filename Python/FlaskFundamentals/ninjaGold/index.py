from flask import Flask, render_template, redirect, request, session
import random
import datetime
app = Flask(__name__)
app.secret_key = 'key'

@app.route('/')
def display_index():
    if not 'total_gold' in session:
        session['total_gold'] = 0
    if not 'activities' in session:
        session['activities'] = []
    return render_template('index.html')


@app.route('/process_money', methods=['POST'])
def update_money():
    name_val = request.form['building']
    money = 0
    phrase = ''
    if name_val == 'farm':
        money = random.randrange(10,21)
    elif name_val == 'cave':
        money = random.randrange(5,11)
    elif name_val == 'house':
        money = random.randrange(2,6)
    elif name_val == 'casino':
        money = random.randrange(-50,31)

    session['total_gold'] += money

    stamp = datetime.datetime.now().strftime('%B %d, %Y %I:%M%p')

    log = {}
    log['timestamp'] = stamp
    log['amount'] = str(abs(money))
    log['text2'] = ' gold at the '
    log['text3'] = name_val + '!'

    if money < 0:
        log['text1'] = 'Oh noooooo you lost '
        log['class'] = 'red'
    else:
        log['text1'] = 'You earned '
        log['class'] = 'green'

    session['activities'].append(log)
    print(session['activities'])
    return redirect('/')

@app.route('/clear')
def session_clear():
    session.clear()

app.run(debug=True)
