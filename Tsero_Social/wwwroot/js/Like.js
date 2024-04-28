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
            LikeFunc(button);
            button.setAttribute('data-event-listener-applied', true);
        }
    });
}
var likeButtons = document.querySelectorAll('.Like');
likeButtons.forEach(function (button) {
    LikeFunc(button);
    button.setAttribute('data-event-listener-applied', true);
});

window.addEventListener('load', function () {
    applyEventListenersToNewButtons();
    var observer = new MutationObserver(function () {
        applyEventListenersToNewButtons();
    });
    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
});
