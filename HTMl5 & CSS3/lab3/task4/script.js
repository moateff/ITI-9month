const canvas = document.querySelector(".canvas");
const context = canvas.getContext("2d");

const width = canvas.width;
const height = canvas.height;

const img = new Image();
img.src = "./image.jpg";

img.onload = () => {
    context.drawImage(img, 0, 0, width, height);
    context.fillText("Hello Canvas!", 40, 40);
}

// Set font style
context.font = "30px Tahoma";    // size + font-family
context.fillStyle = "black";    // text color