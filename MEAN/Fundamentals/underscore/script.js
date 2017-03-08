$(document).ready(function(){
    var lib = {
        map: function map = (arr, funny) => {
            for(var i in arr){
                funny(arr[i]);
            }

            return arr;
        },

        reduce: function reduce = (arr, funny) => {
            var sum = 0;
            for(var i = 0; i < arr.length; i++){
                sum += i;
            }
            return sum;
        },

        find: function find = (arr, single) => {
            var i = 0;
            while(i < arr.length || arr[i] !== single){
                i++;
            }
            if(i < arr.length){
                return i;
            }
            return undefined;
        },

        filter: function filter = (arr, single) => {
            var newArr = [];
            for (var i = 0; i < arr.length; i++) {
                if(arr[i] === single){
                    newArr.push(arr[i]);
                }
            }
        },

        reject: function reject = (arr, single) => {
            var newArr = [];
            for (var i = 0; i < arr.length; i++) {
                if(arr[i] !== single){
                    newArr.push(arr[i]);
                }
            }
        },
    };



});
