//// TEST 1

// const { sum, subtract, multiply, divide } = require('./math');

// // Testa sum-funktionen
// test('adds 1 + 2 to equal 3', () => {
//   expect(sum(1, 2)).toBe(3);
// });

// test('adds negative numbers correctly', () => {
//   expect(sum(-1, -2)).toBe(-3);
// });

// // Testa subtract-funktionen
// test('subtracts 5 - 3 to equal 2', () => {
//   expect(subtract(5, 3)).toBe(2);
// });

// // Testa multiply-funktionen
// test('multiplies 4 * 5 to equal 20', () => {
//   expect(multiply(4, 5)).toBe(20);
// });

// // Testa divide-funktionen
// test('divides 10 / 2 to equal 5', () => {
//   expect(divide(10, 2)).toBe(5);
// });

// test('throws error when dividing by zero', () => {
//   expect(() => divide(10, 0)).toThrow('Division by zero is not allowed');
// });

//// TEST 2

const { sum, subtract, multiply, divide } = require('./math');

describe('Math operations', () => {
  
  describe('sum()', () => {
    test('adds positive numbers', () => {
      expect(sum(1, 2)).toBe(3);
      expect(sum(10, 20)).toBe(30);
    });
    
    test('adds negative numbers', () => {
      expect(sum(-1, -2)).toBe(-3);
    });
    
    test('adds zero correctly', () => {
      expect(sum(5, 0)).toBe(5);
      expect(sum(0, 0)).toBe(0);
    });
  });
  
  describe('divide()', () => {
    test('divides numbers correctly', () => {
      expect(divide(10, 2)).toBe(5);
      expect(divide(9, 3)).toBe(3);
    });
    
    test('handles decimals', () => {
      expect(divide(10, 3)).toBeCloseTo(3.33, 2);
    });
    
    test('throws error for division by zero', () => {
      expect(() => divide(10, 0)).toThrow();
      expect(() => divide(5, 0)).toThrow('Division by zero is not allowed');
    });
  });
  
});