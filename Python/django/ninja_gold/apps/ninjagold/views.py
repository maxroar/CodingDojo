from django.shortcuts import render, redirect
import random
# Create your views here.
def index(request):
    if not 'total' in request.session:
        request.session['total'] = 0
    return render(request, 'ninjagold/index.html')

def process_money(request):
    if request.method == 'POST':
        if request.POST['building'] == 'farm':
            money = random.randint(10,20)
        elif request.POST['building'] == 'cave':
            money = random.randint(5,10)
        elif request.POST['building'] == 'house':
            money = random.randint(2,5)
        elif request.POST['building'] == 'casino':
            money = random.randint(-50,50)
    request.session['total'] += money
    return redirect('/')

def clear(request):
    request.session.flush()
    return redirect('/index')

    request.session.total += money
    return redirect('/index')
