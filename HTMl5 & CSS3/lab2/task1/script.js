const form = document.querySelector(".form");
const nameInput = document.querySelector(".name-input");
const output = document.querySelector(".output");

// Load saved value
const savedName = myLocalStorage.getItem("name");
if (savedName) {
    output.textContent = `Saved name: ${savedName}`;
}

// Handle submit
form.addEventListener("submit", (e) => {
    e.preventDefault(); 

    const name = nameInput.value.trim();
    if (!name) return;

    myLocalStorage.setItem("name", name);
    output.textContent = `Saved name: ${name}`;

    nameInput.value = "";
});