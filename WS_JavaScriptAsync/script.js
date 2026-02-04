const resultDiv = document.getElementById('result');
const fetchBtn = document.getElementById('fetchBtn');
const multipleBtn = document.getElementById('multipleBtn');

// Async funktion för att hämta användare
async function getUser(userId) {
  try {
    resultDiv.innerHTML = '<p class="loading">Hämtar användare...</p>';
    
    const response = await fetch(`https://jsonplaceholder.typicode.com/users/${userId}`);
    
    if (!response.ok) {
      throw new Error(`HTTP-fel! Status: ${response.status}`);
    }
    
    const user = await response.json();
    
    resultDiv.innerHTML = `
      <div class="success">
        <h2>${user.name}</h2>
        <p><strong>Email:</strong> ${user.email}</p>
        <p><strong>Telefon:</strong> ${user.phone}</p>
        <p><strong>Stad:</strong> ${user.address.city}</p>
      </div>
    `;
    
    return user;
    
  } catch (error) {
    resultDiv.innerHTML = `<p class="error">Fel: ${error.message}</p>`;
    console.error('Fel vid hämtning:', error);
  }
}

// Hämta en användare
fetchBtn.addEventListener('click', () => {
  getUser(1);
});

// Hämta flera användare parallellt
async function getMultipleUsers() {
  try {
    resultDiv.innerHTML = '<p class="loading">Hämtar användare...</p>';
    
    // Promise.all kör alla Promises parallellt
    const [user1, user2, user3] = await Promise.all([
      fetch('https://jsonplaceholder.typicode.com/users/1').then(r => r.json()),
      fetch('https://jsonplaceholder.typicode.com/users/2').then(r => r.json()),
      fetch('https://jsonplaceholder.typicode.com/users/3').then(r => r.json())
    ]);
    
    resultDiv.innerHTML = `
      <div class="success">
        <h3>Användare hämtade:</h3>
        <ul>
          <li>${user1.name} - ${user1.email}</li>
          <li>${user2.name} - ${user2.email}</li>
          <li>${user3.name} - ${user3.email}</li>
        </ul>
      </div>
    `;
    
  } catch (error) {
    resultDiv.innerHTML = `<p class="error">Fel: ${error.message}</p>`;
  }
}

multipleBtn.addEventListener('click', getMultipleUsers);