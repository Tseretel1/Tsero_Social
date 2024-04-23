let bool = true;
var flipbt = document.querySelector(".flip-btn");
var donthave = document.querySelector(".donthave");
var card = document.getElementById("card");
function reglog() {
    var login = document.getElementById("login");
    var register = document.getElementById("register");
    setTimeout(function () {
        card.style.opacity = "0";
    }, 0);
    setTimeout(function () {
        card.style.opacity = "1";
    }, 200);
    if (bool) {
        setTimeout(function () {
            login.style.display = "none";
            register.style.display = "flex";
            bool = false;
            flipbt.innerHTML = "Switch to Login";
            donthave.innerHTML = "Already Registered?";
        }, 200);
    } else {
        setTimeout(function () {
            login.style.display = "flex";
            register.style.display = "none";
            bool = true;
            flipbt.innerHTML = "Switch to Register";
            donthave.innerHTML = "Dont have an account?";
        }, 200);
    }
    card.style.transition = "0.2s all ease-in-out";
}
flipbt.addEventListener("click", reglog);

function Okbutton() {
    var modal = document.getElementById("myModal");
    modal.style.display = "none";   
}
document.getElementById("OkBUtton").addEventListener("click", Okbutton);
document.getElementById("myModal").addEventListener("click", Okbutton);

