// Write your Javascript code.
var $fullness = $(`.fullness`);
var $happiness = $(`.happiness`);
var $meals = $(`.meals`);
var $energy = $(`.energy`);
var $message = $(`.message`);
var $image = $(`.image`);

function getData(){
    var route = this.name;
    $.post(`/${route}`, function (data){
        console.log(data)
        var energy = data.energy;
        var happiness = data.happiness;
        var meals = data.meals;
        var fullness = data.fullness;
        var message = data.message;
        var image = data.image;

        $(`.energy`).html(energy)
        $(`.happiness`).html(happiness)
        $(`.meals`).html(meals)
        $(`.fullness`).html(fullness)
        $(`.message`).html(message)
        $(`.image`).html(image)
    })
    return false;
}

$(`.choice-btn`).on(`click`, getData);