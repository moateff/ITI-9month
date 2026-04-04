const truncate = {
    [Symbol.replace]: function (str) {
        if (str.length > 15) {
            return str.slice(0, 15) + "...";
        }
        return str;
    }
}

const str = "Hello World from JavaScript";
console.log(str.replace(truncate));
