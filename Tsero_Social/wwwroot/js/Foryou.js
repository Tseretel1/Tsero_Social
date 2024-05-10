var loadingInProgress = false;

function scrollFunction() {
    var bottomThreshold = document.body.scrollHeight - window.innerHeight - 50;
    var bottomThreshold2 = document.body.scrollHeight - window.innerHeight - 50;
    if (window.pageYOffset >= bottomThreshold2 && !loadingInProgress) {
        setTimeout(function () {
        }, 0);
    }
    if (window.pageYOffset >= bottomThreshold && !loadingInProgress) {
        loadingInProgress = true;
        var currentPage = parseInt(document.getElementById('MyPosts').dataset.page) || 1;
        var xhr = new XMLHttpRequest();
        xhr.open('GET', '/Home/Foryou?page=' + (currentPage + 1), true);
        xhr.onload = function () {
            if (xhr.status >= 200 && xhr.status < 300) {
                var newPosts = xhr.responseText;
                var newPostsArray = newPosts.split('<!-- End Post -->');
                for (var i = 0; i < Math.min(5, newPostsArray.length); i++) {
                    if (newPostsArray.length > 0) {
                        document.getElementById('MyPosts').innerHTML += newPostsArray[i];
                    }
                }
                document.getElementById('MyPosts').dataset.page = currentPage + 1;
            } else {
                console.error('Error fetching more posts:', xhr.statusText);
            }
        };
        xhr.onerror = function () {
            console.error('Error fetching more posts:', xhr.statusText);
        };
        xhr.onloadend = function () {
            loadingInProgress = false;
        };
        xhr.send();
    }
}

window.addEventListener("scroll", scrollFunction);