from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import Email, EmailManager


# Create your views here.
def index(request):
    return render(request, 'index.html')

def submit(request):
    if not EmailManager.validate_data(request.POST['email']):
        return redirect('/')
    Email.objects.create(email=request.POST['email'])
    context = {
        'emails': Email.objects.all()
    }
    return render(request, 'success.html', context)
