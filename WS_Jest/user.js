class User {
  constructor(name, email, age) {
    this.name = name;
    this.email = email;
    this.age = age;
    this.isActive = true;
  }
  
  deactivate() {
    this.isActive = false;
  }
  
  updateEmail(newEmail) {
    if (!newEmail.includes('@')) {
      throw new Error('Invalid email format');
    }
    this.email = newEmail;
  }
  
  getInfo() {
    return `${this.name} (${this.email})`;
  }
}

module.exports = User;