from flask import Flask, render_template, request, redirect, session, flash
app = Flask(__name__)
app.secret_key = 'key'


@app.route('/')
def display_index():
    if not 'name' in session:
        session['name'] = ''
    if not 'location' in session:
        session['location'] = ''
    if not 'language' in session:
        session['language'] = ''
    if not 'comment' in session:
        session['comment'] = ''
    return render_template('index.html')

@app.route('/survey', methods=['POST'])
def form_submit():
    if len(request.form['name']) < 1:
        flash('Name cannot be empty!')
        return redirect('/')
    elif len(request.form['comment']) < 1:
        flash('Comment cannot be empty!')
        return redirect('/')
    else:
        session['name'] = request.form['name']
        session['location'] = request.form['location']
        session['language'] = request.form['language']
        session['comment'] = request.form['comment']
    return redirect('/result')

@app.route('/result')
def display_result():
    return render_template('result.html')



app.run(debug=True)
