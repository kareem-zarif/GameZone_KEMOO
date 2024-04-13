$(document).ready(function () {
    $('#Cover').on("change", function () {
        $('#PreviewImg').attr('src', window.URL.createObjectURL(this.files[0])).removeClass('d-none')
    })
});