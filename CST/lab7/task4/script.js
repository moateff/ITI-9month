let input = document.querySelector("input");
let div = document.querySelector("div");

input.addEventListener("keydown", (event) => {
    div.innerHTML += "Physical Key (event.code): " 
        + event.code 
        + ", " 
        + "Character Printed (event.key): "
        + event.key 
        + "<br>";

});

document.addEventListener("keydown", (event) => {
    if (event.ctrlKey && event.key.toLowerCase() === "s") {
        event.preventDefault();
        alert("Ctrl + S is disabled!");
    }
});