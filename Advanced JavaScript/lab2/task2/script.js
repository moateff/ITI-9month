function Book(title, numOfChapters, author, numOfPages, publisher, numOfCopies) {
    return {
        title: title,
        numOfChapters: numOfChapters,
        author: author,
        numOfPages: numOfPages,
        publisher: publisher,
        numOfCopies: numOfCopies,

        toString: function () {
            return this.title + " by " + this.author;
        },

        copy: function () {
            return Book(
                this.title, 
                this.numOfChapters, 
                this.author, 
                this.numOfPages, 
                this.publisher, 
                this.numOfCopies
            );
        }
    };
}

function Box(height, width, length, material) {

    // private
    var content = [];
    var numOfBooks = 0;

    return {
        height: height,
        width: width,
        length: length,
        material: material,

        get numOfBooks() {
            return numOfBooks;
        },

        get volume() {
            return height * width * length;
        },

        get content() {
            return content.slice(); 
        },

        // add book
        addBook: function (book) {
            for (var i = 0; i < content.length; i++) {
                if (content[i].title === book.title) {
                    content[i].numOfCopies += book.numOfCopies;
                    numOfBooks += book.numOfCopies;
                    return;
                }
            }

            // first time this book title appears
            var bookCopy = book.copy();
            content.push(bookCopy);
            numOfBooks += book.numOfCopies;
        },


        // delete book by title
        deleteBook: function (title) {
            for (var i = 0; i < content.length; i++) {
                if (content[i].title === title) {

                    // remove one physical copy
                    content[i].numOfCopies--;
                    numOfBooks--;

                    // if no copies left, remove the book entry
                    if (content[i].numOfCopies === 0) {
                        content.splice(i, 1);
                    }

                    return true;
                }
            }
            return false;
        },

        // override toString
        toString: function () {
            var bookTitles = content.map(function (b) {
                return b.title + " (Copies: " + b.numOfCopies + ")";
            }).join(", ");

            return "Box (" +
                "H=" + height +
                ", W=" + width +
                ", L=" + length +
                ", Volume=" + this.volume +
                ", Books=[" + bookTitles + "]" +
                ")";
        },

        // override valueOf
        valueOf: function () {
            return numOfBooks;
        }
    };
}

// Create Books
var book1 = Book("JavaScript Basics", 12, "Alice", 250, "TechPress", 2);
var book2 = Book("Advanced JS", 15, "Bob", 400, "CodeHouse", 1);
var book3 = Book("HTML & CSS", 8, "Carol", 200, "WebPub", 3);

// Create Boxes
var box1 = Box(10, 5, 4, "Wood");
var box2 = Box(8, 4, 3, "Plastic");

// Add Books to Box1
box1.addBook(book1); // adds 2 copies
box1.addBook(book2); // adds 1 copy
box1.addBook(book1); // adds 2 more copies (book1 already exists)

// Test Box1
console.log("Box1 numOfBooks:", box1.numOfBooks); 
// Expected: 5 (2 + 1 + 2)

console.log("Box1 details:", box1.toString());
// Expected: Box (H=10, W=5, L=4, Volume=200, Books=[JavaScript Basics, Advanced JS])

// Delete Copies
box1.deleteBook("JavaScript Basics"); 
console.log("Box1 after deleting 1 JS copy:", box1.toString());
// JS copies reduced by 1

box1.deleteBook("Advanced JS"); 
console.log("Box1 after deleting Advanced JS:", box1.toString());
// Advanced JS removed

// Add Books to Box2
box2.addBook(book3); // adds 3 copies
box2.addBook(book1); // adds 2 copies

console.log("Box2 numOfBooks:", box2.numOfBooks); 
// Expected: 5 (3 + 2)

console.log("Box2 details:", box2.toString());
// Expected: Box (H=8, W=4, L=3, Volume=96, Books=[HTML & CSS, JavaScript Basics])

// Test valueOf (adding boxes)
console.log("Total books in box1 + box2:", box1 + box2);
// Expected: box1.numOfBooks + box2.numOfBooks = total physical books
