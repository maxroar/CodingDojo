$(document).ready(function(){
  $("#butt").click(function(){
    var first = $("#fName").val();
    var last = $("#lName").val();
    var info = $("#info").val();

    if(first == "" || last == "" || info == ""){
      alert("Hey, guy, fill in those thangs.");
    }else{
      //$("#right").append("<div class='card'><h2 class='show'>" + first + " " + last + "</h2><p>Click for more info...</p><p");
      $("#right").append(`
        <h2 class="show">${first} ${last}</h2>
        <p class="show">Click for more info...</p>
        <p class="hide">${info}</p>
        `)
    }
    console.log(first, last, info);
  });
  $(".card").click(function(){

  });


});
