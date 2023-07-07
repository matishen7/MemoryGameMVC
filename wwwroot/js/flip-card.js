$(document).ready(function () {
    var openedCard = null;
    var disabledCards = [];

    // Handle click event on card cells
    $('#table_board td').click(function () {
        var clickedCard = $(this);
        if (clickedCard.hasClass('matched disabled')) {
            event.preventDefault(); // Prevent the click event from being triggered on disabled cards
            openedCard = null;
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
                clickedCard.addClass('matched disabled');
                openedCard.addClass('matched disabled');
                disabledCards.push(clickedCard, openedCard);
                openedCard = null;
            } else {
                // If the images don't match, close both cards after a short delay
                var previouslyOpenedCard = openedCard; // Store reference to the previously opened card
                openedCard = null; // Reset the openedCard variable
                setTimeout(function () {
                    clickedCard.find('.card-front').hide();
                    clickedCard.find('.card-back').show();
                    clickedCard.removeClass('opened');
                    previouslyOpenedCard.find('.card-front').hide();
                    previouslyOpenedCard.find('.card-back').show();
                    previouslyOpenedCard.removeClass('opened');
                }, 2000); // Delay of 3 seconds (3000 milliseconds)
            }
        }
    });
});
