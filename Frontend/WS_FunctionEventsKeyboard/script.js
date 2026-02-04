const textArea = document.getElementById('textArea');
const keyInfo = document.getElementById('keyInfo');
const historyList = document.getElementById('historyList');
const keyCount = document.getElementById('keyCount');
const keyTimerText = document.getElementById('keyTimerText');

let count = 0;
let history = [];
let timestampDown = 0;

textArea.addEventListener('keydown', (event) => {
  // Uppdatera räknaren
  count++;
  keyCount.textContent = count;
  timestampDown = Date.now();
  
  // Visa information om tangenten
  keyInfo.innerHTML = `
    <h3>Senaste tangenten</h3>
    <p><strong>Tangent:</strong> ${event.key}</p>
    <p><strong>Kod:</strong> ${event.code}</p>
    <p><strong>KeyCode:</strong> ${event.keyCode}</p>
  `;
  
  // Lägg till i historik
  history.push(event.key);
  
  // Behåll bara de senaste 5
  if (history.length > 5) {
    history.shift();
  }
  
  // Uppdatera historiklistan
  if (history.length > 0) {
    historyList.innerHTML = history
      .map(key => `<li>${key}</li>`)
      .join('');
  }
});


// UPPGIFTER

// TODO: Visa hur länge tangenten var nedtryckt (keyup-event)
// 1. Skapa en variabel för att lagra timestamp när tangenten trycktes ner
// 2. Lägg till en keyup event listener på textArea
// 3. Beräkna skillnaden mellan keyup och keydown timestamp
// 4. Visa resultatet i keyInfo eller en egen sektion

textArea.addEventListener('keyup', (event) => {
    const duration = Date.now() - timestampDown;
    keyInfo.innerHTML += `
    <p><strong>Time:</strong> ${duration}</p>`;
});

// TODO: Detektera modifier-tangenter (Ctrl, Shift, Alt)
// 1. I keydown event listener, kolla event.ctrlKey, event.shiftKey och event.altKey
// 2. Visa vilka modifier-tangenter som är nedtryckta i keyInfo-sektionen
// Tips: Du kan lägga till detta i den befintliga keyInfo.innerHTML


// TODO: ESC för att rensa textarea
// 1. I keydown event listener, lägg till en if-sats
// 2. Kolla om event.key === 'Escape'
// 3. Sätt textArea.value = '' för att rensa textfältet


// TODO: Ctrl+S för att visa "Sparad!"
// 1. I keydown event listener, lägg till en if-sats
// 2. Kolla om event.ctrlKey && event.key === 's'
// 3. Använd event.preventDefault() för att hindra webbläsarens spara-dialog
// 4. Visa ett meddelande "Sparad!" (t.ex. med alert eller i keyInfo)


// TODO: Visa om CapsLock är aktiverat
// 1. I keydown event listener, använd event.getModifierState('CapsLock')
// 2. Visa CapsLock-status i keyInfo eller en egen sektion
// Tips: Du kan visa detta som "CapsLock: PÅ" eller "CapsLock: AV"