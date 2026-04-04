export function drawShapes(shapes, context) {
    for (const shape of shapes) {
        shape.draw(context);
    }
}

export function printShapes(shapes) {
    for (const shape of shapes) {
        console.log(shape.toString());
    }
}

export function getRandomColor() {
    const r = Math.floor(Math.random() * 256);
    const g = Math.floor(Math.random() * 256);
    const b = Math.floor(Math.random() * 256);
    return `rgb(${r}, ${g}, ${b})`;
}
