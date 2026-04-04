// Vehicle constructor
function Vehicle(speed, color) {
    // Private attributes
    let _speed = speed;
    let _color = color;

    // Define accessors with type checks
    Object.defineProperty(this, 'speed', {
        get: function() { return _speed; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Speed must be a number');
            _speed = value;
        },
        enumerable: true
    });

    Object.defineProperty(this, 'color', {
        get: function() { return _color; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Color must be a number');
            _color = value;
        },
        enumerable: true
    });
}

Vehicle.prototype.turnLeft = function() { console.log('Turning left'); };
Vehicle.prototype.turnRight = function() { console.log('Turning right'); };
Vehicle.prototype.start = function() { return true; };
Vehicle.prototype.stop = function() { return true; };
Vehicle.prototype.goBackward = function(speed, accel) {
    console.log('Going backward at ' + speed + ' with accel ' + accel);
};
Vehicle.prototype.goForward = function(speed, accel) {
    console.log('Going forward at ' + speed + ' with accel ' + accel);
};
Vehicle.prototype.toString = function() {
    return 'Vehicle (Speed: ' + this.speed + ', Color: ' + this.color + ')';
};
Vehicle.prototype.valueOf = function() {
    return this.speed;
};


// Bicycle constructor
function Bicycle(speed, color) {
    // Call parent constructor
    Vehicle.call(this, speed, color);
}

// Inherit from Vehicle
Bicycle.prototype = Object.create(Vehicle.prototype);
Bicycle.prototype.constructor = Bicycle;

Bicycle.prototype.ringBell = function() { console.log('Ring ring!'); };
Bicycle.prototype.toString = function() {
    return 'Bicycle (Speed: ' + this.speed + ', Color: ' + this.color + ')';
};


// MotorVehicle constructor
function MotorVehicle(speed, color, sizeOfEngine, licencePlate) {
    // Call parent constructor
    Vehicle.call(this, speed, color);

    let _sizeOfEngine = sizeOfEngine;
    let _licencePlate = licencePlate;

    Object.defineProperty(this, 'sizeOfEngine', {
        get: function() { return _sizeOfEngine; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Engine size must be a number');
            _sizeOfEngine = value;
        },
        enumerable: true
    });

    Object.defineProperty(this, 'licencePlate', {
        get: function() { return _licencePlate; },
        set: function(value) {
            if (typeof value !== 'string') throw new TypeError('Licence plate must be a string');
            _licencePlate = value;
        },
        enumerable: true
    });
}

// Inherit from Vehicle
MotorVehicle.prototype = Object.create(Vehicle.prototype);
MotorVehicle.prototype.constructor = MotorVehicle;

MotorVehicle.prototype.getSizeOfEngine = function() { return this.sizeOfEngine; };
MotorVehicle.prototype.getLicensePlate = function() { return this.licencePlate; };
MotorVehicle.prototype.toString = function() {
    return 'MotorVehicle (Speed: ' + this.speed + ', Color: ' + this.color +
           ', Engine: ' + this.sizeOfEngine + ', Plate: ' + this.licencePlate + ')';
};


// DumpTruck constructor
function DumpTruck(speed, color, sizeOfEngine, licencePlate, loadCapacity, numWheels, weight) {
    // Call parent constructor
    MotorVehicle.call(this, speed, color, sizeOfEngine, licencePlate);

    let _loadCapacity = loadCapacity;
    let _numWheels = numWheels;
    let _weight = weight;

    Object.defineProperty(this, 'loadCapacity', {
        get: function() { return _loadCapacity; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Load capacity must be a number');
            _loadCapacity = value;
        },
        enumerable: true
    });

    Object.defineProperty(this, 'numWheels', {
        get: function() { return _numWheels; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Num of wheels must be a number');
            _numWheels = value;
        },
        enumerable: true
    });

    Object.defineProperty(this, 'weight', {
        get: function() { return _weight; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Weight must be a number');
            _weight = value;
        },
        enumerable: true
    });
}

// Inherit from MotorVehicle
DumpTruck.prototype = Object.create(MotorVehicle.prototype);
DumpTruck.prototype.constructor = DumpTruck;

DumpTruck.prototype.lowerLoad = function() { console.log('Lowering load'); };
DumpTruck.prototype.raiseLoad = function() { console.log('Raising load'); };
DumpTruck.prototype.toString = function() {
    return 'DumpTruck (Load: ' + this.loadCapacity + ', Wheels: ' + this.numWheels + ', Weight: ' + this.weight + ')';
};

// Car constructor
function Car(speed, color, sizeOfEngine, licencePlate, numOfDoors, numWheels, weight) {
    // Call parent constructor
    MotorVehicle.call(this, speed, color, sizeOfEngine, licencePlate);

    let _numOfDoors = numOfDoors;
    let _numWheels = numWheels;
    let _weight = weight;

    Object.defineProperty(this, 'numOfDoors', {
        get: function() { return _numOfDoors; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Num of doors must be a number');
            _numOfDoors = value;
        },
        enumerable: true
    });

    Object.defineProperty(this, 'numWheels', {
        get: function() { return _numWheels; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Num of wheels must be a number');
            _numWheels = value;
        },
        enumerable: true
    });

    Object.defineProperty(this, 'weight', {
        get: function() { return _weight; },
        set: function(value) {
            if (typeof value !== 'number') throw new TypeError('Weight must be a number');
            _weight = value;
        },
        enumerable: true
    });
}

// Inherit from MotorVehicle
Car.prototype = Object.create(MotorVehicle.prototype);
Car.prototype.constructor = Car;

Car.prototype.switchOnAirCon = function() { console.log('AirCon switched on'); };
Car.prototype.getNumOfDoors = function() { return this.numOfDoors; };
Car.prototype.toString = function() {
    return 'Car (Doors: ' + this.numOfDoors + ', Wheels: ' + this.numWheels + ', Weight: ' + this.weight + ')';
};

// Example usage
let bike = new Bicycle(15, 3);
bike.ringBell();
console.log(bike.toString());
console.log(bike.valueOf());

let truck = new DumpTruck(60, 1, 5000, "ABC123", 2000, 6, 8000);
console.log(truck.toString());

let car = new Car(120, 2, 2000, "XYZ789", 4, 4, 1500);
car.switchOnAirCon();
console.log(car.toString());