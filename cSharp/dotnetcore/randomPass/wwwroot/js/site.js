// Write your Javascript code.
var $randomString = $(`.randomString`);
var $totalAttempts = $(`.totalAttempts`);

function getData(){
    $.post('/generate', function (data){
        console.log(data)
        var totalAttempts = data.totalNum;
        var randomString = data.randomString;

        $(`.randomString`).html(randomString);
        $(`.totalAttempts`).html(totalAttempts);
    })
    return false;
}

$(`.generate`).on(`click`, getData);