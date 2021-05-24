

$(document).ready(function () {
    $('.GiamSoLuong').on('click', function () {
        var soluong = $('#soluong').val();
        soluong--;
        $('#soluong').val(soluong);
    });
    $('.TangSoLuong').on('click', function () {
        var soluong = $('#soluong').val();
        soluong++;
        $('#soluong').val(soluong);
    });
});
