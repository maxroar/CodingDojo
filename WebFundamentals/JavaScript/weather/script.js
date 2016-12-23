$(document).ready(function(){
  $('form').on('submit', function(){
    var cityName = $(this).serialize();
    console.log(cityName);
    $.get(`http://api.openweathermap.org/data/2.5/weather?${cityName}&units=imperial&appid=be0f61e7a55bf452fa1de4d1ba944b32`, function(response){
      console.log('.data', response);
      var temp = response.main.temp;
      console.log(temp);
      var city = response.name;
      $('body').append(`
          <h1>${city}</h1>
          <h2>${temp}&#8457;</h2>
        `)
    });
    return false;
  });
});
