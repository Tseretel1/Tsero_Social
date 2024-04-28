function previewImage(event) {
    var input = event.target;
    var centerUpload = document.getElementById('centerUpload');
    centerUpload.style.backgroundSize = "cover";
    centerUpload.style.backgroundPosition = "center";
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            centerUpload.style.background = "url('@arget.result)') center/cover";
        };
        reader.readAsDataURL(input.files[0]);
    }
}