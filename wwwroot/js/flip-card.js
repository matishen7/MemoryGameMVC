$(document).ready(function () {
    // Handle click event on card cells
    $('#table_board td').click(function () {
        // Toggle the visibility of card images within the clicked cell
        var cardFront = $(this).find('.card-front');
        var cardBack = $(this).find('.card-back');

        cardFront.toggle();
        cardBack.toggle();
    });
});

