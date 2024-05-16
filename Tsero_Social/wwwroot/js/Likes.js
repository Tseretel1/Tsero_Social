function likeFunc(button) {
    button.addEventListener('click', function () {
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

window.addEventListener('load', function () {
    console.log('Document loaded');

    var likeButtons = document.querySelectorAll('.Like');
    likeButtons.forEach(function (button) {
        likeFunc(button);
    });
});
