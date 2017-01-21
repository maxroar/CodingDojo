from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^clear', views.clear),
    url(r'^success', views.success),
    url(r'^proccess', views.proccess),
    url(r'^$', views.index)
]
