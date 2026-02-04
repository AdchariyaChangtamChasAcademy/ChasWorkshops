function capitalize(str) {
    return str.charAt(0).toUpperCase() + str.slice(1);
}

function reverseString(str) {
    return str.split('').reverse().join('');
}

function isPalindrome(str) {
    return str === str.split('').reverse().join('');
}

function countVowels(str) {
    return (str.match(/[aeiouàáâäãåèéêëìíîïòóôöùúûü]/gi) || []).length;
}

function truncate(str, maxLength) {
    if (str.length > maxLength) {
        return str.slice(0, maxLength) + '...';
    }
    return str;
}

module.exports = { capitalize, reverseString, isPalindrome, countVowels, truncate };