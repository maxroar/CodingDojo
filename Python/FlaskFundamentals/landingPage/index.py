from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)



@app.route('/')
def display_index():
    if not 'data' in session:
        session['data'] = {}
    return render_template('index.html')

@app.route('/survey', methods=['POST'])
def form_submit():
    session['data']['name'] = request.form['name']
    session['data']['location'] = request.form['location']
    session['data']['language'] = request.form['language']
    session['data']['comment'] = request.form['comment']
    return redirect('/result')

@app.route('/result')
def display_result():
    return render_template('result.html')



app.run(debug=True)
