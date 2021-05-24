
$(document).ready(function () {
    var sanPhamDaXem = JSON.parse(localStorage.getItem("SanPhamDaXem"));
    for (i in sanPhamDaXem) {
        var gia = sanPhamDaXem[i].price;
        gia = gia.toLocaleString('vi', { style: 'currency', currency: 'VND' });
        var SoTienSauKhiGiamGia = sanPhamDaXem[i].price * (100 - sanPhamDaXem[i].giamgia) / 100;
        SoTienSauKhiGiamGia = SoTienSauKhiGiamGia.toLocaleString('vi', { style: 'currency', currency: 'VND' });
        $port = window.location.port;
        $hostName = 'http://' + window.location.hostname + ($port != null ? ":" + $port : "");
        var img = $hostName + "/Content/UploadFile/" + sanPhamDaXem[i].anhSP;
        $('#sanPhamBanDaXem').append(
                '<div class="col-lg-3 col-md-6 mb-4 mb-lg-0">'
                    + '<a href ="/chi-tiet-san-pham/' + sanPhamDaXem[i].seotitle +'/'+ sanPhamDaXem[i].id +'" >'
                        + '<div class= "card rounded shadow-sm border-0 mb-3">'
                                + '<div class="card-body p-4">'
                                    + '<img src="' + img + '" alt="" class="img-fluid d-block mx-auto mb-3">'
                                    + '<h5> <a href="#" class="text-dark text ten">' + sanPhamDaXem[i].ten + '</a></h5>'
                                    + '    <div>'
                                    + '         <p class="d-flex text mb-0">'
                                    + '            <span class="text gia">' + SoTienSauKhiGiamGia + '</span>'
                                    + '            <span class="text-danger ml-2 text">- '+ sanPhamDaXem[i].giamgia +'%</span>'
                                    + '         </p>'
                                    +'          <p class="text sotien">'+gia+'</p>'
                                    + '    </div>'
                                    + '  <ul class="list-inline small">'
                                    + '     <li class="list-inline-item m-0"><i class="fa fa-star text-success"></i></li>'
                                    + '     <li class="list-inline-item m-0"><i class="fa fa-star text-success"></i></li>'
                                    + '     <li class="list-inline-item m-0"><i class="fa fa-star text-success"></i></li>'
                                    + '     <li class="list-inline-item m-0"><i class="fa fa-star text-success"></i></li>'
                                    + '     <li class="list-inline-item m-0"><i class="fa fa-star-o text-success"></i></li>'
                                    + '  </ul>'
                                + '</div>'
                         +'</div >'
                      + '</a >'
                +'</div>'
            )
    }
    $(".regulars").slick({
        dots: true,
        infinite: true,
        slidesToShow: 5,
        slidesToScroll: 5
    });
});
