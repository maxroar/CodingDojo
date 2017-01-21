from django.shortcuts import render, redirect, HttpResponse



# Create your views here.
def index(request):
    print('views work!')
    if 'name' in request.session:
        print('log out please')
        return redirect('/success')
    return render(request, 'survey/index.html')

def proccess(request):
    print('proccess works')
    if not 'name' in request.session:
        request.session['name'] = request.POST['name']
        request.session['location'] = request.POST['location']
        request.session['language'] = request.POST['language']
        request.session['comment'] = request.POST['comment']
    return redirect('/success')
def success(request):
    context = {
        'name': request.session['name'],
        'location': request.session['location'],
        'language': request.session['language'],
        'comment': request.session['comment']
    }
    return render(request, 'survey/success.html', context)
def clear(request):
    request.session.flush()
    return redirect('/')
