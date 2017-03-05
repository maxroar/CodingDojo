$(document).ready(function(){
	var first_variable = "Yipee I was first!";
	console.log(first_variable);
	function firstFunc(){
		console.log(first_variable);
		first_variable = "Not anymore!!!";
	}
	console.log(first_variable);

	var food = "Chicken";
	function eat() {
		var food = "gone";       // CAREFUL!
		console.log(food);
		food = "half-chicken";
		console.log(food);
	}
	eat();
	console.log(food);
});
