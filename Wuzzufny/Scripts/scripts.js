function ShowImagePreview(imageUploader, previewImage, imagePosition) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
            $(imagePosition).hide();
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}