// --- Elements ---
const buttons = document.querySelectorAll('button[data-choice]');
const playerSpan = document.getElementById('player-choice');
const computerSpan = document.getElementById('opponent-choice');
const outcomeEl = document.getElementById('rps-outcome');

const playerHand = document.getElementById('player-hand');
const computerHand = document.getElementById('opponent-hand');

const resultBox = document.querySelector('.result');

// --- Game data ---
const choices = ['rock', 'paper', 'scissors'];

const emojiMap = {
  rock: '✊',
  paper: '✋',
  scissors: '✌️'
};

// --- Helpers ---
function getComputerChoice() {
  return choices[Math.floor(Math.random() * choices.length)];
}

function getOutcome(player, computer) {
  if (player === computer) return 'draw';
  if (
    (player === 'rock' && computer === 'scissors') ||
    (player === 'paper' && computer === 'rock') ||
    (player === 'scissors' && computer === 'paper')
  ) return 'win';
  return 'lose';
}

// --- Game ---
buttons.forEach(button => {
  button.addEventListener('click', () => {
    const playerChoice = button.dataset.choice;

    outcomeEl.textContent = 'Thinking...';
    playerHand.textContent = '❓';
    computerHand.textContent = '❓';

    setTimeout(() => {
      const computerChoice = getComputerChoice();
      const outcome = getOutcome(playerChoice, computerChoice);

      // Update text
      playerSpan.textContent = playerChoice;
      computerSpan.textContent = computerChoice;

      // Update big hands
      playerHand.textContent = emojiMap[playerChoice];
      computerHand.textContent = emojiMap[computerChoice];

      // Outcome message
      if (outcome === 'win') {
        outcomeEl.textContent = 'You win! 🎉';
      } else if (outcome === 'lose') {
        outcomeEl.textContent = 'You lose! 😅';
      } else {
        outcomeEl.textContent = 'Tie! 🤝';
      }
    }, 800);
  });
});
