function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var submitBtn = document.getElementById('submitBtn');

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            imagePreview.src = e.target.result;
            imagePreview.style.display = 'block';
        };
        reader.readAsDataURL(input.files[0]);
    } else {
        imagePreview.src = '';
        imagePreview.style.display = 'none';
    }
}

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
