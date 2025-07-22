function showUserPopup(): void {
    fetch("/api/Backend/Perdoruesit")
        .then(response => response.json())
        .then(users => {
            const container = document.getElementById("userListContainer");
            const popup = document.getElementById("userPopup");
            if (!container || !popup) return;

            container.innerHTML = ""; // Clear existing content

            users.forEach((user: { UserID: number; Username: string }) => {
                const row = document.createElement("div");
                row.className = "user-row"; // Optional for styling
                row.innerHTML = `
                    <span>${user.Username}</span>
                    <button onclick="deleteUser(${user.UserID})">Delete</button>
                `;
                container.appendChild(row);
            });

            popup.style.display = "block"; // ✅ This shows the popup
        })
        .catch(error => {
            console.error("Failed to load users:", error);
        });
}

async function deleteUser(UserID: number): Promise<void> {
    await fetch(`/api/Backend/DeleteUser`, {
        method: "POST",
        body: JSON.stringify({ UserID }),
        headers: {"Content-Type": "application/json"}
    })
        .then(response => {
            if (!response.ok) {
                throw new Error("Failed to delete userrrr");
            }
            console.log("User deleted successfully");
            showUserPopup(); // Refresh the user list
        })
        .catch(error => {
            console.error("Failed to delete userm", error);
        });
}


// Expose globally
(window as any).deleteUser = deleteUser;
    

function closeUserPopup(): void {
    const popup = document.getElementById("userPopup");
    if (popup) {
        popup.style.display = "none";
    }
}

// Make sure functions are available globally
(window as any).showUserPopup = showUserPopup;
(window as any).closeUserPopup = closeUserPopup;

