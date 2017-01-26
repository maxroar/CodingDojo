from django.shortcuts import render, redirect, HttpResponse
from .models import Post
# Create your views here.
def index(request):
    all_data = Post.objects.get_all_data()
    print(all_data)
    return render(request, 'posts/index.html')
def create_post(request):
    pass
def delete_post(request):
    pass
