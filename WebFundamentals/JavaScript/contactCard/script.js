$(document).ready(function(){
  //the function that creates a card when the button is clicked
  $("#butt").click(function newCard(){
    //variables to hold the values from the input boxes
    var first = $("#fName").val();
    var last = $("#lName").val();
    var info = $("#info").val();
    //an if statement to make sure all the inputs have text in them
    if(first == "" || last == "" || info == ""){
      alert("Hey, guy, fill in those thangs.");
    }else{//this else statement is where the actual function is puts have textexecuted if the in
      //create a variable that holds the html we want to be inserted into the webpage
      var cardData = $(`
        <div class='card'>
          <h2 class="show">${first} ${last}</h2>
          <p class="show">Click for more info...</p>
          <p class="hide">${info}</p>
        </div>
        `).on('click', function(){//this .on('click') is saying "when you click the button to create the card then you also want to add the following function which will make the content toggle between shown and hidden"
            $(this).children().toggle(); //if content is visible then hide it
            // $(this).find('.hide').toggle(); //if content is hidden then show it
        });
      //now that everything is properly initiated, append the data with the function already initiated to the #right div
      $("#right").append(cardData);
      //here is some code to clear the values of the forms
      $("#fName").val("");
      $("#lName").val("");
      $("#info").val("");
    }
  });
});
