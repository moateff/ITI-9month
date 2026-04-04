const LinkedList = {
    data: [],

    // helpers
    _validate(value) {
        if (typeof value !== "number" || Number.isNaN(value)) {
            throw new Error("Value must be numeric");
        }
    },

    _exists(value) {
        return this.data.some(item => item.val === value);
    },    
    // end helpers

    isEmpty() {
        return this.data.length === 0;
    },

    enqueue(value) {
        this._validate(value);

        if (this._exists(value)) {
            throw new Error("Duplicate value not allowed");
        }

        if (!this.isEmpty() && value >= this.data[0].val) {
            throw new Error("Value breaks ascending sequence");
        }

        this.data.unshift({ val: value });
    },

    push(value) {
        this._validate(value);

        if (this._exists(value)) {
            throw new Error("Duplicate value not allowed");
        }

        if (!this.isEmpty() && value <= this.data[this.data.length - 1].val) {
            throw new Error("Value breaks ascending sequence");
        }

        this.data.push({ val: value });
    },

    insertAt(index, value) {
        this._validate(value);

        if (this._exists(value)) {
            throw new Error("Duplicate value not allowed");
        }

        if (index < 0 || index > this.data.length) {
            throw new Error("Invalid index");
        }

        const prev = this.data[index - 1];
        const next = this.data[index];

        if (
            (prev && value <= prev.val) ||
            (next && value >= next.val)
        ) {
            throw new Error("Value breaks ascending sequence");
        }

        this.data.splice(index, 0, { val: value });
    },

    pop() {
        if (this.isEmpty()) return null;
        return this.data.pop();
    },

    remove(value) {
        const index = this.data.findIndex(item => item.val === value);
        if (index === -1) {
            return "data not found";
        }
        this.data.splice(index, 1);
    },

    dequeue() {
        if (this.isEmpty()) return null;
        return this.data.shift();
    },

    display() {
        console.log(this.data.map(item => item.val));
    }
};

function main() {
    let choice;

    do {
        choice = prompt(
            `Choose an operation:
1 - Enqueue (add at beginning)
2 - Push (add at end)
3 - Insert at index
4 - Pop (remove from end)
5 - Dequeue (remove from beginning)
6 - Remove value
7 - Display list
0 - Exit`
        );

        try {
            switch (choice) {
                case "1": {
                    const value = Number(prompt("Enter value to enqueue:"));
                    LinkedList.enqueue(value);
                    alert("Value enqueued successfully");
                    break;
                }

                case "2": {
                    const value = Number(prompt("Enter value to push:"));
                    LinkedList.push(value);
                    alert("Value pushed successfully");
                    break;
                }

                case "3": {
                    const index = Number(prompt("Enter index:"));
                    const value = Number(prompt("Enter value:"));
                    LinkedList.insertAt(index, value);
                    alert("Value inserted successfully");
                    break;
                }

                case "4": {
                    const removed = LinkedList.pop();
                    alert(removed ? `Removed: ${removed.val}` : "List is empty");
                    break;
                }

                case "5": {
                    const removed = LinkedList.dequeue();
                    alert(removed ? `Removed: ${removed.val}` : "List is empty");
                    break;
                }

                case "6": {
                    const value = Number(prompt("Enter value to remove:"));
                    const result = LinkedList.remove(value);
                    alert(result || "Value removed successfully");
                    break;
                }

                case "7": {
                    LinkedList.display();
                    alert("Check console for list output");
                    break;
                }

                case "0":
                    alert("Program exited");
                    break;

                default:
                    alert("Invalid choice");
            }
        } catch (error) {
            alert(error.message);
        }

    } while (choice !== "0");
}
