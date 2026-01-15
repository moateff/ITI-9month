function task1() {
    let n = Number(prompt("Enter the number of elements:"));

    while(isNaN(n) || n <= 0) {
        alert("Please enter a valid number.");
        n = prompt("Enter the number of elements:");
    }

    let arr = [];

    for(let i = 0; i < n; i++) {
        let num = Number(prompt("Enter element " + (i + 1) + ":"));

        while(isNaN(num)) {
            alert("Please enter a valid number.");
            num = Number(prompt("Enter element " + (i + 1) + ":"));
        }

        arr.push(num);
    }

    console.log("Array:", arr);
    console.log("Array sorted (ascending):", arr.sort(function (a, b) { return Number(a) - Number(b) }));
    console.log("Array sorted (descending):", arr.reverse());
}

function showAddr(addr = {
    street: "unknown",
    buildingNum: "unknown",
    city: "unknown"
}) {
    let date = new Date();

    return addr.buildingNum 
        + " " 
        + addr.street 
        + ", " 
        + addr.city 
        + " city"
        + " registered in " + date.getDate() 
            + "/" + (date.getMonth() + 1) 
            + "/" + date.getFullYear();
}

function task2() {
    let addrObj = {
        street: "abc st",
        buildingNum: 15,
        city: "xyz"
    };

    console.log("Address: " + showAddr(addrObj));
} 

function dispVal(obj = {
    name: "unknown",
    age: 0
}, key) {
    if (!(key in obj)) {
        return "unknown key";
    }

    if (key === "age") {
        return obj[key] + " years old";
    }

    if (key === "name") {
        return obj[key] + " is your name";
    }
}

function task3() {
    let obj = {
        name: "Ali",
        age: 10
    };

    console.log(dispVal(obj, "name"));
    console.log(dispVal(obj, "age"));
}

function task4() {
    let radius = Number(prompt("Enter the radius:"));

    while(isNaN(radius) || radius <= 0) {
        alert("Please enter a valid number.");
        radius = Number(prompt("Enter the radius:"));
    }

    let area = Math.PI * radius * radius;

    alert("Circle area: " + area.toFixed(2));

    let num = Number(prompt("Enter a number to calculate its square root:"));

    while(isNaN(num) || num < 0) {
        alert("Please enter a valid number.");
        num = Number(prompt("Enter a number to calculate its square root:"));
    }

    alert("Square root of " + num + " is: " + Math.sqrt(num));

    let angle = Number(prompt("Enter an angle in degrees:"));

    while(isNaN(angle) || angle < 0) {
        alert("Please enter a valid number.");
        angle = Number(prompt("Enter an angle in degrees:"));
    }

    console.log("Cosine of " + angle + " degrees is: " + Math.cos(angle * Math.PI / 180).toFixed(2));
}
