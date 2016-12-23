$(document).ready(function(){
  $('.house').on('click', function(){
    var number = $(this).data('num');
    console.log(number);
    $.get(`http://anapioficeandfire.com/api/houses/${number}`, function(houseInfo){
      console.log(houseInfo);

      var infoStr = `
        <h2>Name: </h2><p>${houseInfo.name}</p>
        <h2>Words: </h2><p>${houseInfo.words}</p>
        <h2>Titles:</h2>
        <ul>`;
      for(var i=0; i<houseInfo.titles.length; i++){
        infoStr += `<li>${houseInfo.titles[i]}</li>`
      }
      infoStr += '</ul>'
      $('#info').html(infoStr);

    });
  });
});
