$(document).ready(function () {
    var openedCard = null;
    var disabledCards = [];

    // Handle click event on card cells
    $('#table_board td').click(function () {
        var clickedCard = $(this);

        // Check if the clicked card is disabled (already matched)
        if (clickedCard.hasClass('matched') || clickedCard.hasClass('opened')) {
            return; // Ignore the click event for disabled cards
        }

        // Open the clicked card
        clickedCard.find('.card-front').show();
        clickedCard.find('.card-back').hide();
        clickedCard.addClass('opened');

        // Check if this is the first opened card
        if (openedCard === null) {
            openedCard = clickedCard;
        } else {
            // Check if the images of the two cards match
            if (clickedCard.data('image') === openedCard.data('image')) {
                // Disable the matched cards
                disabledCards.push(clickedCard, openedCard);
                clickedCard.addClass('matched');
                openedCard.addClass('matched');
            } else {
                // If the images don't match, close both cards after a short delay
                setTimeout(function () {
                    clickedCard.find('.card-front').hide();
                    clickedCard.find('.card-back').show();
                    clickedCard.removeClass('opened');
                    openedCard.find('.card-front').hide();
                    openedCard.find('.card-back').show();
                    openedCard.removeClass('opened');
                    openedCard = null; // Reset the openedCard variable
                }, 3000); // Delay of 3 seconds (3000 milliseconds)
            }
        }
    });
});