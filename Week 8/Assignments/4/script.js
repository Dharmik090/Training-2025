async function loadUsers() {
    const userList = document.getElementById("userList");

    try {
        const response = await fetch("https://jsonplaceholder.typicode.com/users");

        if (!response.ok) {
            throw new Error("Network response was not ok");
        }

        const users = await response.json();

        users.forEach(user => {
            const li = document.createElement("li");
            li.innerText = user.name;

            userList.appendChild(li);
        });


    } catch (error) {
        console.error("Failed to load users:", error);
        userList.innerHTML = "<li>Error loading users.</li>";
    }
}

// Load users after page loads
loadUsers();
