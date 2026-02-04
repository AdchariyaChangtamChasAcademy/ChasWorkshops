// Variables 
const name = "Anna";
const age = 25;
const isStudent = true;

console.log("Name:", name);
console.log("Age:", age);
console.log("Student:", isStudent);

// Arrays
const fruits = ["Apple", "Banana", "Orange"]
console.log("First fruit:", fruits[0]);
console.log("Quantity of fruit:", fruits.length);

// Object
const person = {
    name: "Anna",
    age: 45,
    city: "Stockholm"
};

console.log("Person:", person);

// If
const temperature = 22;

if(temperature > 25){
    console.log("It is warm!");
} else if(temperature > 15){
    console.log("It is pleasant!");
} else {
    aconsole.log("It is cold!");
}

// Switch
const day = "Monday";

switch (day){
    case "Monday":
        console.log("New week!");
        break;
    case "Friday":
        console.log("Weekend soon!");
        break;
    default:
        console.log("Regular day");
}

// For-loop
for (let i=0;i<5;i++){
    console.log("Counter:", i);
}

// For...of
const colours = ["Red", "Green", "Blue"]
for(let colour of colours){
    console.log("Colour:", colour);
}

// While-loop
let count = 0;
while(count < 3){
    console.log("Count:", count);
    count++;
}