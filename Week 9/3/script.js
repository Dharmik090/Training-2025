function loadTasks() {
    $("#loader").show();

    $.get("https://jsonplaceholder.typicode.com/todos?_limit=5")
        .done(data => {
            data.forEach(task => {
                $("#taskTable").append(`
          <tr data-id="${task.id}">
            <td>${task.id}</td>
            <td>${task.title}</td>
            <td><button class="deleteBtn">Delete</button></td>
          </tr>
        `);
            });
        })
        .always(() => $("#loader").hide());
}

loadTasks();



$("#addTask").on("click", function () {
    const title = $("#taskInput").val();

    $("#loader").show();

    $.post("https://jsonplaceholder.typicode.com/todos", {
        title,
        completed: false
    }).done(task => {
        $("#taskTable").append(`
      <tr data-id="${task.id}">
        <td>${task.id}</td>
        <td>${task.title}</td>
        <td><button class="deleteBtn">Delete</button></td>
      </tr>
    `);
        $("#taskInput").val("");
    }).always(() => $("#loader").hide());
});



$(document).on("click", ".deleteBtn", function () {
    const row = $(this).closest("tr");
    const id = row.data("id");

    $("#loader").show();

    $.ajax({
        url: `https://jsonplaceholder.typicode.com/todos/${id}`,
        type: "DELETE"
    }).done(() => {
        row.remove();
    }).always(() => $("#loader").hide());
});
