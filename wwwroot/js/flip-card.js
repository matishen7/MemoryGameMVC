$(document).ready(function () {
    var openedCard = null;
    var disabledCards = [];

    // Handle click event on card cells
    $('#table_board td').click(function () {
        var clickedCard = $(this);

        // Check if the clicked card is already disabled
        if (disabledCards.includes(clickedCard)) {
            return; // Ignore the click event for disabled cards
        }

        // Check if a card is already opened
        if (openedCard) {
            // Close the previously opened card
            openedCard.find('.card-front').hide();
            openedCard.find('.card-back').show();
            openedCard = null;
        }

        // Open the clicked card
        clickedCard.find('.card-front').show();
        clickedCard.find('.card-back').hide();

        // Check if this is the first opened card
        if (openedCard === null) {
            openedCard = clickedCard;
        } else {
            // Check if the images of the two cards match
            if (clickedCard.find('.card-back img').attr('src') === openedCard.find('.card-back img').attr('src')) {
                // Disable the matched cards
                disabledCards.push(clickedCard, openedCard);
            } else {
                // If the images don't match, close both cards after a short delay
                setTimeout(function () {
                    clickedCard.find('.card-front').hide();
                    clickedCard.find('.card-back').show();
                    openedCard.find('.card-front').hide();
                    openedCard.find('.card-back').show();
                }, 1000);
            }
            openedCard = null;
        }
    });
});
