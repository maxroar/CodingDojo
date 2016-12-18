var hour = 8;
var minutes = 50;
var period = "AM";

function timeTeller(hour, minutes, period){
  var phrase = "";
  var timeOfDay = "";

  if(minutes === 0){
    if(hour === 12){
      if(period = "AM"){
        return "It is midnight.";
      }else return "It is noon.";
    }else phrase=" exactly ";
  }

  if(period == "AM"){
    timeOfDay = "in the morning.";
  }else if(hour < 4){
    timeOfDay = "in the afternoon.";
  }else if(hour < 7){
    timeOfDay = "in the evening.";
  }else timeOfDay = "at night.";

  if(minutes % 15 == 0){
    switch(minutes){
      case 15: phrase = "quarter after";
        break;
      case 30: phrase = "half past";
        break;
      case 45: phrase = "quarter til" && hour++;
        break;
      default: break;
    }
  }else if(minutes % 15 !== 0){
    if (minutes <30){
      phrase = "just after";
    }else if (minutes > 30){
      phrase = "almost";
      hour++;
    }
  }



  return "It is " + phrase + hour +  timeOfDay;
}
console.log(timeTeller(hour, minutes, timeOfDay));
