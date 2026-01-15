let childWindow = null;
let message = "Hello from the parent window!";
let index = 0;
let writeInterval = null;

document.querySelector("button").addEventListener("click", () => {
    if(childWindow && !childWindow.closed) {
        alert("child window is already opened");
        return
    } 
    
    childWindow = window.open(
        "child.html", 
        "FlyingChild", 
        "width=300, height=200"
    );

    childWindow.focus();
    
    childWindow.onload = () => {
        const p = childWindow.document.querySelector("p");
        if (!p) return;

        index = 0;
        writeInterval = setInterval(() => {
            if (!childWindow || childWindow.closed) {
                clearInterval(writeInterval);
                writeInterval = null;
                return;
            }

            if (index === message.length) {
                setTimeout(() => {
                    childWindow.close();
                }, 500); 
            } else {
                p.textContent += message[index++];
            }
        }, 100);
    };
})