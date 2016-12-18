var start = 2;
var end = 10;
var skipAmount = 2;

function skipArray(start, end, skipAmount){
  for(var i = start; i<end; i+=skipAmount){
    console.log(i);
  }
}
skipArray(start, end, skipAmount);
