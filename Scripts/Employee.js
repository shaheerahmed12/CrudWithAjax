$(document).ready(function () {
    get();


});
function get() {

    var html = '';
    $.ajax({
        url: '/Emp/Get',
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (result) {


            $.each(result, function (key, item) {
                html += '<tr><td>' + item.Id + '</td><td>' + item.FirstName + '</td><td>' + item.LastName + '</td><td>' + item.Address + '</td></tr>';


            });
            $("#tbody").html(html);
        }
    }

    );
}

function AddCustomer() {
    
    $.get("DataEntry").done(function (r) {
        $('#DataEnt').html(r);

    });
};
//function Updating() {

//    $.get("DataUpdate").done(function (r) {
//        $('#DataUp').html(r);

//    });
//};
$(document).on('click', '#ADD', function (e) {
    e.preventDefault();

    var isNew = true;

    if (isNew == true) {



        var empObj = {

            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            Address: $('#Address').val()

        }
    }

    $.ajax({

        type: "POST",
        url: '/Emp/SaveChange',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(empObj),
        success: function (data) {
            if (isNew) {
                get();
            }
        }
    });
});

    //$(document).on('click', '#Upadte', function (e) {
    //    e.preventDefault();

    //    var isNew = true;

    //    if (isNew == true) {



    //        var empObj = {

    //            FirstName: $('#FirstName').val(),
    //            LastName: $('#LastName').val(),
    //            Address: $('#Address').val()

    //        }
    //    }

    //     $.ajax({

    //        type: "POST",
    //        url: '/Emp/DataUpdate',
    //        dataType: "json",
    //        contentType: "application/json;charset=utf-8",
    //        data: JSON.stringify(empObj),
    //        success: function (data) {
    //            if (isNew) {
    //                get();
    //            }
    //        }
        
    //    });
/*});*/







//})