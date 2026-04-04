const canvas = document.querySelector(".canvas");
const context = canvas.getContext("2d");

const width = canvas.width;
const height = canvas.height;

const rectWidth = 80;
const rectHeight = 60;
const xSpacing = 40;
const ySpacing = 40;
const xBase = 20;
const yBase = 20;

context.translate(xBase, yBase);

for (let row = 0; row < 3; row++) {
  for (let col = 0; col < 3; col++) {
    context.save();

    context.translate(col * (rectWidth + xSpacing), row * (rectHeight + ySpacing));

    context.strokeStyle = "black";
    context.lineWidth = 4;
    context.strokeRect(0, 0, rectWidth, rectHeight);

    context.restore();
  }
}