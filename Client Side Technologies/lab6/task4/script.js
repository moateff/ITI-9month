const images = [
    "images/1.png",
    "images/2.png",
    "images/3.png",
    "images/4.png",
    "images/5.png",
    "images/6.png"
];

let img;
let index = 0;
const minIndex = 0;
const maxIndex = images.length - 1;
let slideInterval = null;

window.onload = () => {
    img = document.querySelector("#image");

    if (!img) return;

    index = Math.floor(Math.random() * images.length);
    img.src = images[index];
};

const nextButton = document.querySelector("#next-button");
nextButton.onclick = () => {
    if (slideInterval) {
        alert("Slide is active!");
        return;
    }

    if (index < maxIndex) {
        index++;
        img.src = images[index];
    }
};

const prevButton = document.querySelector("#prev-button");
prevButton.onclick = () => {
    if (slideInterval) {
        alert("Slide is active!");
        return;
    }

    if (index > minIndex) {
        index--;
        img.src = images[index];
    }
};

const slideButton = document.querySelector("#slide-button");
slideButton.onclick = () => {
    if (slideInterval) {
        alert("Slide is already active!");
        return;
    }

    slideInterval = setInterval(() => {
        index = (index + 1) % images.length;
        img.src = images[index];
    }, 2000);
};

const stopButton = document.querySelector("#stop-button");
stopButton.onclick = () => {
    if (!slideInterval) {
        alert("Slide is already stopped!");
        return;
    }

    // slideButton.disabled = false;
    clearInterval(slideInterval);
    slideInterval = null;
};