function FollowFunc(button) {
    button.addEventListener('click', function () {
        navigator.vibrate(100);

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



function likeFunc(button) {
    button.addEventListener('click', function () {
        navigator.vibrate(100);

        var likeSymbol = button.querySelector('i');
        var likeCountElement = button.querySelector('.like-count');

        var likeCount = parseInt(likeCountElement.textContent.trim());
        if (likeSymbol.classList.contains('fas')) {
            likeSymbol.classList.remove('fas');
            likeSymbol.classList.add('far');
            likeSymbol.style.color = 'white';
            likeCount--;
        } else {
            likeSymbol.classList.remove('far');
            likeSymbol.classList.add('fas');
            likeSymbol.style.color = 'red';
            likeCount++;
        }
        likeCountElement.textContent = likeCount;
    });
}

function applyEventListenersToNewLikeButtons() {
    var likeButtons = document.querySelectorAll('.Like');
    likeButtons.forEach(function (button) {
        if (!button.hasAttribute('data-like-event-listener-applied')) {
            likeFunc(button);
            button.setAttribute('data-like-event-listener-applied', true);
        }
    });
}

window.addEventListener('load', function () {
    console.log('Document loaded');

    applyEventListenersToNewLikeButtons();

    var observer = new MutationObserver(function () {
        applyEventListenersToNewLikeButtons();
    });

    observer.observe(document.body, {
        childList: true,
        subtree: true
    });
});

