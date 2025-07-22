//window.addEventListener("DOMContentLoaded", () => {
//    const container = document.getElementById("taskNotifications") as HTMLElement | null;
//    const tasks: any[] = (window as any)["tasksFromServer"];
//    console.log("Checking tasks for reminders...", tasks);

//    if (!Array.isArray(tasks) || !container) return;

//    const today = new Date();
//    const todayStr = today.toISOString().split("T")[0];

//    tasks.forEach((task: any) => {
//        if (!task.DueDate || task.IsCompleted) return;

//        const taskDate = new Date(task.DueDate);
//        const taskDateStr = taskDate.toISOString().split("T")[0];

//        if (taskDateStr === todayStr) {
//            addNotification(container, `📅 Due Today: ${task.Text}`, "due-today");
//        } else if (taskDateStr < todayStr) {
//            addNotification(container, `⚠️ Overdue: ${task.Text}`, "overdue");
//        }
//    });
//});

//function addNotification(container: HTMLElement, message: string, type: string): void {
//    const div = document.createElement("div");
//    div.className = `notification ${type}`;
//    div.textContent = message;
//    container.appendChild(div);
//}
