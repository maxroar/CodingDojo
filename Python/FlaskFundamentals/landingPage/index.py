from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def display_index():
    return render_template('index.html')

@app.route('/ninjas')
def display_ninjas():
    return render_template('ninjas.html')

@app.route('/dojos/new')
def display_dojos():
    return render_template('dojo.html')

app.run(debug=True)
