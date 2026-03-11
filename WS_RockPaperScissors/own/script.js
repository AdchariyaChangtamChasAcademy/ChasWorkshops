// ===============================
// ELEMENTS
// ===============================
const buttons = document.querySelectorAll('button[data-move]');
const textBox = document.getElementById('text');

const playerHP = document.getElementById('player-hp');
const enemyHP = document.getElementById('enemy-hp');

const playerHand = document.getElementById('player-hand');
const enemyHand = document.getElementById('enemy-hand');

const playerLosePop = document.getElementById('player-pop');
const enemyLosePop = document.getElementById('enemy-pop');

// ===============================
// GAME DATA
// ===============================
const MOVES = ['rock', 'paper', 'scissors'];

const EMOJI = {
  rock: '✊',
  paper: '✋',
  scissors: '✌️'
};

let locked = false;

// ===============================
// HELPERS
// ===============================
function randomMove() {
  return MOVES[Math.floor(Math.random() * MOVES.length)];
}

function getOutcome(player, enemy) {
  if (player === enemy) return 'draw';
  if (
    (player === 'rock' && enemy === 'scissors') ||
    (player === 'paper' && enemy === 'rock') ||
    (player === 'scissors' && enemy === 'paper')
  ) return 'win';
  return 'lose';
}

function showHand(handEl, move) {
  handEl.textContent = EMOJI[move];
  handEl.classList.remove('show');
  void handEl.offsetWidth; // restart animation
  handEl.classList.add('show');
}

function lockControls(state) {
  locked = state;
  buttons.forEach(btn => btn.disabled = state);
}

// ===============================
// TURN LOGIC
// ===============================
function showScorePop(loserPopEl) {
  loserPopEl.classList.remove('show');
  void loserPopEl.offsetWidth; // restart animation
  loserPopEl.classList.add('show');
}

buttons.forEach(button => {
  button.addEventListener('click', () => {
    if (locked) return;

    lockControls(true);

    const playerMove = button.dataset.move;
    const enemyMove = randomMove();

    // Show hands immediately
    showHand(playerHand, playerMove);
    showHand(enemyHand, enemyMove);

    // Sync loser pop with hand “clash”
    setTimeout(() => {
      const result = getOutcome(playerMove, enemyMove);

      if (result === 'win') {
        showScorePop(enemyLosePop);
        enemyHP.value = Math.max(0, enemyHP.value - 20);
      } else if (result === 'lose') {
        showScorePop(playerLosePop);
        playerHP.value = Math.max(0, playerHP.value - 20);
      }

      // End battle if HP 0
      if (enemyHP.value === 0 || playerHP.value === 0) {
        lockControls(true);
        return;
      }

      lockControls(false);
    }, 500); // matches hand animation timing
  });
})

// Remove show class after animation
playerLosePop.addEventListener('animationend', () => playerLosePop.classList.remove('show'));
enemyLosePop.addEventListener('animationend', () => enemyLosePop.classList.remove('show'));