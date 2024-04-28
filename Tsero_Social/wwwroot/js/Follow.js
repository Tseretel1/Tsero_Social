function FollowFunc(button) {
    button.addEventListener('click', function () {
        var buttonText = button.textContent.trim();
        if (buttonText === 'Following') {
            button.textContent = 'Follow';
        } else {
            button.textContent = 'Following';
        }
    });
}

function applyEventListenersToNewButtons() {
    var followButtons = document.querySelectorAll('.Follow');
    followButtons.forEach(function (button) {
        if (!button.hasAttribute('data-event-listener-applied')) {
            FollowFunc(button);
            button.setAttribute('data-event-listener-applied', true);
        }
    });
}

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
