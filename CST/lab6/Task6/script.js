const images = [
    "images/1.gif",
    "images/2.gif",
    "images/3.gif",
    "images/4.gif",
    "images/5.gif",
    "images/6.gif",
    "images/1.gif",
    "images/2.gif",
    "images/3.gif",
    "images/4.gif",
    "images/5.gif",
    "images/6.gif"
]
const moonImage = "images/moon.gif";

const board = document.querySelector(".game-board");

let firstCard = null;
let secondCard = null;
let lockBoard = false;
let matchedCount = 0;

function shuffle(array) {
  return array.sort(() => Math.random() - 0.5);
}
// console.log(shuffle(images));

function createBoard() {
    board.innerHTML = "";
    matchedCount = 0;
    shuffle(images);

    images.forEach(src => {
        const card = document.createElement("div");
        card.classList.add("card");

        const img = document.createElement("img");
        img.src = moonImage;
        img.dataset.image = src;

        card.appendChild(img);
        card.addEventListener("click", flipCard);

        board.appendChild(card);

        /*
        <div class="game-board">
            <div class="card">
                <img src="images/moon.gif" data-image="images/1.gif">
            </div>
            ...
        </div>
        */
    });
}

function flipCard() {
    console.log("click");

    if (lockBoard) return;
    if (this === firstCard) return;
    if (this.classList.contains("matched")) return;

    const img = this.querySelector("img");
    img.src = img.dataset.image;

    if (!firstCard) {
        firstCard = this;
        return;
    }

    secondCard = this;
    checkMatch();
}

function checkMatch() {
    const img1 = firstCard.querySelector("img").dataset.image;
    const img2 = secondCard.querySelector("img").dataset.image;

    img1 === img2 ? disableCards() : unflipCards();
}

function disableCards() {
    firstCard.classList.add("matched");
    secondCard.classList.add("matched");
    matchedCount += 2;
    resetTurn();

    if (matchedCount === images.length) {
        setTimeout(() => {
            alert("Congratulations! You won!");
        }, 500);

        setTimeout(createBoard, 1200);
    }
}

function unflipCards() {
    lockBoard = true;
    setTimeout(() => {
        firstCard.querySelector("img").src = moonImage;
        secondCard.querySelector("img").src = moonImage;
        resetTurn();
    }, 1000);
}

function resetTurn() {
    firstCard = null;
    secondCard = null;
    lockBoard = false;
}


createBoard();