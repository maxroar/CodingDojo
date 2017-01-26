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
    print(User._meta.db_table)
    if 'user_id' in request.session:
        return redirect('/login')
    return render(request, 'dbtest/index.html')
def register(request):
    if 'user_id' in request.session:
        messages.add_message(resuest, messages.ERROR, 'You were already logged in, goof. If you would like to log into or register a new account, please log out first.')
        print('logged in')
        return redirect('/wall')

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
    # if messages:
    #     print(messages)
    #     return redirect('/')
    email_var = request.POST['email']
    User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=request.POST['pass1'])

    print request.POST['email']

    if not 'user_id' in request.session:
        user_data = User.objects.all().filter(email=request.POST['email'])
        print(request.POST['email'])
        user_data = user_data[0]['id']
        print user_data
        # request.session['user_id'] = User.objects.get(id=user_data['user']['id'])
    # print(request.session.user_id)
    return redirect('/wall')

def login(request):
    if 'user_id' in request.session:
        return redirect('/wall')
    return redirect('/wall')

def wall(request):
    print(request.session['user_id'])
    context = {
        'user': User.objects.get(id=1),
        'posts': Message.objects.all(),
        'comments': Comment.objects.all()
    }
    print(context['user'])
    return render(request, '/dbtest/wall.html', context)

def create_message(request):
    return redirect('/')

def create_comment(request):
    return redirect('/')

def delete_message(request):
    return redirect('/')

def delete_comment(request):
    return redirect('/')
