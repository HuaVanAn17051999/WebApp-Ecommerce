

$(document).ready(function () {
    var giohang = JSON.parse(window.localStorage.getItem('giohang'));
    $port = window.location.port;
    $hostName = 'http://' + window.location.hostname + ($port != null ? ":" + $port : "");
    var tongtien = 0;
    if (giohang.length > 0) {
        for (i = 0; i < giohang.length; i++) {

            var SoTienSauKhiGiamGia = giohang[i].price * (100 - giohang[i].giamgia) / 100;
            TongSoTienCuaMotSanPham = giohang[i].soluong * SoTienSauKhiGiamGia;
            tongtien += TongSoTienCuaMotSanPham;
            TongSoTienCuaMotSanPham = TongSoTienCuaMotSanPham.toLocaleString('vi', { style: 'currency', currency: 'VND' });

            $('.giohang').append(
                '<div class="d-flex" style="padding-bottom: 5px">'
                + '   <div class="col-md-10">'
                + '       <div style="display: flex">'
                + '          <div style="padding-right: 10px"> x' + giohang[i].soluong + '</div>'
                + '          <div>'
                + giohang[i].ten
                + '      </div>'
                + '       </div>'

                + '   </div>'
                + '  <div class="col-md-2">'
                + '      <div>'
                + TongSoTienCuaMotSanPham
                + '    </div>'
                + '     </div>'
                + ' </div>'
            )
        }
        tongtien = tongtien.toLocaleString('vi', { style: 'currency', currency: 'VND' });
        $('.tongtien').append(tongtien);
    }

    $('#TienHanhMuaHang').on('click', function () {
        let diachiId = $('#diachiId').val();
        console.log(diachiId);
        var OrderDetails = [];
        for (j in giohang) {
            var sotienSauKhiGiamGia = giohang[j].price * (100 - giohang[j].giamgia) / 100;
            var listProduct = { "ProductId": giohang[j].id, "Quantity": giohang[j].soluong, "Price": sotienSauKhiGiamGia };
            OrderDetails.push(listProduct);
        }
        var TienHanhDatMuaModel = { To: $('#email').val(), Subject: 'ShopAnHua', Body: 'Bạn vui lòng chuẩn bị số tiền ' + tongtien + ' trước khi nhân hàng !', OrderId: diachiId, OrderDetails: OrderDetails }
        $.ajax({
            url: "/TienHanhDatMua/Index",
            type: "POST",
            dataType: "JSON",
            data: TienHanhDatMuaModel,
            success: function (res) {
                if (res.success == true) {
                    localStorage.removeItem("giohang");
                    swal("Thành công!", "Cảm ơn bạn đã ghé Shop Mr.An!", "success");
                    $('.swal-button-container').on('click', function () {
                        window.location.assign('/');
                    });
                }
            }
        });
    });
   
});