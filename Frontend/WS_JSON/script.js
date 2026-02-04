const resultDiv = document.getElementById('result');
const getUsersBtn = document.getElementById('getUsers');
const getPostBtn = document.getElementById('getPost');

// Hämta alla användare
getUsersBtn.addEventListener('click', () => {
  resultDiv.innerHTML = '<p>Laddar användare...</p>';
  
  fetch('https://jsonplaceholder.typicode.com/users')
    .then(response => {
      console.log('Response status:', response.status);
      console.log('Response OK?', response.ok);
      return response.json();
    })
    .then(users => {
      console.log('Användare:', users);
      displayUsers(users);
    })
    .catch(error => {
      console.error('Fel vid hämtning:', error);
      resultDiv.innerHTML = `<p style="color: red;">Fel: ${error.message}</p>`;
    });
});

// Visa användare i DOM
function displayUsers(users) {
  let html = '<h2>Användare:</h2>';
  
  users.slice(0, 5).forEach(user => {
    html += `
      <div class="user-card">
        <h3>${user.name}</h3>
        <p><strong>Email:</strong> ${user.email}</p>
        <p><strong>Stad:</strong> ${user.address.city}</p>
        <p><strong>Företag:</strong> ${user.company.name}</p>
      </div>
    `;
  });
  
  resultDiv.innerHTML = html;
}

// Hämta ett specifikt inlägg
getPostBtn.addEventListener('click', () => {
  resultDiv.innerHTML = '<p>Laddar inlägg...</p>';
  
  fetch('https://jsonplaceholder.typicode.com/posts/1')
    .then(response => response.json())
    .then(post => {
      console.log('Inlägg:', post);
      resultDiv.innerHTML = `
        <h2>${post.title}</h2>
        <p>${post.body}</p>
        <p><em>Användare ID: ${post.userId}</em></p>
      `;
    })
    .catch(error => {
      console.error('Fel:', error);
      resultDiv.innerHTML = `<p style="color: red;">Fel: ${error.message}</p>`;
    });
});