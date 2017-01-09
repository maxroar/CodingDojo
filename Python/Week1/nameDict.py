users = {
 'Students': [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'},
     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
     {'first_name' : 'KB', 'last_name' : 'Tonel'}
  ],
 'Instructors': [
     {'first_name' : 'Michael', 'last_name' : 'Choi'},
     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
  ]
 }

def display_users(users):
    for key, data in users.items():
        print(key)
        label = 0
        for value in data:
            label +=1
            nameLength = len(value['first_name']) + len(value['last_name'])
            print('%d - %s %s %d' % (label, value['first_name'], value['last_name'], nameLength))
display_users(users)
