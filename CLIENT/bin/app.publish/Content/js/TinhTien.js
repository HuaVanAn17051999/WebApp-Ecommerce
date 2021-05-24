


$(document).ready(function () {
    var giohang = JSON.parse(window.localStorage.getItem('giohang'));
    var tongtien = 0;
    if (giohang.length > 0) {
        for (i = 0; i < giohang.length; i++) {
            soluong += giohang[i].soluong;
            var SoTienSauKhiGiamGia = giohang[i].price * (100 - giohang[i].giamgia) / 100;
            TongSoTienCuaMotSanPham = giohang[i].soluong * SoTienSauKhiGiamGia;
            tongtien += TongSoTienCuaMotSanPham;
            TongSoTienCuaMotSanPham = TongSoTienCuaMotSanPham.toLocaleString('vi', { style: 'currency', currency: 'VND' });
        }
        tongtien = tongtien.toLocaleString('vi', { style: 'currency', currency: 'VND' });
        $('#TongTienPhaiTra').append(tongtien);
        $('#TongSoLuongSanPham').append(soluong);
    }
});