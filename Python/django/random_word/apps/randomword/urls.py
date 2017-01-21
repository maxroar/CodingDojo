from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^random_num$', views.index),
    url(r'^clear$', views.clear),
    url(r'^$', views.num)
]
