var testArr = ["Jack", 'Jill', 'Up', 'Hill'];

function fancyArray(testArr){
  for(var i = 0; i < testArr.length; i++){
    console.log(`${i} -> ${testArr[i]}`);
  }
}
fancyArray(testArr);
