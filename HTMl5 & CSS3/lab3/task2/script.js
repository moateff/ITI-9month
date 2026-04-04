const canvas = document.querySelector(".canvas");
const context = canvas.getContext("2d");

const width = canvas.width;
const height = canvas.height;

var gradient = context.createLinearGradient(0, 0, 0, height / 2);
gradient.addColorStop(0, "#4bb0d4");
gradient.addColorStop(1, "white");

context.fillStyle = gradient;
context.fillRect(20, 20, width - 40, height - 40);

gradient = context.createLinearGradient(0, height / 2, 0, height);
gradient.addColorStop(0, "#5fd100");
gradient.addColorStop(1, "white");

context.fillStyle = gradient;
context.fillRect(20, 20 + height / 2, width - 40, height - 40);


gradient = context.createLinearGradient(width / 3, height / 3, width / 3, height - 40);
gradient.addColorStop(0, "black");
gradient.addColorStop(1, "white");

context.strokeStyle = gradient;
context.lineWidth = 5;

context.beginPath();
context.moveTo(width / 3, 2 * height / 3);
context.lineTo(width / 3, height / 3);
context.lineTo(2 * width / 3, height / 3);
context.lineTo(2 * width / 3, 2 * height / 3);
context.stroke();
