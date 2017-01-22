from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^ninjas/(?P<color>\w+)$', views.ninjas),
    url(r'^', views.index)
]
