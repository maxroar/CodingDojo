from flask import Flask, render_template, redirect, request, session
import random
app = Flask(__name__)
app.secret_key = 'key'

@app.route('/')
def display_index():
    if not 'total_gold' in session:
        session['total_gold'] = 0
        session['activities'] = ''



    return render_template('index.html')


@app.route('/process_money', methods=['POST'])
def update_money():
    name_val = form.request['value']
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

    if money < 0:
        session['activities'] += '<p class="red">Oh noooooo you lost <strong>' + abs(money) + '</strong> gold at the casino!</p>'
    else:
        session['activities'] += '<p class="green">You earned <strong>' + money + '</strong> gold at the ' + name_val + '!</p>'

    return redirect('/')


app.run(debug=True)
