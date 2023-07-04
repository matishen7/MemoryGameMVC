$(document).ready(function () {
    var firstCell = null;

    $(".game-cell").click(function () {
        var clickedCell = $(this);

        // If it's the first cell being clicked, store the reference and show the front image
        if (firstCell === null) {
            firstCell = clickedCell;
            clickedCell.find(".card-back").hide();
        } else {
            // It's the second cell being clicked
            var firstCellRow = firstCell.data("row");
            var firstCellCol = firstCell.data("col");
            var secondCellRow = clickedCell.data("row");
            var secondCellCol = clickedCell.data("col");

            // Get the image URLs from the data attributes
            var firstCellImage = firstCell.data("image");
            var secondCellImage = clickedCell.data("image");

            // Make an AJAX POST request to the controller with the image URLs
            $.ajax({
                type: "POST",
                url: "/Home/ClickCard",
                data: {
                    firstImage: firstCellImage,
                    secondImage: secondCellImage
                },
                success: function (response) {
                    // Handle the response from the server
                    if (response.match) {
                        // The images match
                        console.log("Images match!");
                    } else {
                        // The images don't match
                        console.log("Images don't match!");
                    }
                },
                error: function (error) {
                    // Handle any error that might occur during the AJAX request
                    console.error("Error sending data:", error);
                },
                complete: function () {
                    // Reset the first cell reference after processing the response
                    firstCell = null;
                }
            });

            // Show the front image of the second cell
            clickedCell.find(".card-back").hide();
        }
    });
});