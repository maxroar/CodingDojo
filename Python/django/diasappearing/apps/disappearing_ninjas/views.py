from django.shortcuts import render, redirect

# Create your views here.
def index(request):
    return render(request, 'disappearing_ninjas/index.html')

def ninjas(request, color):
    if color == '':
        context = { 'image':  'turtles'}
    elif color == 'red':
        context = { 'image':  'red'}
    elif color == 'blue':
        context = { 'image':  'blue' }
    elif color == 'purple':
        context = { 'image':  'purple'}
    elif color == 'orange':
        context = { 'image':  'orange'}
    else:
        context = { 'image':  'megan'}
    return render(request, 'disappearing_ninjas/ninjas.html', context)
