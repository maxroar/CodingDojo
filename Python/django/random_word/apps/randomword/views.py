from django.shortcuts import render, redirect
import random, string



# Create your views here.
def index(request):
    print('views work!')
    return render(request, 'randomword/index.html')

def num(request):
    print(request.method)
    print('num works')
    if not 'num' in request.session:
        request.session['num'] = 0
    new_string = ''
    for i in range(14):
        new_string += random.choice(string.letters)
    print('request method worked')
    if not 'name' in request.session:
        request.session['name'] = new_string
    else:
        request.session['name'] = new_string
    request.session['num'] += 1
    return redirect('/random_num')
def clear(request):
    request.session.flush()
    return redirect('/')
