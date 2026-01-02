// // Select elements
// var button = document.getElementById("btn");
// var text = document.getElementById("text");

// // Add event listener
// button.addEventListener("click", function () {
//     text.innerText = "Text Changed!";
//     text.classList.toggle("highlight");
// });


$(document).ready(function () {
    $("#btn").click(function () {
        $("#text").text("Text Changed!");
        $("#text").toggleClass("highlight");
    });
});



$(document).ready(function () {

    // text()
    $("#btnText").click(function () {
        $("#para").text("Text changed using text()");
    });


    // html()
    $("#btnHtml").click(function () {
        $("#para").html("<b>Bold HTML using html()</b>");
    });


    // append() + prepend()
    $("#btnAdd").click(function () {
        $("#container")
            .prepend("<p>Prepended paragraph</p>")
            .append("<p>Appended paragraph</p>");
    });


    // addClass(), removeClass(), toggleClass(), hasClass()
    $("#btnClass").click(function () {
        $("#para").toggleClass("highlight");

        if ($("#para").hasClass("highlight")) {
            console.log("Highlight class added");
        } else {
            console.log("Highlight class removed");
        }
    });


    // css()
    $("#btnCss").click(function () {
        $("#container").css({
            "background-color": "gray",
            "border-color": "blue",
            "color": "white"
        });
    });


    // attr() and prop()
    $("#btnAttr").click(function () {
        var value = $("#name").val();

        $("#name")
            .attr("placeholder", "Hello " + value)
            .prop("disabled", true);
    });


    // remove() and empty()
    $("#btnRemove").click(function () {
        $("#para").remove();        // removes element completely
        // $("#container").empty(); // removes only child content
    });


    // Custom Events
    $(window).on("customEvent", function () {
        alert("Custom event triggered!");
    });

    // Trigger custom event after 3 seconds
    setTimeout(function () {
        $(window).trigger("customEvent");
    }, 3000);

});


// Custom events with multiple handlers
// $("p").on({
//     mouseenter: function () {
//         $(this).css("background-color", "lightgray");
//     },
//     mouseleave: function () {
//         $(this).css("background-color", "lightblue");
//     },
//     click: function () {
//         $(this).css("background-color", "yellow");
//     }
// });

