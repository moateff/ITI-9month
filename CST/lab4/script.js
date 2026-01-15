let str = prompt("Enter a string: ");

let ch;
while(true) {
    ch = prompt("Enter a character: ");

    if (ch.length !== 1) {
        alert("Please enter a single character.");
        continue;
    }
    break;
}

let isCaseSensitive = confirm("Should the search be case-sensitive?");

const flags = isCaseSensitive ? "g" : "gi";
const regex = new RegExp(ch, flags);

const matches = str.match(regex);
const count = matches ? matches.length : 0;

alert("Number of occurrences: " + count);



let str = prompt("Enter a string: ");
let isCaseSensitive = confirm("Should the check be case-sensitive?");
let isPalindrome = true;

str = isCaseSensitive ? str : str.toLowerCase();

for(let i = 0; i < ((str.length + 1) / 2); i++) {
    if (str[i] !== str[str.length - 1 - i]) {
        isPalindrome = false;
        break;
    }
}

alert("Your string is " + (isPalindrome ? "a palindrome" : "not a palindrome"));



let str = prompt("Enter a string: ");
let words = str.split(" ");

let maxIndex = 0;
let maxLength = words[0].length;
for(let i = 1; i < words.length; i++) {
    if (words[i].length > maxLength) {
        maxIndex = i;
        maxLength = words[i].length;
    }
}

alert("The longthest substring is " + "\"" +  words[maxIndex] + "\"");



// Name validation: only letters
let name = prompt("Enter your name (letters only):");
while (!/^[A-Za-z]+$/.test(name)) {
    name = prompt("Invalid name. Please enter letters only:");
}

// Phone number validation: 8 digits
let phone = prompt("Enter your phone number (8 digits):");
while (!/^\d{8}$/.test(phone)) {
    phone = prompt("Invalid phone number. Enter exactly 8 digits:");
}

// Mobile number validation: 11 digits, starts with 010, 011, 012
let mobile = prompt("Enter your mobile number (11 digits, starts with 010, 011, 012):");
while (!/^(010|011|012)\d{8}$/.test(mobile)) {
    mobile = prompt("Invalid mobile number. Try again:");
}

// Email validation
let email = prompt("Enter your email:");
while (!/^[a-zA-Z]+@[a-zA-Z0-9]+\.[a-z]{2,}$/.test(email)) {
    email = prompt("Invalid email. Please enter a valid email:");
}

// Color choice
let color = prompt("Choose a color for your message: red, green, or blue").toLowerCase();
while (!["red", "green", "blue"].includes(color)) {
    color = prompt("Invalid color. Choose red, green, or blue:").toLowerCase();
}

// Display the welcoming message
let today = new Date().toLocaleDateString();

console.log(
    "%cWelcome, " + name + "!\n" +
    "Your phone number: " + phone + "\n" +
    "Your mobile number: " + mobile + "\n" +
    "Your email: " + email + "\n" +
    "Today's date: " + today,
    "color: " + color + "; font-size: 16px;"
);



