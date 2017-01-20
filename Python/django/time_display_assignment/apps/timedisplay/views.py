from django.shortcuts import render, HttpResponse

# Create your views here.
def show_time(request):
    context={
        'key': 'value'
    }
return render(request, 'timedisplay/index.html', context)
