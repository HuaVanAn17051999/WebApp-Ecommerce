
$(document).ready(function () {
    var checkout = {
        init: function () {
            checkout.loadTinhThanh();
            checkout.registerEvent();
        },
        registerEvent: function () {
            $('#ddLoadTinhThanh').off('change').on('change', function () {
                var id = $(this).val();
                if (id != '') {
                    checkout.loadQuanHuyen(parseInt(id));
                }
                else {
                    $('#ddLoadQuanHuyen').html('');
                }
            });

            $('#ddLoadQuanHuyen').off('change').on('change', function () {
                var id = $(this).val();
                if (id != '') {
                    checkout.loadXaPhuong(parseInt(id));
                }
                else {
                    $('#ddLoadXaPhuong').html('');
                }
            });
        },
        loadTinhThanh: function () {
            var html = '';
            $.ajax({
                url: '/CheckOut/LoadTinhThanh',
                method: "GET",
                dataType: "JSON",
                success: function (res) {
                    var data = JSON.parse(res);
                    var html = '<option value="" class="textCss color-placeholder" disabled selected hidden>Chọn Tỉnh/Thành phố</option>';
                    $.each(data, function (i, item) {
                        html += '<option class="text-thanhtoan tinhthanh" value="' + item.Id + '">' + item.Name + '</option>'
                    });
                    $('#ddLoadTinhThanh').html(html);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        loadQuanHuyen: function (id) {
            var html = '';
            $.ajax({
                url: '/CheckOut/LoadQuanHuyen',
                method: "POST",
                dataType: "JSON",
                data: { tinhthanhId: id },
                success: function (res) {
                    var data = JSON.parse(res);
                    var html = '<option class="textCss color-placeholder" disabled selected hidden>Chọn Quận/Huyện</option>';
                    $.each(data, function (i, item) {
                        html += '<option class="text-thanhtoan" value="' + item.Id + '">' + item.Name + '</option>'
                    });
                    $('#ddLoadQuanHuyen').html(html);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        },
        loadXaPhuong: function (id) {
            var html = '';
            $.ajax({
                url: '/CheckOut/LoadXaPhuong',
                method: "POST",
                dataType: "JSON",
                data: { quanhuyenId: id },
                success: function (res) {
                    var data = JSON.parse(res);
                    var html = '<option class="textCss color-placeholder" disabled selected hidden>Chọn Phường/Xã</option>';
                    $.each(data, function (i, item) {
                        html += '<option class="text-thanhtoan" value="' + item.Id + '">' + item.Name + '</option>'
                    });
                    $('#ddLoadXaPhuong').html(html);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    }
    checkout.init();

    $('#xacnhan').on('click', function () {
        var userId = parseInt($('#userId').val());
        var hoten = $('#hoten').val();
        var sdt = parseInt($('#sdt').val());
        var diachi = $('#diachi').val();
        var idXaPhuong = parseInt($('#ddLoadXaPhuong').val());

        var ThongTinThanhToanModel = { userId, hoten, sdt, diachi, idXaPhuong };

        $.ajax({
            url: '../CheckOut/XacNhan',
            method: "POST",
            dataType: "JSON",
            data: ThongTinThanhToanModel,
            success: function () {
                alert('Thông tin của bạn đã được chúng tôi ghi lại !!!');
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});