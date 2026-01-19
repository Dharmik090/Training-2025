$("#loadDashboard").on("click", function () {
    
    $("#dashboard").html("Loading...");
    $("#error").empty();

    const userRequest = $.get("https://jsonplaceholder.typicode.com/users/1");
    const postsRequest = $.get("https://jsonplaceholder.typicode.com/posts?userId=1");

    $.when(userRequest, postsRequest)
        .done((userRes, postsRes) => {
            const user = userRes[0];
            const posts = postsRes[0];

            let html = `<h2>${user.name}</h2><ul>`;
            posts.forEach(p => {
                html += `<li>${p.title}</li>`;
            });

            html += "</ul>";

            $("#dashboard").html(html);
        })
        .fail(() => {
            $("#error").text("Failed to load dashboard data.");
            $("#dashboard").empty();
        });
});
