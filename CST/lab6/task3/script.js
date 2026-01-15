window.onload = () => {
    let params = parseQueryString();
    injectData(params);
    checkBrowser();
};

parseQueryString = () => {
    return params = Object.fromEntries(
        new URLSearchParams(location.search)
    );
};

injectData = (params) => {
    document.querySelector("#name").textContent = params.name;
    document.querySelector("#address").textContent = params.address;
    document.querySelector("#gender").textContent = params.gender;
    document.querySelector("#email").textContent = params.email;
    document.querySelector("#mobile").textContent = params.mobile;
};

checkBrowser = () => {
    if (!window.navigator.userAgent.includes("Chrome")) {
        setTimeout(() => { alert("Please use Google Chrome!") }, 500);
    }
};

// const params = {};
// location.href
//     .split("?")[1]
//     .replaceAll("+", " ")
//     .split("&")
//     .forEach(item => {
//         const [key, value] = item.split("=");
//         params[key] = decodeURIComponent(value);
//     });
// console.log(params);