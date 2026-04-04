const canvas = document.querySelector(".canvas");
const context = canvas.getContext("2d");

const canvasWidth = canvas.width;
const canvasHeight = canvas.height;

const step = 10;

let x = 0;
let y = 0;

(function() {
    const interval = setInterval(() => {
        console.log(x, y);
        if (x >= canvasWidth || y >= canvasHeight) {
            clearInterval(interval); 
            
            alert("animation ended");
            return;
        }

        context.beginPath();
        context.moveTo(x, y);

        x += step;
        y += step;
        
        context.lineTo(x, y);
        context.strokeStyle = "red";
        context.lineWidth = 4;

        context.stroke();
    }, 500);
})();