from django.shortcuts import render, HttpResponse
import datetime



# Create your views here.
def index(request):
    stuff = datetime.datetime.now()
    context={
        'key': 'value',
        'things': stuff
    }
    return render(request, 'timedisplay/index.html', context)
