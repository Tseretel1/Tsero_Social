function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var submitBtn = document.getElementById('submitBtn');

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            imagePreview.src = e.target.result;
            imagePreview.style.display = 'flex';
            document.getElementById("Post").style.display = "none";
            hiddenn = true;
        };
        reader.readAsDataURL(input.files[0]);
    } else {
        imagePreview.src = '';
        imagePreview.style.display = 'none';
    }
}


var hidden = true;
function UpdateProfile() {
    if (hidden == true) {
        document.getElementById("formhidden").style.display = "flex";
        hidden = false;
    }
    else if (hidden == false){
        document.getElementById("formhidden").style.display = "none";
        hidden = true;
    }
}
document.getElementById("changephoto").addEventListener("click", UpdateProfile);
var hiddenn = false;
function WritePost() {
    if (hiddenn == true) {
        document.getElementById("Post").style.display = "flex";
        hiddenn = false;
    }
    else if (hidden == false) {
        document.getElementById("Post").style.display = "none";
        hiddenn = true;
    }
}
document.getElementById("writepost").addEventListener("click", UpdateProfile);
