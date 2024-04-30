function LikeFunc(button) {
    button.addEventListener('click', function () {
        var likeSymbol = button.textContent.trim();
        var likeCount = parseInt(button.textContent.trim().split(' ')[1]);
        if (likeSymbol.includes('❤️')) {
            likeSymbol = '🤍';
            likeCount--;
        } else {
            likeSymbol = '❤️';
            likeCount++;
        }
        button.textContent = likeSymbol + ' ' + likeCount;
    });
}

function applyEventListenersToNewButtons() {
    var likeButtons = document.querySelectorAll('.Like');
    likeButtons.forEach(function (button) {
        if (!button.hasAttribute('data-event-listener-applied')) {
            console.log('Applying event listener to new button:', button);
            LikeFunc(button);
            button.setAttribute('data-event-listener-applied', true);
        }
    });
}

window.addEventListener('load', function () {
    console.log('Document loaded');
    applyEventListenersToNewButtons();

    var observer = new MutationObserver(function (mutations) {
        console.log('Mutation detected:', mutations);
        applyEventListenersToNewButtons();
    });

    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
});
