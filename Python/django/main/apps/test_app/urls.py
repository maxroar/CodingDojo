from django.conf.urls import url
from . import views

def index(request):
    print "prrrrrrrrrrrrrrrrrrrrrrrt"

urlpatterns = [
    url(r'^$', views.index),
    url(r'^users$', views.show)
]
