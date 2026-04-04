const images = document.querySelectorAll("#images img");

let currentIndex = 0;
let lightInterval = null;

let duration = Number(prompt("Enter time duration:"));
while(isNaN(duration) || duration <= 0) {
    alert("Please enter a valid number.");
    duration = Number(prompt("Enter time duration:"));
}

function lightMarble() {
    images.forEach(img => {
        img.src = "images/off.jpg";
    });

    images[currentIndex].src = "images/on.jpg";
    currentIndex = (currentIndex + 1) % images.length;
}

function startLighting() {
    if (!lightInterval) {
        lightInterval = setInterval(lightMarble, duration);
    }
}

function stopLighting() {
    clearInterval(lightInterval);
    lightInterval = null;
}

startLighting();

images.forEach(img => {
    img.addEventListener("mouseenter", stopLighting);
    img.addEventListener("mouseleave", startLighting);
});


