$(document).ready(function() {

    function Vehicle(name, wheels, speed, passengers) {
        this.name = name;
        this.wheels = wheels;
        this.speed = speed;
        this.passengers = passengers;
        var distanceTravelled = 0;
        var getDistanceTravelled = function() {
            console.log(this.distanceTravelled);
        }
        var updateDistanceTravelled = function(miles){
            this.distanceTravelled += miles * this.speed;
        }

        this.makeNoise = () => {
            console.log(`Honk Honk`);
        }

        this.move = (miles) => {
            updateDistanceTravelled(miles);
            getDistanceTravelled();
            this.makeNoise();
        }
    }

    function Bike(name, wheels, speed, passengers) {
        Vehicle.call(this, name, wheels, speed, passengers);
        this.makeNoise = function() {
            console.log(`ding, ding`);
        }
    }


    function Bus(name, wheels, speed, passengers) {
        Vehicle.call(this, name, wheels, speed, passengers);
        this.pickUpPassengers = function(pNum) {
            this.passengers += pNum;
        }
    }

    var sedan = new Vehicle(`sedan`, 4, 55, 4);
    sedan.makeNoise();

    var bike = new Bike(`bike`, 2, 25, 0);
    bike.makeNoise();

    var bus = new Bus(`bus`, 8, 30, 0);
    bus.makeNoise();
    bus.pickUpPassengers(11);
    console.log(bus.passengers);
    bus.move(20);
});
