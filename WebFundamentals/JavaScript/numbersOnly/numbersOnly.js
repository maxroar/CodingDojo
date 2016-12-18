var startingArr = [0, "apple", -4, 1.343, false, 88];
function numbersOnly(startingArr){
  var numOnly = [];
  for(var i =0; i<startingArr.length; i++){
    if(typeof startingArr[i] === "number"){
      numOnly.push(startingArr[i]);
    }
  }
  return numOnly;
}
console.log(numbersOnly(startingArr));

function numRemover(startingArr){
  var idxPlace = 0;
  var origLength = startingArr.length;
  for(i = 0; i<startingArr.length; i++){
    if(typeof startingArr[i] !== "number"){
      startingArr[idxPlace] = startingArr[i];
      idxPlace++;
    }
  }
  for(var j = 0; j<origLength - idxPlace; j++){
    startingArr.pop();
  }
  return startingArr;
}
console.log(numRemover(startingArr));
