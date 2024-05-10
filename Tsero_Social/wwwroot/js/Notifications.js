function allNotificationDelete() {
    var notificationsParent = document.getElementById("NotificationsParenttttt");
    notificationsParent.style.transition = "0.3s all ease-in-out";
    notificationsParent.style.scale = "0.01";

    setTimeout(function () {
        notificationsParent.style.height = "0";
    }, 700);
    setTimeout(function () {
       notificationsParent.style.display = "none";
    }, 1000);

}

var buttonToDelete = document.getElementById("NotificationAl");
buttonToDelete.addEventListener("click", allNotificationDelete);
