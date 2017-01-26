from __future__ import unicode_literals
import re
from django.db import models

# Create your models here.
class Email(models.Model):
    email = models.CharField(max_length=99)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    
class EmailManager(models.Manager):
    def validate_data(self, postData):
        REGEX_EMAIL = re.compile(r'^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$')
        if not REGEX_EMAIL.match(postData['email']):
            messages.add_message(request, messages.ERROR, 'Please use a valid email.')
            return False
        return True
