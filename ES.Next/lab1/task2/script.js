function getMinMax(...arr) {
    // let min = Number.MAX_VALUE;
    // let max = Number.MIN_VALUE;

    // for (let i = 0; i < arr.length; i++) {
    //     if (arr[i] < min) min = arr[i];
    //     if (arr[i] > max) max = arr[i];
    // } 

    const min = Math.min(...arr);
    const max = Math.max(...arr);

    return { min, max };
}

// Call with any number of values
// const result = getMinMax(10, 5, 30, -2, 8, 100);

let arr = [10, 5, 30, -2, 8, 100];
const result = getMinMax(...arr);

console.log("Min: ", result.min);
console.log("Max: ", result.max);