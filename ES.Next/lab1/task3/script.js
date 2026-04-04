var fruits = ["apple", "strawberry", "banana", "orange", "mango"];


// Check if all elements are strings
const allStrings = fruits.every(item => typeof item === "string");
console.log("All elements are strings:", allStrings);


// Check if any element starts with 'a'
const hasA = fruits.some(item => item.startsWith("a"));
console.log("Some elements start with 'a':", hasA);


// Filter elements that start with 'b' or 's'
const filteredFruits = fruits.filter(item => item.startsWith("b") || item.startsWith("s"));
console.log("Filtered fruits:", filteredFruits);


// Map each element to "I like {element}"
const likedFruits = fruits.map(item => `I like ${item}`);
console.log(likedFruits);


// Print each element using forEach
likedFruits.forEach(item => console.log(item));
