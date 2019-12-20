$('#basicModal').on('shown.bs.modal', function (e) {
    $("#modal-content").load("/Clientes/ElegirCliente");
});
//<a href="#" class="btn btn-primary btn-large" data-toggle="modal" data-target="#basicModal">
//    +
//                    </a>
//@*//MODAL TRAER CLIENTE*@
//    <div class="modal fade bd-example-modal-lg" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
//        <div class="modal-dialog modal-lg">
//            <div class="modal-content">
//                <div class="modal-header">
//                    <h4 class="modal-title" id="myModalLabel">Nuevo Repuesto</h4>
//                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
//                        <span aria-hidden="true">×</span>
//                    </button>
//                </div>
//                <div class="modal-body">
//                    <div id="modal-content">
//                        cargando...
//                </div>
//                </div>
//                <div class="modal-footer">
//                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
//                    @*<button type="button" class="btn btn-primary">Save changes</button>*@
//            </div>
//            </div>
//        </div>
////    </div>
//<script src="~/Scripts/ModalScripts/ModalScripts.js"></script>
    $("#searchInput").autocomplete({
        source: function (request, response) {
        $.ajax({
            url: '/Ingresos/GetSearchValue/' ,
            dataType: "json",
            data: { search: $("#searchInput").val() },
            success: function (data) {
                response($.map(data, function (item) {
                    return { label: item.Name, value: item.Name };
                }));
            },
            error: function (xhr, status, error) {
                alert("Error");
            }
        });
    }
});

//Autocompletar marca en ingreso create 
$(function () {
    $("#txtCustomer").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Ingresos/AutoComplete/',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $("#hfCustomer").val(i.item.val);
        },
        minLength: 1
    });
});


$(document).ready(function () {
    $('.search').on('keyup', function () {
        var searchTerm = $(this).val().toLowerCase();
        $('#userTbl tbody tr').each(function () {
            var lineStr = $(this).text().toLowerCase();
            if (lineStr.indexOf(searchTerm) === -1) {
                $(this).hide();
            } else {
                $(this).show();
            }
        });
    });
});