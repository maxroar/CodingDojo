# django

start django environment

create django app:
`$ django-admin startproject <name_of_project>`
`$ djas <proj_name>` because zshrc

in settings.py add `apps.survey.urls` to use its urls

create `/apps` direction and cd into `/apps`
create `__init__.py` file and leave it empty.

when inside apps dir to create new subproject:
`$ python ../manage.py startapp <sub_proj_name>`

to run server:
`$ python <path_to manage.py> runserver`

in a form you need:
`{% csrf_token %}`

to get session to work:
```
python manage.py makemigrations
python manage.py migrate
```
