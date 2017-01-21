from django.shortcuts import render, redirect, HttpResponse



# Create your views here.
def index(request):
    print('views work!')
    return render(request, 'survey/index.html')
