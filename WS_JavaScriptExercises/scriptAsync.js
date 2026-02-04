const postIdInput = document.getElementById('postId');
const fetchPostBtn = document.getElementById('fetchPostBtn');
const resultDiv = document.getElementById('result');
const loadingDiv = document.getElementById('loading');

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

const fetchPost = async (postId) => {
    showLoading('Fetching post...');
    await sleep(2000); 
    const response = await fetch(`https://jsonplaceholder.typicode.com/posts/${postId}`);
    hideLoading();
    if (!response.ok) throw new Error('Could not fetch post');
    return await response.json();
}

const fetchUser = async (userId) => {
    showLoading('Fetching user...');
    await sleep(2000); 
    const response = await fetch(`https://jsonplaceholder.typicode.com/users/${userId}`);
    hideLoading();
    if (!response.ok) throw new Error('Could not fetch user');
    return await response.json();
}

const fetchComments = async (commentId) => {
    showLoading('Fetching comments...');
    await sleep(2000); 
    const response = await fetch(`https://jsonplaceholder.typicode.com/posts/${commentId}/comments`);
    hideLoading();
    if (!response.ok) throw new Error('Could not fetch comment');
    return await response.json();
}

async function loadBlogPost() {
    const postId = postIdInput.value;
    try {
        const post = await fetchPost(postId);
        const user = await fetchUser(post.userId);
        const comments = await fetchComments(postId);

        resultDiv.innerHTML = `
        <div class="post">
            <h2>${post.title}</h2>
            <p>${post.body}</p>

            <hr>

            <p><strong>Författare:</strong> ${user.name} (${user.email})</p>
            <p><strong>Kommentarer:</strong> ${comments.length}</p>

            <div class="comments">
            <h3>Kommentarer:</h3>
            ${comments.map(c => `
                <div class="comment">
                <p><strong>${c.name}</strong> (${c.email})</p>
                <p>${c.body}</p>
                </div>
            `).join("")}
            </div>
        </div>
        `;

    } catch (error) {
        resultDiv.innerHTML = `<p class="error">Fel: ${error.message}</p>`;
        console.error(error);
    }
}

fetchPostBtn.addEventListener("click", loadBlogPost);