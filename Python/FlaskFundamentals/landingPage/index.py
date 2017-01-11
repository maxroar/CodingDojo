from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def display_index():
    return render_template('index.html')

@app.route('/result')
def display_result():
    return render_template('result.html')

app.run(debug=True)
