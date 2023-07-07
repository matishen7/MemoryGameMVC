$(document).ready(function () {
    $(".game-cell").click(function () {
        var clickedCell = $(this);
        var id = clickedCell.data("id");

        // Get the image URL from the data attribute
        //var cellImage = clickedCell.data("image");

        // Make an AJAX POST request to the controller with the image URL
        $.ajax({
            type: "POST",
            url: "/Board/FlipCard",
            data: {
                id: id
            },
            success: function (response) {
                // Handle the response from the server
                if (response.match == true) {
                    // The image matches
                    console.log("Image matches!");
                } else {
                    // The image doesn't match
                    console.log("Image doesn't match!");
                }
            },
            error: function (error) {
                // Handle any error that might occur during the AJAX request
                console.error("Error sending data:", error);
            }
        });

        // Show the front image of the clicked cell
        //clickedCell.find(".card-back").hide();
    });
});
