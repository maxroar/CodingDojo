from __future__ import unicode_literals
from django.db import models
from ..login_reg.models import User

# Create your models here.
class PostManager(models.Model):
    def create_post(self):
        pass
    def get_all_data(self):
        user_data = User.objects.all()
        post_data = self.all()
        all_data = {
            users: user_data,
            posts: post_data
        }
        return all_data


class Post(models.Model):
    content = models.CharField(max_length=450)
    user = models.ForeignKey(User, related_name='user_posts')
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    objects = PostManager()
