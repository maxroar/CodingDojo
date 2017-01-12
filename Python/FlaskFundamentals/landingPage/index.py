from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)

data = {}

@app.route('/')
def display_index():
    return render_template('index.html')

@app.route('/survey', methods=['POST'])
def form_submit():
    data['name'] = request.form['name']
    data['location'] = request.form['location']
    data['language'] = request.form['language']
    data['comment'] = request.form['comment']
    return redirect('/result')

@app.route('/result')
def display_result():
    return render_template('result.html')

app.run(debug=True)
