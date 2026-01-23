// Shape Constructor (Abstract)
function Shape() {
    if(this.constructor === Shape) {
        throw new Error("Cannot create an instance of abstract class Shape");
    }
}

// Rectangle Constructor
function Rectangle(width, height) {
    this._width = width;
    this._height = height;
}

// Inherit from Shape
Rectangle.prototype = Object.create(Shape.prototype);
Rectangle.prototype.constructor = Rectangle;

// Define properties using accessors
Object.defineProperties(Rectangle.prototype, {
    width: {
        get() { return this._width; },
        set(value) { this._width = value; },
        enumerable: true
    },
    height: {
        get() { return this._height; },
        set(value) { this._height = value; },
        enumerable: true
    },
    area: {
        get() { return this._width * this._height; },
        enumerable: true
    },
    perimeter: {
        get() { return 2 * (this._width + this._height); },
        enumerable: true
    }
});

// Methods
Rectangle.prototype.toString = function() {
    return `Rectangle - Width: ${this.width}, Height: ${this.height}, Area: ${this.area}, Perimeter: ${this.perimeter}`;
};

Rectangle.prototype.valueOf = function() {
    return this.area;
};

// Square Constructor
function Square(side) {
    // Singleton pattern
    if (Square._instance) {
        throw new Error("Square is a singleton");
    }

    // or check Square count
    // if (Square.count) {
    //     return Square._instance;
    // }

    // Call Rectangle constructor
    Rectangle.call(this, side, side);

    // Increase square count
    Square.count = (Square.count || 0) + 1;

    Square._instance = this;
}

// Inherit from Rectangle
Square.prototype = Object.create(Rectangle.prototype);
Square.prototype.constructor = Square;

// Override toString for Square
Square.prototype.toString = function() {
    return `Square - Side: ${this.width}, Area: ${this.area}, Perimeter: ${this.perimeter}`;
};


// Testing
try {
    const shape1 = new Shape(); 
} catch (e) {
    console.log(e.message);
}
// Cannot create an instance of abstract class Shape

const rect1 = new Rectangle(5, 12);
const rect2 = new Rectangle(3, 7);

console.log(rect1.toString());
console.log(`Sum of rectangles: ${rect1 + rect2}`); // 60 + 21 = 81
console.log(`Difference of rectangles: ${rect1 - rect2}`); // 60 - 21 = 39

const square1 = new Square(8);
try {
    const square3 = new Square(5); 
} catch (e) {
    console.log(e.message);
}
// Square is a singleton

console.log(square1.toString());
console.log(`Number of squares created: ${Square.count}`); // 1
console.log(`Sum of square and rectangle areas: ${square1 + rect1}`); // 64 + 60 = 124