const { filterEven, findMax, removeDuplicates } = require('./array-utils');

describe('Array utilities', () => {
  
  describe('filterEven()', () => {
    test('filters even numbers', () => {
      expect(filterEven([1, 2, 3, 4, 5, 6])).toEqual([2, 4, 6]);
    });
    
    test('returns empty array for no even numbers', () => {
      expect(filterEven([1, 3, 5])).toEqual([]);
    });
  });
  
  describe('findMax()', () => {
    test('finds maximum number', () => {
      expect(findMax([1, 5, 3, 9, 2])).toBe(9);
    });
    
    test('returns null for empty array', () => {
      expect(findMax([])).toBeNull();
    });
  });
  
  describe('removeDuplicates()', () => {
    test('removes duplicate values', () => {
      expect(removeDuplicates([1, 2, 2, 3, 3, 4])).toEqual([1, 2, 3, 4]);
    });
    
    test('handles array with no duplicates', () => {
      expect(removeDuplicates([1, 2, 3])).toEqual([1, 2, 3]);
    });
  });
  
});