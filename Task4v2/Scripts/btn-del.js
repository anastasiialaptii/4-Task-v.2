$(document).ready(function () {
    $('.popup-link').magnificPopup({
        type: 'inline',
        midClick: true
    });
    $(document).on('click', '.popup-ok', function (e) {
        e.preventDefault();
        $.magnificPopup.close();
        document.getElementById('form1').submit();
    });
    $(document).on('click', '.popup-no', function (e) {
        e.preventDefault();
        $.magnificPopup.close();
        document.getElementById('Close').click();
    });
});