function twoParamsOnly(a, b) {
    // Check the number of arguments
    if (arguments.length !== 2) {
        throw new Error("This function requires exactly 2 parameters.");
    }

    return a + b;
}

// Testing the function
console.log(twoParamsOnly(5, 10)); // Works fine, outputs 15

try {
    console.log(twoParamsOnly(5));     // Throws Error
} catch (error) {
    console.error(error.message);
}
// This function requires exactly 2 parameters.

try {
    console.log(twoParamsOnly(1, 2, 3)); // Throws Error
} catch (error) {
    console.error(error.message);
}
// This function requires exactly 2 parameters.

