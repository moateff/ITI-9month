// const myObj = {
//     name: "JavaScript",
//     version: "ES6",
//     year: 2015,

//     [Symbol.iterator]() {
//         // create a generator instance
//         const gen = (function* () {
//             for (const [key, value] of Object.entries(myObj)) {
//                 yield `${key}: ${value}`;
//             }
//         })();

//         // return an object with a next() method
//         return {
//             next() {
//                 return gen.next();
//             }
//         };
//     }
// }

const myObj = {
    name: "JavaScript",
    version: "ES6",
    year: 2015,

    *[Symbol.iterator]() { // generator function
        for (const [key, value] of Object.entries(this)) {
            yield `${key}: ${value}`;
        }
    }
}

// const myObj = {
//     name: "JavaScript",
//     version: "ES6",
//     year: 2015,

//     [Symbol.iterator]: function () {
//         const entries = Object.entries(this); // array of [key, value] pairs
//         let index = 0;

//         return { // iterator object
//             next: () => {
//                 if (index < entries.length) {
//                     const [key, value] = entries[index++];
                    
//                     return { 
//                         value: `${key}: ${value}`,
//                         done: false 
//                     };
//                 }

//                 return { done: true };
//             }
//         }
//     }
// }

for (const item of myObj) {
    console.log(item);
}