
let action = "home.html";
let form = document.querySelector(".form");
let register = form.querySelector('input[name="register"]');

register.addEventListener("click", function () {

    let name = form.querySelector('input[name="name"]').value;
    let age = form.querySelector('input[name="age"]').value;
    let gender = form.querySelector('input[name="gender"]:checked')?.value;
    let color = form.querySelector('select[name="color"]').value;

    if (!name || !age || !gender) {
        alert("Please fill all required fields");
        return;
    }

    setCookie("name", name);
    setCookie("age", age);
    setCookie("gender", gender);
    setCookie("color", color);

    window.location.href = action;
});
