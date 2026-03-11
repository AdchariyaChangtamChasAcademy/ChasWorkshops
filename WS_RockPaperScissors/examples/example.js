// JS-panel
const btn = document.getElementById('toggle-btn');
const panel = document.getElementById('panel');

btn.addEventListener('click', () => {
  panel.classList.toggle('open');
});