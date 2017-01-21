from django.conf.urls import url
from . import views
def index(request):
    print('works!')

urlpatterns = [
    url(r'^random_num', views.num),
    url(r'^', views.index)
]
