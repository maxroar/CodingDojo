from django.shortcuts import render, redirect
from models import User, Message, Comment
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
