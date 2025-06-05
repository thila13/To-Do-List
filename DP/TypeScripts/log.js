//console.log("JS is running");
//window.onload = () => {
//    const loginBtn = document.querySelector("input[id$='btnLogin']") as HTMLInputElement;
//    if (!loginBtn) {
//        console.error("Login button not found.");
//        return;
//    }
//console.log("Login button found!");
//    loginBtn.addEventListener("click", (e) => {
//        //e.preventDefault(); // Stop the form from submitting normally
//        //alert("Login button clicked!");
//        const usernameInput = document.getElementById("username") as HTMLInputElement;
//        const passwordInput = document.getElementById("password") as HTMLInputElement;
//        if (!usernameInput || !passwordInput) {
//            console.error("Username or password field not found.");
//            return;
//        }
//        const username = usernameInput.value;
//        const password = passwordInput.value;
//        console.log("username:", username);
//        console.log("password:", password);
//        const hiddenlogin = document.querySelector("input[id$='hiddenLogin']") as HTMLInputElement;
//        const form = document.querySelector("form[id$='form1']") as HTMLFormElement;
//        if (!hiddenlogin || !form) {
//            console.error("Hidden field or form not found.");
//            return;
//        }
//        if (username === "admin" && password === "1234") {
//            hiddenlogin.value = "success";
//            // Inject the ASP.NET button's name manually so the server recognizes the event
//            const btnField = document.createElement("input");
//            btnField.type = "hidden";
//            btnField.name = loginBtn.name; // ASP.NET identifies button click by name
//            btnField.value = loginBtn.value;
//            form.appendChild(btnField);
//            form.submit(); // Now the server-side btnLogin_Click should run
//        } else {
//            alert("Invalid username or password");
//        }
//    });
//};
//# sourceMappingURL=log.js.map