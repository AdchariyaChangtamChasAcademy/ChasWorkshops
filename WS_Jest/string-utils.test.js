const { capitalize, reverseString, isPalindrome, countVowels, truncate } = require('./string-utils');

describe('String operations', () => {
  
  describe('capitalize()', () => {
    test('Capitalize first letter', () => {
      expect(capitalize('alice')).toBe('Alice');
      expect(capitalize('bob')).toBe('Bob');
    });
  });
  
  describe('reverseString()', () => {
    test('Reverse string', () => {
      expect(reverseString('alice')).toBe('ecila');
      expect(reverseString('bob')).toBe('bob');
    });
  });
  
  describe('isPalindrome()', () => {
    test('Check if string is a palindrome', () => {
      expect(isPalindrome('alice')).toBeFalsy();
      expect(isPalindrome('bob')).toBeTruthy();
    });
  });

  describe('countVowels()', () => {
    test('Count number of vowels', () => {
      expect(countVowels('alice')).toBe(3);
      expect(countVowels('bob')).toBe(1);
    });
  });

  describe('truncate()', () => {
    test('Truncates string to input length', () => {
      expect(truncate('alice', 2)).toBe('al...');
      expect(truncate('bob', 1)).toBe('b...');
    });
  });
});