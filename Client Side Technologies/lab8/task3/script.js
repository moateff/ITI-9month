function addNumbers() {
    // Check if no parameters were passed
    if (arguments.length === 0) {
        throw new Error("At least one number must be passed.");
    }

    let sum = 0;

    for (let i = 0; i < arguments.length; i++) {
        // Check if the argument is a number
        if (typeof arguments[i] !== "number") {
            throw new TypeError(`Argument at position ${i + 1} is not a number.`);
        }
        sum += arguments[i];
    }

    return sum;
}

// Example usage:
console.log(addNumbers(1, 2, 3));  // 6

try {
    console.log(addNumbers());         // Throws Error
} catch (err) {
    console.error(err.message);
}

try {
    console.log(addNumbers(1, "2", 3));  // Throws TypeError
} catch (err) {
    console.error(err.message);
}