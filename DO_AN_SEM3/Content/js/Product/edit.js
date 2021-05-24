


$(document).ready(function () {
    $('#CapNhat').on('click', function () {
        $.ajax({
            type: "POST",
            url: '/Product/Edit',
            success: function (res) {
                console.log(res);
                if (res.success == true) {
                    window.history.back();
                }
            }
        });
    });
    $('#TaoMoi').on('click', function () {
        $.ajax({
            type: "POST",
            url: '/Product/Create',
            success: function (res) {
                console.log(res);
                if (res.success == true) {
                    window.history.back();
                }
            }
        });
    });

});