const product = {
    name : "ProductName",
    price : 100,
    inStock : true,
    categories : ["Category1", "Category2"],
    supplier : {
        name : "Supplier1",
        email : "supplier1@email.com",
        phone: "070-1234567"
    }
}

const saveProduct = (product) => {
    const json = JSON.stringify(product);
    localStorage.setItem("Product", json);
}

const loadProduct = () => {
    const json = localStorage.getItem(product);
    if(!json) return null;
    return JSON.parse(json);
}

const displayProduct = (product) => {
    const display = document.getElementById("productDisplay");

    
}