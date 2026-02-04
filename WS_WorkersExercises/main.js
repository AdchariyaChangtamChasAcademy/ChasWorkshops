/* Worker - Counter */
const startBtn = document.getElementById("startBtn");
const pingBtn = document.getElementById("pingBtn");
const resultCounter = document.getElementById("resultCounter");

// New worker
const workerCounter = new Worker('../workers/counter-worker.js');

// Message listen
workerCounter.addEventListener("message", (event) => {
  if (event.data.progress) {
        resultCounter.textContent = "Progress: " + event.data.progress;
    } else {
        resultCounter.textContent = `${event.data.result} - Time: ${event.data.durationMs.toFixed(0)} ms`;
    }
});

// Start count
startBtn.addEventListener("click", () => {
  resultCounter.textContent = "Counting...";
  workerCounter.postMessage({ start: 0, end: 1_000_000_000 });
});

// Ping for UI-response test
pingBtn.addEventListener("click", () => {
  alert("UI still responsive!");
});

/* Worker - Upper Case */
const inputText = document.getElementById("inputText");
const convertBtn = document.getElementById("convertBtn");
const resultUpperCaseText = document.getElementById("resultUpperCaseText");

// New worker
const workerUpperCaseText = new Worker('../workers/text-worker.js');

// Message listen
workerUpperCaseText.addEventListener("message", (event) => {
    resultUpperCaseText.textContent = event.data;
});

convertBtn.addEventListener("click", () => {
    const text = inputText.value;
    workerUpperCaseText.postMessage(text);
});

/* Worker - Array Sorter */
const sortBtn = document.getElementById("sortArraysBtn");
const result1 = document.getElementById("result1");
const result2 = document.getElementById("result2");
const result3 = document.getElementById("result3");

// New worker
const workerArraySorter = new Worker('../workers/multi-sort-worker.js');

// Generate arrays and send to worker
sortBtn.addEventListener("click", () => {
    const array1 = Array.from({ length: 10000 }, () => Math.floor(Math.random() * 100000));
    const array2 = Array.from({ length: 10000 }, () => Math.floor(Math.random() * 100000));
    const array3 = Array.from({ length: 10000 }, () => Math.floor(Math.random() * 100000));

    workerArraySorter.postMessage({ array1, array2, array3 });
});

// Message listen
workerArraySorter.addEventListener("message", (event) => {
    const { sortedArray1, sortedArray2, sortedArray3 } = event.data;

    // Show sorted array of the sizes 20, 10, 5
    result1.textContent = sortedArray1.slice(0, 20).join(", ");
    result2.textContent = sortedArray2.slice(0, 10).join(", ");
    result3.textContent = sortedArray3.slice(0, 5).join(", ");
});

