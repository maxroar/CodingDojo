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
