let todos = [];

// Load todos from LocalStorage
const loadTodos = () => {
    const storedTodos = localStorage.getItem("todos");
    if (storedTodos) {
        todos = JSON.parse(storedTodos);
    }
    displayTodos();
};

// Save todos to LocalStorage
const saveTodos = () => {
    localStorage.setItem("todos", JSON.stringify(todos));
};

// Add new todo
const addTodo = (text) => {
    if (text.trim() === "") return;

    todos.push({
        text: text,
        completed: false
    });

    saveTodos();
    displayTodos();
};

// Toggle completed status
const toggleTodo = (index) => {
    todos[index].completed = !todos[index].completed;
    saveTodos();
    displayTodos();
};

// Remove todo
const removeTodo = (index) => {
    todos.splice(index, 1);
    saveTodos();
    displayTodos();
};

// Display todos
const displayTodos = () => {
    const taskList = document.getElementById("taskList");
    taskList.innerHTML = "";

    todos.forEach((todo, index) => {
    const li = document.createElement("li");

    // Checkbox
    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.checked = todo.completed;
    checkbox.addEventListener("change", () => toggleTodo(index));

    // Text
    const taskText = document.createElement("span");
    taskText.textContent = todo.text;
    if (todo.completed) {
        taskText.style.textDecoration = "line-through";
    }

    // Remove button
    const removeBtn = document.createElement("button");
    removeBtn.textContent = "Ta bort uppgift";
    removeBtn.setAttribute("aria-label", `Ta bort uppgift: ${todo.text}`);
    removeBtn.addEventListener("click", () => removeTodo(index));
        li.appendChild(checkbox);
        li.appendChild(taskText);
        li.appendChild(removeBtn);
        taskList.appendChild(li);
    });
};

document.getElementById("taskForm").addEventListener("submit", (e) => {
    e.preventDefault();
    const input = document.getElementById("taskInput");
    addTodo(input.value);
    input.value = "";
});

loadTodos();


const loadProfile = () => {
    const storedProfile = localStorage.getItem("profile");
    if (!storedProfile) return;

    const profile = JSON.parse(storedProfile);

    document.getElementById("name").value = profile.name || "";
    document.getElementById("email").value = profile.email || "";
    document.getElementById("age").value = profile.age || "";
    document.getElementById("city").value = profile.city || "";
    document.getElementById("interests").value = profile.interests || "";

    showWelcomeMessage(profile.name);
};

// Save profile to LocalStorage
const saveProfile = () => {
    const profile = {
        name: document.getElementById("name").value,
        email: document.getElementById("email").value,
        age: document.getElementById("age").value,
        city: document.getElementById("city").value,
        interests: document.getElementById("interests").value
    };

    localStorage.setItem("profile", JSON.stringify(profile));
    showWelcomeMessage(profile.name);
};

// Clear profile
const clearProfile = () => {
    localStorage.removeItem("profile");
    document.getElementById("profileForm").reset();
    document.getElementById("welcomeMessage").textContent = "";
};

// Show welcome message
const showWelcomeMessage = (name) => {
    const welcomeMessage = document.getElementById("welcomeMessage");
    welcomeMessage.textContent = `Välkommen tillbaka, ${name}!`;
};

// Profile form submit
document.getElementById("profileForm").addEventListener("submit", (e) => {
    e.preventDefault();
    saveProfile();
});

// Clear profile button
document.getElementById("clearBtn").addEventListener("click", () => {
    clearProfile();
});

// Load profile on page load
loadProfile();