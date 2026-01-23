function NumericSequence(start, end, step) {
    if (end < start) {
        throw new Error("End must be greater than or equal to start");
    }

    if (step <= 0) {
        throw new Error("Step must be a positive number");
    }

    // private list
    var list = [];

    // private method
    (function fillList() {
        for (var i = start; i <= end; i += step) {
            list.push(i);
        }
    })();

    // fillList();

    // public methods
    this.getList = function () {
        return list.slice(); 
    };

    this.append = function (value) {
        var last = list[list.length - 1];
        if (value !== last + step) {
            throw new Error("Value is not sequential");
        }

        list.push(value);
    };

    this.prepend = function (value) {
        var first = list[0];
        if (value !== first - step) {
            throw new Error("Value is not sequential");
        }

        list.unshift(value);
    };

    this.dequeue = function () {
        if (list.length === 0) return null;
        return list.shift();
    };

    this.pop = function () {
        if (list.length === 0) return null;
        return list.pop();
    };

    // override toString
    this.toString = function () {
        return list.join(" -> ");
    };
}

var seq = new NumericSequence(2, 10, 2);

console.log(seq.toString());
// 2 -> 4 -> 6 -> 8 -> 10

seq.append(12);
seq.prepend(0);

console.log(seq.toString());
// 0 -> 2 -> 4 -> 6 -> 8 -> 10 -> 12

seq.pop();
seq.dequeue();

console.log(seq.toString());
// 2 -> 4 -> 6 -> 8 -> 10

try {
    seq.append(15);
} catch (e) {
    console.log(e.message);
}
// Error: Value is not sequential

try {
    seq.append(1);
} catch (e) {
    console.log(e.message);
}
// Error: Value is not sequential
