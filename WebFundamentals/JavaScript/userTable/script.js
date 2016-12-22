$(document).ready(function(){
  $('button').click(function(){
    var dataArr = [$('#0'), $('#1'), $('#2'), $('#3')];
    for(var i=0; i<4; i++){
      dataArr[i] = dataArr[i].val();
    }
    for(var j=0; j<4; j++){
      if(dataArr[j] == ""){
        alert("Hey, dude, enter your digits");
        return;
      }
    }
    var appStr = "<tr>";
    for(var k=0; k<4; k++){
      appStr+="<td>" + dataArr[k] + "</td>";
    }
    appStr+="</tr>";
    $('tbody').append(appStr);
  });
});
