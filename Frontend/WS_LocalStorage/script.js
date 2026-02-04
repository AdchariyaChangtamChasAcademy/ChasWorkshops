const userNameInput = document.getElementById('userNameInput');
const userEmailInput = document.getElementById('userEmailInput');
const userAgeInput = document.getElementById('userAgeInput');
const saveUserBtn = document.getElementById('saveUserBtn');
const loadUserBtn = document.getElementById('loadUserBtn');
const userOutput = document.getElementById('userOutput');

// Spara användarobjekt
saveUserBtn.addEventListener('click', () => {
  const user = {
    name: userNameInput.value,
    email: userEmailInput.value,
    age: parseInt(userAgeInput.value),
    savedAt: new Date().toLocaleString('sv-SE')
  };
  
  if (user.name && user.email && user.age) {
    // Konvertera objekt till JSON-sträng
    localStorage.setItem('userProfile', JSON.stringify(user));
    userOutput.innerHTML = '<p style="color: green;">Användarinfo sparad!</p>';
    
    // Rensa fält
    userNameInput.value = '';
    userEmailInput.value = '';
    userAgeInput.value = '';
  } else {
    userOutput.innerHTML = '<p style="color: red;">Fyll i alla fält!</p>';
  }
});

// Ladda användarobjekt
loadUserBtn.addEventListener('click', () => {
  const userJson = localStorage.getItem('userProfile');
  
  if (userJson) {
    // Konvertera JSON-sträng till objekt
    const user = JSON.parse(userJson);
    
    userOutput.innerHTML = `
      <h3>Användarinfo:</h3>
      <p><strong>Namn:</strong> ${user.name}</p>
      <p><strong>E-post:</strong> ${user.email}</p>
      <p><strong>Ålder:</strong> ${user.age} år</p>
      <p><em>Sparad: ${user.savedAt}</em></p>
    `;
  } else {
    userOutput.innerHTML = '<p style="color: orange;">Ingen användarinfo sparad.</p>';
  }
});

const testInput = document.getElementById('testInput');
const saveLocalBtn = document.getElementById('saveLocalBtn');
const saveSessionBtn = document.getElementById('saveSessionBtn');
const loadBothBtn = document.getElementById('loadBothBtn');
const comparisonOutput = document.getElementById('comparisonOutput');

// Spara i LocalStorage
saveLocalBtn.addEventListener('click', () => {
  const data = testInput.value;
  localStorage.setItem('testData', data);
  comparisonOutput.innerHTML = '<p style="color: green;">Data sparad i LocalStorage!</p>';
});

// Spara i SessionStorage
saveSessionBtn.addEventListener('click', () => {
  const data = testInput.value;
  sessionStorage.setItem('testData', data);
  comparisonOutput.innerHTML = '<p style="color: blue;">Data sparad i SessionStorage!</p>';
});

// Ladda från båda
loadBothBtn.addEventListener('click', () => {
  const localData = localStorage.getItem('testData');
  const sessionData = sessionStorage.getItem('testData');
  
  comparisonOutput.innerHTML = `
    <h3>Jämförelse:</h3>
    <p><strong>LocalStorage:</strong> ${localData || '(tom)'}</p>
    <p><strong>SessionStorage:</strong> ${sessionData || '(tom)'}</p>
    <p><em>Tips: Stäng fliken och öppna igen. LocalStorage finns kvar, men SessionStorage är borta!</em></p>
  `;
});