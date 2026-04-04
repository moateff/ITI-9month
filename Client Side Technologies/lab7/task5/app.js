const screen = document.getElementById("screen");

let num1 = null;
let num2 = null;
let operator = null;
let result = null;

let tempNum = null;
let tempResult = null;

function calc(operator, num1, num2) {
    switch (operator) {
        case "+":
            return num1 + num2;
        case "-":
            return num1 - num2;
        case "*":
            return num1 * num2;
        case "/":
            if (num2 === 0) 
                return null;
            return num1 / num2;
        default:
            return null;
    }
}

function resetTemp() {
    tempNum = null;
    // tempResult = null;
}

function resetState() {
    num1 = null;
    num2 = null;
    operator = null;
    result = null;
}

function EnterNumber(value) {
    if (screen.value.length >= 18) return;
    
    if (value === ".") {
        if (tempNum === null) value = "0.";
        else if (tempNum.includes(".")) return;
    }

    if (tempNum === null) tempNum = value;
    else tempNum += value;
    
    if (operator) num2 = tempNum;
    else num1 = tempNum;

    renderScreen(tempNum);
};

function EnterOperator(op) {
    if (num2) return;
    if (num1 === null) {
        if (tempResult === null) return;
        else num1 = tempResult;
    }

    operator = op; 
    renderScreen(op);

    resetTemp();
};

function EnterEqual() {
    if (num1 === null) return;
    if (operator === null) return;
    if (num2 === null) return;
    
    showResult();
    resetTemp();
};

function EnterClear() {
    clearScrean();
    resetState();
};

function clearScrean() {
    screen.value = "";
}

function renderScreen(val) {
    screen.value = val;
    console.log(num1, operator, num2, " = ", result);
}

function emptyScreen() {
    return screen.value === "";
}

function showResult() {
    result = calc(operator, Number(num1), Number(num2));

    if (result === null) renderScreen("Error");
    else renderScreen(result);

    tempResult = result;
    resetState();
}

window.onload = () => {
    clearScrean();
    renderScreen("0");
    tempResult = 0;
}

document.addEventListener("keydown", (event) => {
    const key = event.key;

    if (!isNaN(key) || key === ".") {
        EnterNumber(key);
    } else if (key === "+" || key === "-" || key === "*" || key === "/") {
        EnterOperator(key);
    } else if (key === "Enter" || key === "=") {
        EnterEqual();
    } else if (key === "Escape") {
        EnterClear();
    }
});

screen.addEventListener("focus", () => {
    screen.blur();
});