var obj = {
    id: "SD-10",
    location: "SV",
    addr: "123 st.",

    getSetGen: function () {
        var obj = this;

        for (var prop in obj) {
            // skip functions
            if (typeof obj[prop] === "function") continue;

            // Capitalize first letter
            var cap = prop.charAt(0).toUpperCase() + prop.slice(1);

            // Create getter if not exists
            if (typeof obj["get" + cap] !== "function") {
                obj["get" + cap] = (function(p) {
                    return function () {
                        return this[p];
                    };
                })(prop);
            }

            // Create setter if not exists
            if (typeof obj["set" + cap] !== "function") {
                obj["set" + cap] = (function(p) {
                    return function (value) {
                        this[p] = value;
                    };
                })(prop);
            }
        }
    }
};

obj.getSetGen();
console.log(obj);

// Example usage on another object
var user = { 
    name: "Ali", 
    age: 10 
};

// Apply getSetGen from obj to user
obj.getSetGen.call(user);
console.log(user);

// Now user has dynamically generated getters and setters
console.log(user.getName()); // Ali
console.log(user.getAge());  // 10

user.setName("Ahmed");
user.setAge(20);

console.log(user.getName()); // Ahmed
console.log(user.getAge());  // 20
