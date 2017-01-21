from django.shortcuts import render, redirect
import random

# Create your views here.
def index(request):
    print('views work!')
    return render(request, 'randomword/index.html')

def num(request):
    print(request.method)
    print('num works')
    if request.method == 'POST':
        end_char = 0
        new_string = ''
        while end_char < 14:
            new_string += str(random.randint(0, 10))
        print('request method worked')
        return redirect(index, string_num=new_string)
    else:
        print('error with post method')
        return redirect(index)
