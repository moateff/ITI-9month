const canvas = document.querySelector(".canvas");
const context = canvas.getContext("2d");

const width = canvas.width;
const height = canvas.height;

var gradient = context.createRadialGradient(width / 2 + 50, height / 2 - 100, 0, width / 2, height / 2, width / 2 + 100);
gradient.addColorStop(0, "white");
gradient.addColorStop(1, "blue");

context.fillStyle = gradient;
context.beginPath();
context.arc(width / 2, height / 2, width / 2, 0, Math.PI * 2);
context.fill();

gradient = context.createRadialGradient(width / 2 + 100, height / 2 + 100, 0, width / 2, height / 2, width / 2);
gradient.addColorStop(0, "white");
gradient.addColorStop(1, "blue");

context.fillStyle = gradient;
context.beginPath();
context.arc(width / 2, height / 2, width / 2 - 50, 0, Math.PI * 2);
context.fill();


context.beginPath();

// Left vertical
context.moveTo(width / 3, 2 * height / 3);
context.lineTo(width / 3, height / 3);

// Left diagonal
context.lineTo(width / 2, height / 2);

// Right diagonal
context.lineTo(2 * width / 3, height / 3);

// Right vertical
context.lineTo(2 * width / 3, 2 * height / 3);

context.strokeStyle = "white";
context.lineWidth = 24;
context.stroke();