var express = require('express');

var app = express();

app.get('/', function(request, response) {
    response.send("<h1>Hello Express</h1>");
});

app.listen(8000, function() {
    console.log("listening on 8000");
});

// look for all static files in static folder
app.use(express.static(__dirname + '/static'));

// This sets the location where express will look for the ejs views
app.set('views', __dirname + '/views'); 
// Now lets set the view engine itself so that express knows that we are using jade as opposed to another templating engine like jade
app.set('view engine', 'pug');

app.get('/users', function(request, response){
	var user_arr = [
		{name: 'max', email: 'mxrohrer@gmail.com'},
		{name: 'max2', email: 'mxrohrer@gmail.com2'}
	];
	response.render('users', {users: user_arr});
})