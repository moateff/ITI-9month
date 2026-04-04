// Target object
const person = {};

// Proxy handler
const handler = {
    set(target, prop, value) {
        switch (prop) {
            case "name":
                if (typeof value !== "string") {
                    throw new Error("Name must be a string");
                }
                if (!value.match(/^[a-zA-Z]{7}$/)) {
                    throw new Error("Name must be at least 7 characters long");
                }
                break;

            case "address":
                if (typeof value !== "string") {
                    throw new Error("Address must be a string");
                }
                break;

            case "age":
                if (typeof value !== "number") {
                    throw new Error("Age must be a number");
                }
                if (value < 25 || value > 60) {
                    throw new Error("Age must be between 25 and 60");
                }
                break;

            default:
                throw new Error(`Property ${prop} is not allowed`);
                break;
        }

        target[prop] = value;
        return true;
    }
};

// Create the proxy
const proxyPerson = new Proxy(person, handler);

try {
    proxyPerson.name = "Mohamed"; 
    proxyPerson.age = 35;
    proxyPerson.address = "Alexandria";

    console.log(proxyPerson);
} catch (err) {
    console.error(err.message);
}

try {
    proxyPerson.name = "Ahmed";
} catch (error) {
    console.error(error.message);
}

try {
    proxyPerson.age = 20;
} catch (error) {
    console.error(error.message);
}

try {
    proxyPerson.address = 123;
} catch (error) {
    console.error(error.message);
}
