function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var submitBtn = document.getElementById('submitBtn');

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            imagePreview.src = '';
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

var photostatus = false;
function previewImage(input) {
    var imagePreview = document.getElementById('ProfilePreview2');
    var PhotoContHeight = document.getElementById('photopreviewcontainer');
    var PhotoHeight = imagePreview.clientHeight;

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


function publishclick() {
    var publishbtn = document.getElementById("HidePublishButtton");
    var contclick = document.getElementById("PostPublish");
    var parent = document.getElementById("PostParent");

    publishbtn.style.transition = "0.3s all ease-in-out";
    contclick.style.height = "700px";
    contclick.style.width = "clamp(280px, 75%, 900px)";
    publishbtn.style.opacity = "1";
    parent.style.justifyContent = "center";
}
document.getElementById("WritePostText").addEventListener("click", publishclick);


function publishclick2() {
    var publishbtn = document.getElementById("HidePublishButtton");
    var contclick = document.getElementById("PostPublish");
    var parent = document.getElementById("PostParent");

    publishbtn.style.transition = "0.3s all ease-in-out";
    contclick.style.height = "0px";
    publishbtn.style.opacity = "1";
    contclick.style.width = "60%";
    parent.style.justifyContent = "flex-start";
}
document.getElementById("HidePublishButtton").addEventListener("click", publishclick2);