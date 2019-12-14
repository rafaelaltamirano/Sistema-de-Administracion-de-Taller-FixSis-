$('#basicModal').on('shown.bs.modal', function (e) {
    $("#modal-content").load("/Repuestos/Create");
});




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
