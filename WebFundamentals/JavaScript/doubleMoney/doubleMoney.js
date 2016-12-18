var days = 30;
var money = .01;

function doubleMoney(days){
  var totalMoney = 0;
  for(var i = 1; i <= days; i++){
    totalMoney += money;
    money = money* 2;
  }
  return totalMoney;
}
console.log(`After ${days} days the reward will be $${doubleMoney(days)}`);
