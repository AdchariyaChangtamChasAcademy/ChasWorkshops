const loadBtn = document.getElementById('loadBtn');
const loadingDiv = document.getElementById('loading');
const resultDiv = document.getElementById('result');

const sleep = (ms) => {
    return new Promise(resolve => setTimeout(resolve, ms));
}

const showLoading = (message) => {
  loadingDiv.innerHTML = `
    <span>${message}</span>
    <span class="spinner"></span>
  `;
}

const hideLoading = () => {
  loadingDiv.innerHTML = "";
}

const loadDashboard = async () =>{
    showLoading('Loading data...');
    
    const startTime = performance.now();
    await sleep(2000); // Fake loading for spinny
    try {
        const [users, posts, todos] = await Promise.all([
            fetch(`https://jsonplaceholder.typicode.com/users`).then(res => res.json()),
            fetch(`https://jsonplaceholder.typicode.com/posts`).then(res => res.json()),
            fetch(`https://jsonplaceholder.typicode.com/todos`).then(res => res.json()),
    ]);

    const endTime = performance.now();
    const totalTime = ((endTime - startTime) / 1000).toFixed(2);
    const totalUsers = users.length;
    const totalPosts = posts.length;
    const completedTodos = todos.filter(t => t.completed).length;
    const incompleteTodos = todos.length - completedTodos;
    const avgPostsPerUser = (totalPosts / totalUsers).toFixed(2);

    resultDiv.innerHTML = `
        <div class="stats">
        <h2>Statistik</h2>
        <p><strong>Total users:</strong> ${totalUsers}</p>
        <p><strong>Total posts:</strong> ${totalPosts}</p>
        <p><strong>Todos (complete):</strong> ${completedTodos}</p>
        <p><strong>Todos (incomplete):</strong> ${incompleteTodos}</p>
        <p><strong>Average post per user:</strong> ${avgPostsPerUser}</p>
        <p><strong>Total loading time:</strong> ${totalTime} sec</p>
        </div>
    `;

    } catch (error) {
        resultDiv.innerHTML = `<p class="error">Fel: ${error.message}</p>`;
    } finally {
        hideLoading();
    }
}

loadBtn.addEventListener("click", loadDashboard);
