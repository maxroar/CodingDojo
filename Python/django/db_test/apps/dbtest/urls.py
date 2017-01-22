from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^delete_comment$', views.delete_comment),
    url(r'^delete_message$', views.delete_message),
    url(r'^create_comment$', views.create_comment),
    url(r'^create_message$', views.create_message),
    url(r'^wall$', views.wall),
    url(r'^login$', views.login),
    url(r'^register$', views.register),
    url(r'^', views.index)
]
