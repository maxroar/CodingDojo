from flask import Flask, render_template, redirect, request, session
import random
app = Flask(__name__)

@app.route('/')
def display_index():
    if not session['total_gold']:
        session['total_gold'] = 0
        session['activities'] = ''



    return render_template('index.html')


@app.route('/process_money', methods='POST')
def update_money():
    name_val = form.request['value']
    money = 0
    if name_val == 'farm':
        money = random.randrange(10,21)
    elif name_val == 'farm':
        money = random.randrange(5,11)
    elif name_val == 'farm':
        money = random.randrange(2,6)
    elif name_val == 'farm':
        money = random.randrange(-50,31)






app.run(debug=True)
