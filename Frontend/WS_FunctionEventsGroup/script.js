const add = (a,b) => a+b;
const substract = (a,b) => a-b;
const multiply = (a,b) => a*b;
const divide = (a,b) => a/b;
const isEven = (num) => num%2 === 0;
const findMax = (arr) => Math.max(...arr);

const calculate = (operation, a, b) =>
    operation === '+' ? a+b :
    operation === '-' ? a-b :
    operation === '*' ? a*b :
    operation === '/' ? a/b :
    'Invalid operator';

// Event
const box = document.getElementById('box');
const infoText = document.getElementById('info');
const redBtn = document.getElementById('redBtn');
const greenBtn = document.getElementById('greenBtn');
const blueBtn = document.getElementById('bluebtn');
const resetBtn = document.getElementById('resetBtn');

// Click Event
redBtn.addEventListener('click', () => {
    box.style.backgroundColor = 'red';
    info.textContent = 'Red button clicked';
});

greenBtn.addEventListener('click', () => {
    box.style.backgroundColor = 'green';
    info.textContent = 'Green button clicked';
});

blueBtn.addEventListener('click', () => {
    box.style.backgroundColor = 'blue';
    info.textContent = 'Blue button clicked';
});

resetBtn.addEventListener('click', () => {
    box.style.backgroundColor = 'grey';
    box.style.transform = 'rotate(0deg)';
    info.textContent = 'Reset button clicked';
});

box.addEventListener('dblclick', () => {
    box.style.transform = 'rotate(45deg)';
    info.textContent = 'Box double clicked';
})

// Mouse Enter Event
box.addEventListener('mouseenter', () => {
    box.style.border = '5px solid black';
    info.textContent = 'Box mouse enter';
})

// Mouse Leave Event
box.addEventListener('mouseleave', () => {
    box.style.border = '0px solid black';
    info.textContent = 'Box mouse leave';
})