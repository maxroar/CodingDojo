$(document).ready(function(){
  var level=[
    [2,2,2,2,2,2,2,2,2,2],
    [2,1,1,1,1,1,1,1,1,2],
    [2,1,1,1,1,1,1,1,1,2],
    [2,1,1,1,1,1,1,1,1,2],
    [2,1,1,1,1,1,1,1,1,2],
    [2,2,2,2,2,2,2,2,2,2]
  ];

  function displayLevel(level){
    var output = '';
    for(var i = 0; i < level.length; i++){
      output += '\n<div class="row">';
      for(var j = 0; j<level[i].length; j++){
        if(level[i][j] == 2){
          output += `\n\t<div class="brick"></div>`;
        }else if(level[i][j] == 1){
          output += `\n\tdiv class="coin"`;
        }else if(level[i][j] == 0){
          output += `\n\t<div class="empty"></div>\n`
        }
      }
      output+='</div>';
      $('#wrapper').append(output);
    }
    console.log(output);

  }

});
