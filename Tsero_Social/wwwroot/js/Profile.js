function editprofile() {
    var EditButton = document.getElementById("editbutton");
    var ChangeButtons = document.getElementById("ChangeButtonsParent");
    ChangeButtons.style.width = "200px";
    EditButton.style.display = "none";
}

document.getElementById("editbutton").addEventListener("click", editprofile);

function editprofile2() {
    var EditButton = document.getElementById("editbutton");
    var ChangeButtons = document.getElementById("ChangeButtonsParent");
    ChangeButtons.style.width = "0";
    EditButton.style.display = "flex";
}

document.getElementById("Xbutton").addEventListener("click", editprofile2);
