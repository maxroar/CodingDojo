from django.shortcuts import render, redirect
from django.contrib import messages
from .models import User, Message, Comment
import re

#regex variables to check new users against
REGEX_NAME = re.compile(r'^([a-zA-Z]){2,55}$')
REGEX_EMAIL = re.compile(r'^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$')
REGEX_PASS = re.compile(r'^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$')

# Create your views here.
def index(request):
    if 'user_id' in request.session:
        return redirect('/login')
    return render(request, 'dbtest/index.html')
def register(request):
    fname = request.POST['first_name']
    lname = request.POST['last_name']
    email = request.POST['email']

    if not REGEX_NAME.match(request.POST['first_name']):
        messages.add_message(request, messages.ERROR, 'First name must be only letters and at least 2 characters.')
    if not REGEX_NAME.match(request.POST['last_name']):
        messages.add_message(request, messages.ERROR, 'Last name must be only letters and at least 2 characters.')
    if not REGEX_EMAIL.match(request.POST['email']):
        messages.add_message(request, messages.ERROR, 'Please use a valid email.')
    if not REGEX_PASS.match(request.POST['pass1']):
        messages.add_message(request, messages.ERROR, 'Password must be at least 8 characters and contain at least 1 of each: capital letter, lowercase letter, number, special character.')
    if not request.POST['pass1'] == request.POST['pass2']:
        messages.add_message(request, messages.ERROR, 'Passwords must match.')
    if messages:
        return redirect('/')
    return redirect('/')

def login(request):
    return redirect('/')

def wall(request):
    return redirect('/')

def create_message(request):
    return redirect('/')

def create_comment(request):
    return redirect('/')

def delete_message(request):
    return redirect('/')

def delete_comment(request):
    return redirect('/')
