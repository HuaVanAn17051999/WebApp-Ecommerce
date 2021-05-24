
$(document).ready(function () {
    $('#exampleCheck').on('click', function () {
        let checkState = $("#exampleCheck").is(":checked") ? "true" : "false";
        if (checkState) {
            $('#capnhat').on('click', function () {
                $('.formPassword').validate({
                    onfocusout: false,
                    onkeyup: false,
                    onclick: false,
                    rules: {
                        "MatKhauCu": {
                            required: true
                        },
                        "MatKhau": {
                            required: true
                            //pattern: "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"
                        },
                        "XacNhanMatKhau": {
                            required: true,
                            equalTo: "#MatKhau",
                        }
                    },
                    messages: {
                        "MatKhauCu": {
                            required: "Mật khẩu củ không được để trống !!!",
                        },
                        "MatKhau": {
                            required: "Mật khẩu mới không được để trống !!!"
                            //pattern: "Mật khẩu chứa ít nhất một chứ cái viết hoa, ít nhất một chữ viết thường, ít nhất một chữ số, ít nhất một ký tự đặc biệt .Độ dài tối thiểu 8 !!!"
                        },
                        "XacNhanMatKhau": {
                            required: "Xác nhận mật khẩu không được để trống !!!",
                            equalTo: "Xác nhận mật khẩu không đúng !!!"
                        }
                    }
                });
            });
        }

        $('#errorPassWordCu').val() === '' ? $('#errorPassWordCu').hide() : $('#errorPassWordCu').show();
        $('#errorPassWordMoi').val() === '' ? $('#errorPassWordMoi').hide() : $('#errorPassWordMoi').show();
        $('#errorPassWordXacNhan').val() === '' ? $('#errorPassWordXacNhan').hide() : $('#errorPassWordXacNhan').show();
 
    });
    $('.ThongBaoThanhCong').show(0).delay(5000).fadeOut();
});