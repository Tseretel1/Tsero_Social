
function BurgerMenuShow() {
    var HeaderShow = document.getElementById("HeaderBurgerContainer");
    var Menu = document.getElementById("HeaderBurger");
    var Navigators = document.querySelectorAll(".NavBurger");
    HeaderShow.style.transition = "0.3s all ease-in-out";
    Menu.style.transition = "0.3s all ease-in-out";

    HeaderShow.style.opacity = "0"
    HeaderShow.style.display = "flex";
    setTimeout(() => {
        Menu.style.width = "50%";
        HeaderShow.style.opacity = "1"
    }, 100);
    setTimeout(() => {
        Navigators.forEach(function (nav) {
            nav.style.opacity = "1";
        });
    }, 200);
}

var BurgerShowButton = document.getElementById("BurgerButton");
BurgerShowButton.addEventListener("click", BurgerMenuShow);


function BurgerMenuDelete() {
    var HeaderShow = document.getElementById("HeaderBurgerContainer");
    var Menu = document.getElementById("HeaderBurger");
    var Navigators = document.querySelectorAll(".NavBurger");
    HeaderShow.style.transition = "0.3s all ease-in-out";
    Menu.style.transition = "0.3s all ease-in-out";

    HeaderShow.style.opacity = "0"
    Menu.style.width = "0%";
    setTimeout(() => {
        HeaderShow.style.display = "none";
    }, 300);
    setTimeout(() => {
        Navigators.forEach(function (nav) {
            nav.style.opacity = "0";
        });
    }, 100);
}

var BurgerShowButtonn = document.getElementById("BurgerButton2");
BurgerShowButtonn.addEventListener("click", BurgerMenuDelete);