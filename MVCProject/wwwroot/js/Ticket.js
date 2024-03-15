var Quantity = document.getElementById("NumberOfTickets");
var Stock = document.getElementById("Stock");
var HiddenStock = document.getElementById("HiddenStock");
var Status = document.getElementById("Status");


function Add() {
    // Parse input values as integers
    var quantityValue = parseInt(Quantity.value);
    var stockValue = parseInt(Stock.textContent);

    // Check if input values are valid integers
    if (isNaN(quantityValue) || isNaN(stockValue)) {
        alert("Please enter valid numeric values for quantity and stock.");
        return;
    }

    // Check if the quantity is a positive integer
    if (quantityValue <= 0 || !Number.isInteger(quantityValue)) {
        alert("Please enter a valid positive integer for quantity.");
        return;
    }

    // Check if the quantity is greater than available stock
    if (quantityValue > stockValue) {
        alert("Can't book with this number. Not enough stock.");
        return;
    }

    // Calculate remaining stock and update UI
    var newStockValue = stockValue - quantityValue;
    Stock.textContent = newStockValue;
    HiddenStock.value = newStockValue;

    // Update status based on remaining stock
    if (newStockValue == 0) {
        Status.textContent = "not avalable";
    }
    console.log("Remaining stock: " + newStockValue);
    
}

window.onload =function() {
    var statusValue = document.getElementById("Status").innerText;
    var btn = document.getElementById("FormBtn");

    if (statusValue === "not avalable") {
        btn.disabled = true;
    } else {
        btn.disabled = false;
    }
}
