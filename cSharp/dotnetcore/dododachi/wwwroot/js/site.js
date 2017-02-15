// Write your Javascript code.
var $fullness = $(`.fullness`);
var $happiness = $(`.happiness`);
var $meals = $(`.meals`);
var $energy = $(`.energy`);
var $message = $(`.message`);
var $image = $(`.image`);

function getStats(){
    $.post(`/getStats`, function (data){
        var energy = data.energy;
        var happiness = data.happiness;
        var meals = data.meals;
        var fullness = data.fullness;
        var message = data.message;
        var image = data.image;
        var gameOver = data.gameOver;

        var imageStr = '<img src="/images/' + image + '" alt="image" class="img-responsive"/>';

        $(`.energy`).html(energy)
        $(`.happiness`).html(happiness)
        $(`.meals`).html(meals)
        $(`.fullness`).html(fullness)
        $(`.message`).html(message)
        $(`.image`).html(imageStr)

        return false;
    });
        
    
}

function getData(){
    var route = this.name;
    $.post(`/${route}`, function (data){
        var energy = data.energy;
        var happiness = data.happiness;
        var meals = data.meals;
        var fullness = data.fullness;
        var message = data.message;
        var image = data.image;
        var gameOver = data.gameOver;

        var imageStr = '<img src="/images/' + image + '" alt="image" class="img-responsive"/>';

        $(`.energy`).html(energy)
        $(`.happiness`).html(happiness)
        $(`.meals`).html(meals)
        $(`.fullness`).html(fullness)
        $(`.message`).html(message)
        $(`.image`).html(imageStr)

        if(gameOver == true){
            $(`.choice-buttons`).toggle();
            $(`.reset-button`).toggle();
        }
        });
    
    return false;
}

function reset(){
    $.post(`/reset`, function (data){
            $(`.choice-buttons`).toggle();
            $(`.reset-button`).toggle();
            getStats();
        });
    
    return false;
}

$(document).ready(function (){
    console.log("JAVASCRIPT")
    getStats();
    $(`.reset-button`).toggle();
});

$(`.choice-btn`).on(`click`, getData);
$(`.reset-button`).on(`click`, reset);