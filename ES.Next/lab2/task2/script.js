function* fibonacciByCount(n) {
    let a = 0, b = 1;
    for (let i = 0; i < n; i++) {
        yield a;
        [a, b] = [b, a + b];
    }
}

console.log("Fibonacci Series By Count: ");
for (const num of fibonacciByCount(10)) {
    console.log(num);
}

function* fibonacciByMax(max) {
    let a = 0, b = 1;
    while (a <= max) {
        yield a;
        [a, b] = [b, a + b];
    }
}

console.log("\nFibonacci Series By Max: ");
for (const num of fibonacciByMax(20)) {
    console.log(num);
}
