from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name='the_wall'),
    url(r'^create_post$', views.create_post, name='create_post'),
    url(r'^delete_post$', views.delete_post, name='delete_post')
]
