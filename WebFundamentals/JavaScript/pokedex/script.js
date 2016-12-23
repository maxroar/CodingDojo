// $(document).ready(function(){
//
//
//   for(var i=1; i <= 151; i++){
//     var pokemonAPI = $(`<img id='${i}' src="http://pokeapi.co/media/img/${i}.png">`).on('click', function(){
//
//       var name = $.get(`http://pokeapi.co/api/v1/pokemon/${i}/`, function(res){
//         console.log(res);
//       }, 'json');
//       });
//     $('#left').append(pokemonAPI);
//   }
// });
// 'http://pokeapi.co/media/img/'
// 'http://pokeapi.co/api/v1/pokemon/${pokeNum}/'

$(document).ready(function(){
  //loop to set ids and display all images
  for(var i=1; i<= 151; i++){
    var pokemonAPI = $(`<img class='pokeImg' data-pokeid='${i}' src="http://54.70.82.18/media/${i}.png">`);
    $('#left').append(pokemonAPI);
  }
  $('.pokeImg').on('click',function(){
    console.log(this);
    var pokeNum = $(this).data('pokeid');
    // $.get(`http://pokeapi.co/api/v1/pokemon/${pokeNum}/`, function(res){
    //   console.log(res);
    //   //assign vars
    // }, 'json');
    console.log('before .get', pokeNum)
    $.get(`http://pokeapi.co/api/v1/pokemon/${pokeNum}/`, function(response) {
      console.log('DONNEEEEEE', response)
    })
  })
});
