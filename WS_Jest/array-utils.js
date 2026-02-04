function filterEven(numbers) {
  return numbers.filter(n => n % 2 === 0);
}

function findMax(numbers) {
  if (numbers.length === 0) {
    return null;
  }
  return Math.max(...numbers);
}

function removeDuplicates(array) {
  return [...new Set(array)];
}

module.exports = { filterEven, findMax, removeDuplicates };