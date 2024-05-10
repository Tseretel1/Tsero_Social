function likeFunc(button) {
    button.addEventListener('click', function () {
        var likeSymbol = button.querySelector('.like-symbol');
        var likeCountElement = button.querySelector('.like-count');

        var likeCount = parseInt(likeCountElement.textContent.trim());
        if (likeSymbol.textContent.trim() === '❤️') {
            likeSymbol.textContent = '🤍';
            likeCount--;
        } else {
            likeSymbol.textContent = '❤️';
            likeCount++;
        }
        likeCountElement.textContent = likeCount;
    });
}

function applyEventListenersToNewButtons() {
    var likeButtons = document.querySelectorAll('.Like');
    likeButtons.forEach(function (button) {
        if (!button.hasAttribute('data-event-listener-applied')) {
            console.log('Applying event listener to new button:', button);
            likeFunc(button);
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
