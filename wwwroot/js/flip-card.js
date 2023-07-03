$(document).ready(function () {
    var isOpened = [];

    // Initialize isOpened array with false values for each card
    $('#table_board td').each(function () {
        isOpened.push(false);
    });

    // Handle click event on card cells
    $('#table_board td').click(function () {
        var cardIndex = $(this).index();

        // Check if the card is already opened
        if (isOpened[cardIndex]) {
            // Close the card by showing the front image and hiding the back image
            $(this).find('.card-front').hide();
            $(this).find('.card-back').show();
            isOpened[cardIndex] = false;
        } else {
            // Open the card by hiding the front image and showing the back image
            $(this).find('.card-front').show();
            $(this).find('.card-back').hide();
            isOpened[cardIndex] = true;

            // Close any other opened cards
            $('#table_board td').not($(this)).each(function () {
                $(this).find('.card-front').hide();
                $(this).find('.card-back').show();
                isOpened[$(this).index()] = false;
            });
        }
    });
});
