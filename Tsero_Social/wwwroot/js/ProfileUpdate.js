function previewImage(event) {
    var input = event.target;
    var imagePreview = document.getElementById('ProfilePreview');
    var ProfilePreviewCont = document.getElementById('ProfilePreviewCont');
    var Profile_Photo_Update = document.getElementById('Profile_Photo_Update');
    var submitBtn = document.getElementById('submitBtn2');
    var saysomething = document.getElementById('saysomething');

    if (input.files && input.files[0]) {
        ProfilePreviewCont.style.height = "0";
        saysomething.style.width = "0";
        saysomething.style.height = "0";
        saysomething.style.borderBottom =  "0px solid black";
        setTimeout(function () {
            var reader = new FileReader();
            reader.onload = function (e) {
                imagePreview.src = e.target.result;
                submitBtn.style.visibility = "visible";
            };
            reader.readAsDataURL(input.files[0]);
            saysomething.style.width = "100%";
            saysomething.style.height = "20px";
            saysomething.style.borderBottom = "1px solid black";
            ProfilePreviewCont.style.height = "300px";
            Profile_Photo_Update.style.paddingBottom = "30px";
        }, 10);

    } else {
        submitBtn.style.visibility = "hidden";
        setTimeout(function () {
            imagePreview.src = '';
            ProfilePreviewCont.style.height = "0";
            saysomething.style.width = "0";
            saysomething.style.height = "0";
            saysomething.style.borderBottom = "0px solid black";
        }, 10);
    }

    ProfilePreviewCont.style.transition = "0.4s ease-in-out";
    imagePreview.style.transition = "0.4s ease-in-out";
}
