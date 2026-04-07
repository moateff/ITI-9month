const input = document.getElementById('input');
const button = document.getElementById('button');
const result = document.getElementById('result');

async function fetchData(query = "") {
    try {
        const url = query 
            ? `https://dummyjson.com/products/${query}`
            : `https://dummyjson.com/products`;

        const response = await fetch(url);

        if (!response.ok) throw new Error("Failed to fetch");

        return await response.json();
    } catch (error) {
        console.error(error);
        return null;
    }
}

function createCell(tag, text) {
    const cell = document.createElement(tag);
    cell.textContent = text;
    return cell;
}

function renderData(data) {
    result.innerHTML = "";

    if (!data) {
        alert("Error loading data");
        return;
    }

    const table = document.createElement("table");

    // Header
    const headerRow = document.createElement("tr");
    ["Id", "Title", "Description"].forEach(text => {
        headerRow.appendChild(createCell("th", text));
    });
    table.appendChild(headerRow);

    // Normalize data 
    const products = data.products || [data];

    products.forEach(product => {
        const row = document.createElement("tr");

        row.appendChild(createCell("td", product.id));
        row.appendChild(createCell("td", product.title));
        row.appendChild(createCell("td", product.description));

        table.appendChild(row);
    });

    result.appendChild(table);
}

function getInput() {
    return input.value.trim();
}

function clearInput() {
    input.value = "";
}

button.addEventListener('click', async () => {
    const value = getInput();

    let data;

    if (value === "*") {
        data = await fetchData(); // all products
    } else if (!isNaN(value) && value !== "") {
        data = await fetchData(value); // single product
    } else {
        alert("Invalid input");
        clearInput();
        return;
    }

    renderData(data);
});

clearInput();