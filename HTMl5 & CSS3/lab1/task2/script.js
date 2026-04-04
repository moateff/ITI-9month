const text = document.querySelector(".text");
const redRange = document.querySelector(".red-range");
const greenRange = document.querySelector(".green-range");
const blueRange = document.querySelector(".blue-range");

// Single function to update color
function updateColor() {
    const r = redRange.value;
    const g = greenRange.value;
    const b = blueRange.value;

    text.style.color = `rgb(${r}, ${g}, ${b})`;
}

// Attach same handler to all sliders
redRange.addEventListener("input", updateColor);
greenRange.addEventListener("input", updateColor);
blueRange.addEventListener("input", updateColor);

// Initial color
updateColor();