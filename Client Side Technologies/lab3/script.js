var message = prompt("Enter your message: ");
for(var i = 1; i <= 6; i++) {
   document.write("<h" + i + ">" + message + "</h" + i + ">");
}



var sum = 0;
while (true) {
    var input = prompt("Enter a number (0 to stop): ");

    if (input === null) break;

    var num = Number(input);

    if(isNaN(num)) {
        alert("Please enter a numeric value.");
        continue;
    }

    if (num === 0) break;

    sum += num;
    console.log("sum = " + sum);

    if (sum > 100) break;
}



var a = prompt("Enter first number:");
var b = prompt("Enter second number:");

var result = !isNaN(a) && !isNaN(b)
    ? (Number(a) > Number(b) ? a : b)
    : "Invalid input";

alert(result);



var x = prompt("Enter first number:");
var y = prompt("Enter second number:");
var z = prompt("Enter third number:");

if (isNaN(x) || isNaN(y) || isNaN(z)) {
    alert("Invalid input");
} else {
    x = Number(x);
    y = Number(y);
    z = Number(z);

    if (x % y === 0 && x % z === 0) {
        alert(x + " is divisible by both " + y + " and " + z);
    } else if (x % y === 0) {
        alert(x + " is divisible by " + y);
    } else if (x % z === 0) {
        alert(x + " is divisible by " + z);
    } else {
        alert(x + " is not divisible by " + y + " or " + z);
    }
}



var start = Number(prompt("Enter the start value:"));
var end = Number(prompt("Enter the end value:"));

if (isNaN(start) || isNaN(end)) {
    alert("Please enter valid numeric values.");
} else {
    var multiplesOf3 = "";
    var multiplesOf5 = "";
    var sum = 0;
    
    for (var i = start; i <= end; i++) {
        var flag = false;

        if (i % 3 === 0) {
            multiplesOf3 += i + " ";
            flag = true;
            sum += i;
        } 
        if (i % 5 === 0) {
            multiplesOf5 += i + " ";
            
            if (!flag) 
                sum += i;
        }
    }

    console.log("Number multiple of 3: " + multiplesOf3);
    console.log("Number multiple of 5: " + multiplesOf5);
    console.log("Total sum is " + sum);
}



var rows = Number(prompt("Enter rows number:"));

if (isNaN(rows) || rows <= 0) {
    alert("Invalid input");
} else {
    for (var i = 1; i <= rows; i++) {
        var str = "";
        for (var j = 1; j <= i; j++) {
            str += "* ";
        }
        console.log(str);
    }
}



var x = prompt("Enter first number:");
var y = prompt("Enter second number:");
var z = prompt("Enter type (odd / even / no):");

if (
    isNaN(x) || isNaN(y) ||
    (z !== "odd" && z !== "even" && z !== "no")
) {
    alert("Invalid input");
} else {
    x = Number(x);
    y = Number(y);

    var result = "";
    var sum = 0;

    var step = x <= y ? 1 : -1;

    for (var i = x; step === 1 ? i <= y : i >= y; i += step) {
        var isOdd = i % 2 !== 0;
        var isEven = i % 2 === 0;

        if (
            z === "no" ||
            (z === "odd" && isOdd) ||
            (z === "even" && isEven)
        ) {
            result += i + " ";
            sum += i;
        }
    }

    console.log("Result numbers are " + result);
    console.log("Total sum is " + sum);
}
