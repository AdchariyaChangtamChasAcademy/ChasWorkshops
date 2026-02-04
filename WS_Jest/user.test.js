const User = require('./user');

describe('User class', () => {
  
  test('creates a new user with correct properties', () => {
    const user = new User('Anna', 'anna@example.com', 28);
    
    expect(user.name).toBe('Anna');
    expect(user.email).toBe('anna@example.com');
    expect(user.age).toBe(28);
    expect(user.isActive).toBe(true);
  });
  
  test('deactivates user', () => {
    const user = new User('Erik', 'erik@example.com', 30);
    user.deactivate();
    
    expect(user.isActive).toBe(false);
  });
  
  test('updates email successfully', () => {
    const user = new User('Lisa', 'lisa@example.com', 25);
    user.updateEmail('lisa.new@example.com');
    
    expect(user.email).toBe('lisa.new@example.com');
  });
  
  test('throws error for invalid email', () => {
    const user = new User('Karl', 'karl@example.com', 35);
    
    expect(() => user.updateEmail('invalid-email')).toThrow('Invalid email format');
  });
  
  test('returns correct user info', () => {
    const user = new User('Sara', 'sara@example.com', 27);
    
    expect(user.getInfo()).toBe('Sara (sara@example.com)');
  });
  
});