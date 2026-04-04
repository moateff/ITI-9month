import * as shape from "./shape.js";
import * as helper from "./helper.js";

const canvas = document.getElementById("canvas");
const context = canvas.getContext("2d");

const shapes = [
    new shape.Circle(60, 80, 25),
    new shape.Rectangle(120, 40, 90, 60),
    new shape.Triangle(250, 100, 70, 50),
    new shape.Square(380, 30, 65),

    new shape.Circle(90, 200, 40),
    new shape.Rectangle(200, 180, 110, 70),
    new shape.Triangle(340, 220, 80, 60),
    new shape.Square(30, 260, 75),

    new shape.Circle(150, 320, 35),
    new shape.Rectangle(260, 300, 95, 80),
    new shape.Triangle(400, 350, 60, 55),
    new shape.Square(70, 380, 85),

    new shape.Circle(300, 80, 30),
    new shape.Rectangle(50, 120, 70, 100),
    new shape.Triangle(180, 420, 90, 70),
    new shape.Square(420, 200, 60),

    new shape.Circle(420, 420, 45),
    new shape.Rectangle(220, 400, 100, 50),
    new shape.Triangle(100, 450, 75, 45),
    new shape.Square(320, 150, 70)
];

helper.drawShapes(shapes, context);
helper.printShapes(shapes);

