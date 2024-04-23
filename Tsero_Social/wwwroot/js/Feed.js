var loadingInProgress = false;

function scrollFunction() {
    var bottomThreshold = document.body.scrollHeight - window.innerHeight - 50;
    var bottomThreshold2 = document.body.scrollHeight - window.innerHeight - 50;
    var Loader = document.getElementById("loader");
    var LoaderContainer = document.getElementById("LoaderContainer");
    if (window.pageYOffset >= bottomThreshold2 && !loadingInProgress) {
        Loader.style.height = "65px";
        LoaderContainer.style.height = "200px";
        setTimeout(function () {
            Loader.style.height = "0px";
            LoaderContainer.style.height = "0px";
        }, 0);
    }
    if (window.pageYOffset >= bottomThreshold && !loadingInProgress) {
        loadingInProgress = true;

        setTimeout(function () {
            LoaderContainer.style.transition = "0.5s all ease-in-out";
            var currentPage = parseInt(document.getElementById('MyPosts').dataset.page) || 1;
            var xhr = new XMLHttpRequest();
            xhr.open('GET', '/Home/home?page=' + (currentPage + 1), true);
            xhr.onload = function () {
                if (xhr.status >= 200 && xhr.status < 300) {
                    var newPosts = xhr.responseText;
                    var newPostsArray = newPosts.split('<!-- End Post -->');
                    for (var i = 0; i < Math.min(5, newPostsArray.length); i++) {
                        document.getElementById('MyPosts').innerHTML += newPostsArray[i];
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
        }, 500);
    }
}

window.addEventListener("scroll", scrollFunction);