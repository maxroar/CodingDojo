var wallet = 50;

function spinSlot(wallet){
  if(wallet <= 0){
    console.log("Come back when you have some money!");
  }
  wallet --;
  var jackpot = Math.trunc(Math.random() * 100);
  var spin = Math.trunc(Math.random() * 100);
  var winnings = 0;
  if (spin === jackpot){
    winnings = Math.trunc(Math.random()*50 + 50);
    wallet += winnings;
  }
  console.log(`You won $${winnings} and your new total is $${wallet}.`);
  console.log(`jp ${jackpot} spin ${spin} win ${winnings} wallet ${wallet}`)
}

spinSlot(wallet);
