from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^clear', views.clear),
    url(r'^process_money$', views.process_money),
    url(r'^', views.index)
]
