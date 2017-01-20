from django.shortcuts import render

# Create your views here.
# controller
def index(request):
    print('i farted')
    return render(request, 'test_app/index.html')
def show(request):
    print('i fshow farted')
    return render(request, 'test_app/show.html')
