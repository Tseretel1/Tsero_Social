
//Follower Container Hide//
function FollowerWindowClose() {
    var WindowToClose = document.getElementById("FollowerWinodw");
    WindowToClose.style.transition = "0.3s all ease-in-out";
    WindowToClose.style.scale = "0.01";
    setTimeout(function () {
        WindowToClose.style.display = "none";
    }, 300);
}
var CloseButton = document.getElementById("FollowerXbutton");
CloseButton.addEventListener("click", FollowerWindowClose);

//Follower Container Show//
function FollowerWindowOpen() {
    var WindowToClose = document.getElementById("FollowerWinodw");
    WindowToClose.style.transition = "0.3s all ease-in-out";
    WindowToClose.style.display = "flex";
    WindowToClose.style.scale = "0.01";
    setTimeout(function () {
        WindowToClose.style.scale = "1";
    }, 0);
}
var FollowerButton = document.getElementById("FollowerButton");
FollowerButton.addEventListener("click", FollowerWindowOpen);



//FollowING Container Hide//
function FollowingWindowClose() {
    var WindowToClose = document.getElementById("FollowINGWinodw");
    WindowToClose.style.transition = "0.3s all ease-in-out";
    WindowToClose.style.scale = "0.01";
    setTimeout(function () {
        WindowToClose.style.display = "none";
    }, 300);
}
var FollowingClose = document.getElementById("FollowINGXbutton");
FollowingClose.addEventListener("click", FollowingWindowClose);

//FollowING Container Show//
function FollowingWindowShow() {
    var WindowToClose = document.getElementById("FollowINGWinodw");
    WindowToClose.style.transition = "0.3s all ease-in-out";
    WindowToClose.style.display = "flex";
    WindowToClose.style.scale = "0.01";
    setTimeout(function () {
        WindowToClose.style.scale = "1";
    }, 0);
}
var FollowingShow = document.getElementById("FollowINGButton");
FollowingShow.addEventListener("click", FollowingWindowShow);


//Follower Remove//
(function () {
    function toggleButtonText(event) {
        var removeButton = event.target;
        var buttonText = removeButton.textContent;
        if (buttonText.includes("Undo")) {
            removeButton.textContent = "Remove";
        } else if (buttonText.includes("Remove")) {
            removeButton.textContent = "Undo";
        }
    }

    var removeButtons = document.querySelectorAll(".DeletFollowerBUtton");
    removeButtons.forEach(function (button) {
        button.addEventListener("click", toggleButtonText);
    });
})();


//FollowING Remove//
(function () {
    function toggleButtonText(event) {
        var button = event.target;
        var buttonText = button.textContent;
        if (buttonText.includes("Following")) {
            button.textContent = "Follow";
        } else if (buttonText.includes("Follow")) {
            button.textContent = "Following";
        }
    }

    var followButtons = document.querySelectorAll(".RemoveFollowingBUtton");
    followButtons.forEach(function (button) {
        button.addEventListener("click", toggleButtonText);
    });
})();
