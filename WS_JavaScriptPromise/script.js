// Promise.all - väntar på alla Promises
async function getAllData() {
  try {
    const results = await Promise.all([
      fetch('https://jsonplaceholder.typicode.com/posts/1').then(r => r.json()),
      fetch('https://jsonplaceholder.typicode.com/users/1').then(r => r.json()),
      fetch('https://jsonplaceholder.typicode.com/comments/1').then(r => r.json())
    ]);
    
    console.log('Alla resultat:', results);
    // Om EN misslyckas, misslyckas ALLA
  } catch (error) {
    console.error('Minst en förfrågan misslyckades:', error);
  }
}

// Promise.race - returnerar den första som blir klar
async function raceExample() {
  try {
    const fastest = await Promise.race([
      delay(1000).then(() => 'Förfrågan 1'),
      delay(500).then(() => 'Förfrågan 2'),
      delay(1500).then(() => 'Förfrågan 3')
    ]);
    
    console.log('Snabbast:', fastest); // 'Förfrågan 2'
  } catch (error) {
    console.error('Fel:', error);
  }
}

// Promise.allSettled - väntar på alla, även om vissa misslyckas
async function getAllSettledExample() {
  const results = await Promise.allSettled([
    Promise.resolve('Lyckades'),
    Promise.reject('Misslyckades'),
    Promise.resolve('Lyckades igen')
  ]);
  
  results.forEach((result, index) => {
    if (result.status === 'fulfilled') {
      console.log(`Promise ${index}: Lyckades med ${result.value}`);
    } else {
      console.log(`Promise ${index}: Misslyckades med ${result.reason}`);
    }
  });
}