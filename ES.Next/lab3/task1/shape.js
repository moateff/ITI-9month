import { getRandomColor } from "./helper.js";

class Polygon {
    constructor(name, color = getRandomColor()) {
        this.name = name;
        this.color = color;
    }

    area() { return 0; }
    toString() { return `${this.name}`; }

    // abstract method
    draw(context) { }
}

export class Rectangle extends Polygon {
    constructor(x = 0, y = 0, width, height) {
        super("Rectangle");
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    area() {
        return this.width * this.height;
    }

    toString() {
        return `Rectangle with width ${this.width} and height ${this.height} at (${this.x}, ${this.y})`;
    }

    draw(context) {
        context.beginPath();
        context.strokeStyle = this.color;
        context.fillStyle = this.color;
        context.rect(this.x, this.y, this.width, this.height);
        context.closePath();
        context.fill();
    }
}

export class Square extends Rectangle {
    constructor(x = 0, y = 0, size) {
        super(x, y, size, size);
        this.name = "Square";
    }

    toString() {
        return `Square with side length ${this.width} at (${this.x}, ${this.y})`;
    }
}

export class Triangle extends Polygon {
    constructor(x = 0, y = 0, base, height) {
        super("Triangle");
        this.x = x;
        this.y = y;
        this.base = base;
        this.height = height;
    }

    area() {
        return (this.base * this.height) / 2;
    }

    toString() {
        return `Triangle with base ${this.base} and height ${this.height} at (${this.x}, ${this.y})`;
    }

    draw(context) {
        context.beginPath();
        context.strokeStyle = this.color;
        context.fillStyle = this.color;
        context.moveTo(this.x, this.y);
        context.lineTo(this.x + this.base, this.y);
        context.lineTo(this.x + this.base / 2, this.y + this.height);
        context.closePath();
        context.fill();
    }
}

export class Circle extends Polygon {
    constructor(x = 0, y = 0, radius) {
        super("Circle");
        this.x = x;
        this.y = y;
        this.radius = radius;
    }

    area() {
        return Math.PI * this.radius * this.radius;
    }

    toString() {
        return `Circle with radius ${this.radius} at (${this.x}, ${this.y})`;
    }

    draw(context) {
        context.beginPath();
        context.strokeStyle = this.color;
        context.fillStyle = this.color;
        context.arc(this.x, this.y, this.radius, 0, 2 * Math.PI);
        context.closePath();
        context.fill();
    }
}

