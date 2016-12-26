$(document).ready(function(){
  var level=[
    [
      [2,2,2,2,2,2,2,2,2,2],
      [2,0,2,1,1,1,2,1,3,2],
      [2,1,2,1,2,1,1,1,1,2],
      [2,1,1,1,2,1,2,1,4,2],
      [2,1,2,1,1,1,2,2,3,2],
      [2,2,2,2,2,2,2,2,2,2]
    ],
    [
      [2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2],
      [2,0,1,1,1,4,1,1,1,2,1,1,1,1,1,1,1,1,2],
      [2,1,2,1,2,2,2,2,1,2,1,2,2,2,2,1,2,1,2],
      [2,1,2,1,1,1,1,2,1,1,1,2,1,1,1,1,2,1,2],
      [2,1,2,2,1,2,1,2,1,2,1,2,1,2,1,2,2,1,2],
      [2,1,3,1,1,2,1,2,1,2,1,2,1,2,1,1,1,3,2],
      [2,2,1,2,2,2,1,1,1,2,1,1,1,2,2,2,2,1,2],
      [2,1,1,1,1,2,1,2,2,2,2,2,1,1,1,1,1,1,2],
      [2,1,2,2,1,1,1,1,2,1,1,1,1,2,2,1,2,1,2],
      [2,4,1,1,1,2,2,1,1,1,2,2,1,1,1,1,1,3,2],
      [2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2]
    ],
    [
      [2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2],
      [6,0,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,2],
      [2,1,2,1,2,2,2,2,1,2,1,2,2,2,2,1,2,1,2],
      [2,1,3,1,1,1,1,2,1,1,1,2,1,3,1,1,2,1,2],
      [2,1,2,2,1,2,1,2,1,2,1,2,1,2,1,2,2,1,2],
      [2,1,1,1,1,2,1,2,1,2,1,2,1,2,1,1,1,1,2],
      [2,2,1,2,2,2,1,1,1,2,1,1,1,2,2,2,2,1,2],
      [2,1,3,1,1,2,1,2,2,2,2,2,1,3,1,1,4,1,2],
      [2,1,2,2,1,1,1,1,2,1,1,1,1,2,2,1,2,1,2],
      [2,4,1,1,1,2,2,1,1,1,2,2,1,1,1,1,1,1,5],
      [2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2]
    ],
    [

    ]
  ];
  var lvlID = 0;
  var score = 0;

  var aykman = {
    x: 1,
    y: 1
  }

  function displayAykman(){
    document.getElementById('aykman').style.top = aykman.y*20+"px";
    document.getElementById('aykman').style.left = aykman.x*20+"px";
  }

  function displayLevel(){
    var output = '';
    var winner = 0;
    for(var i = 0; i < level[lvlID].length; i++){
      output += '<div class="row">';
      console.log(level[lvlID][i]);
      for(var j = 0; j<level[lvlID][i].length; j++){
        console.log(level[lvlID][i][j])
        if(level[lvlID][i][j] == 2){
          output += '<div class="brick"></div>';
        }else if(level[lvlID][i][j] == 1){
          output += '<div class="coin"></div>';
          winner ++;
        }else if(level[lvlID][i][j] == 0){
          output += '<div class="empty"></div>'
        }else if(level[lvlID][i][j] == 3){
          output += '<div class="cookie"></div>'
        }else if(level[lvlID][i][j] == 4){
          output += '<div class="alien"></div>'
        }else if(level[lvlID][i][j] == 5){
          output += '<div class="tpr"></div>'
        }else if(level[lvlID][i][j] == 6){
          output += '<div class="tpl"></div>'
        }
        console.log(output);
      }
      output+='</div>';
    }
    output+='<div id="aykman"></div>'
    console.log(output);
    $('#levelMap').html(output);
    if(winner == 0){
      if(lvlID<2){
        lvlID++;
        alert(`Winner!\nScore: ${score}\nNext level: ${lvlID+1}`);
        aykman.x=1;
        aykman.y=1;
        displayLevel();
        displayAykman();
        displayScore();
      }
      else{
        alert(`Winner!\nScore: ${score}\nYou beat every level!`);
      }
    }
  }
  function displayScore(){
    $('#scoreCard').html(score);
  }
  $(".lvlBtn").on('click', function(){
    lvlID = $(this).attr('id');
    displayLevel();
    displayAykman();
    displayScore();
  })


  document.onkeydown = function(e){
    console.log(e.which);
    if(e.which == 40){
      aykman.y ++;
      if(level[lvlID][aykman.y][aykman.x] == 2){
        aykman.y--;
      }
    }
    else if(e.which == 39){
      aykman.x ++;
      if(level[lvlID][aykman.y][aykman.x] == 2){
        aykman.x--;
      }
    }
    else if(e.which == 38){
      aykman.y --;
      if(level[lvlID][aykman.y][aykman.x] == 2){
        aykman.y++;
      }
    }
    else if(e.which == 37){
      aykman.x --;
      if(level[lvlID][aykman.y][aykman.x] == 2){
        aykman.x++;
      }
    }
    //if else statements to handle the points/teleporters
    if(level[lvlID][aykman.y][aykman.x] == 1){
      level[lvlID][aykman.y][aykman.x] = 0;
      score+=10;
    }else if(level[lvlID][aykman.y][aykman.x] == 3){
      level[lvlID][aykman.y][aykman.x] = 0;
      score+=50;
    }
    //4 represents ghosts
    else if(level[lvlID][aykman.y][aykman.x] == 4){
      level[lvlID][aykman.y][aykman.x] = 0;
      score=0;
      alert('Loser!');
    }
    //5 represents right teleporter
    else if(level[lvlID][aykman.y][aykman.x] == 5){
      aykman.y = 1;
      aykman.x = 1;
      if(level[lvlID][aykman.y][aykman.x] == 1){
        level[lvlID][aykman.y][aykman.x] = 0;
        score+=10;
      }else if(level[lvlID][aykman.y][aykman.x] == 3){
        level[lvlID][aykman.y][aykman.x] = 0;
        score+=50;
      }
    }
    //6 represents the left teleporter
    else if(level[lvlID][aykman.y][aykman.x] == 6){
      aykman.y = 9;
      aykman.x = 17;
      if(level[lvlID][aykman.y][aykman.x] == 1){
        level[lvlID][aykman.y][aykman.x] = 0;
        score+=10;
      }else if(level[lvlID][aykman.y][aykman.x] == 3){
        level[lvlID][aykman.y][aykman.x] = 0;
        score+=50;
      }
    }
    displayLevel();
    displayAykman();
    displayScore();
  };

});
