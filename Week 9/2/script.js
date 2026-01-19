$("#saveBtn").on("click", function () {
    const formData = $("#profileForm").serializeArray();

    const jsonData = {};

    formData.forEach(item => {
        if (jsonData[item.name]) {
            // Handle multiple values (checkboxes)
            if (!Array.isArray(jsonData[item.name])) {
                jsonData[item.name] = [jsonData[item.name]];
            }
            jsonData[item.name].push(item.value);
        } else {
            jsonData[item.name] = item.value;
        }
    });

    $("#output").text(JSON.stringify(jsonData, null, 2));
});
