function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var ProfilePreviewCont = document.getElementById('ProfilePreviewCont');
    var submitBtn = document.getElementById('submitBtn2');
    imagePreview.style.opacity = "0";
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            imagePreview.src = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
        setTimeout(function () {
            imagePreview.style.opacity = "1";
        }, 10);

    } else {
        imagePreview.style.opacity = "0";
        setTimeout(function () {
            imagePreview.src = '';
        }, 10);
    }

    ProfilePreviewCont.style.transition = "0.4s ease-in-out";
    imagePreview.style.transition = "0.4s ease-in-out";
}
function Submit() {
    var imagePreview = document.getElementById('ProfilePreview');
    imagePreview.src = '';
}
var submitBtn = document.getElementById('submitBtn2');
submitBtn.addEventListener("click", Submit);