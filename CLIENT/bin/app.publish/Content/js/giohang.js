
$(document).ready(function () {
    var giohang = JSON.parse(window.localStorage.getItem('giohang'));
    var soluong = 0;
    var tongtien = 0;

    if (localStorage.getItem("giohang") === null) {
        $('.cart_count').append(0);
        $('.cart_price').append("0 đ");
    }
    else {
        for (i in giohang) {
            soluong += parseInt(giohang[i].soluong);
            var SoTienSauKhiGiamGia = giohang[i].price * (100 - giohang[i].giamgia) / 100;
            TongSoTienCuaMotSanPham = giohang[i].soluong * SoTienSauKhiGiamGia;
            tongtien += TongSoTienCuaMotSanPham;
            console.log(tongtien);
        }
        tongtien = tongtien.toLocaleString('vi', { style: 'currency', currency: 'VND' });
        $('.cart_count').append(soluong);
        console.log(soluong);
        $('.cart_price').append(tongtien);
    }
});