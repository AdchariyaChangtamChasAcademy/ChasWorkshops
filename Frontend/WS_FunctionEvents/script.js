// Traditional Function
function calculateSum(a, b){
    return a+b;
}
console.log('Sum: ', calculateSum(5, 3))

// Arrow Function
const calculateProduct = (a,b) => a*b;
console.log('Product: ', calculateProduct(5, 3))

// Function with object
const greetPerson = (person) => {
    return `Hello ${person.name}, you are ${person.age} years old!`
};

const student = {
    name: 'Alice',
    age: 11
};

console.log(greetPerson(student));

// Function with default value
const greet = (name = 'Guest') => `Welcome ${name}`

console.log(greet('Bob'));
console.log(greet());

// Event
const box = document.getElementById('myBox');
const info = document.getElementById('info');

// Click Event
box.addEventListener('click', () => {
    box.style.backgroundColor = 'red';
    info.textContent = 'You clicked on the box';
});

// Mouse Enter Event
box.addEventListener('mouseenter', () => {
    box.style.transform = 'scale(1.1)';
    info.textContent = 'Mouse entered box';
})

// Mouse Leave Event
box.addEventListener('mouseleave', () => {
    box.style.transform = 'scale(1.0)';
    info.textContent = 'Mouse left box';
})

// Key Events
const textInput = document.getElementById('textInput');
const keyInfo = document.getElementById('keyInfo');

// Key Down Event
textInput.addEventListener('keydown', (event) =>{
    keyInfo.textContent = `You pressed the key: ${event.key} {Code: ${event.code}}`
});

// Key Up Event
textInput.addEventListener('keyup', (event) =>{
    if(event.key === 'Enter'){
        alert(`You wrote: ${textInput.value}`)
    }
});

// Listen
document.addEventListener('keydown', (event) =>{
    if(event.key === 'Escape'){
        console.log('ESC-key pressed')
        textInput.value = '';
    }
})