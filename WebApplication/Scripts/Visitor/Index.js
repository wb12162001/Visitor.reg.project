$(function () {

    "use strict";
    //console.log("1233222");
    $('div button.let-btn').each(function (i) {
        $(this).click(function () {
            var letter = $(this).attr("data-value");
            console.log(letter);
            submitIndex(letter);
        })

    });
    bindclickUser();

    $('#myModal').on('show.bs.modal', function (e) {
        var site = e.relatedTarget.site;
        var userid = e.relatedTarget.userid;
        console.log(userid);
    });

    $('#myModal').on('hide.bs.modal', function (e) {
        $("#myModal span.text-danger").html('');
        /*
        var url = $('#modal_actUrl').val(); 

        $.ajax({
            type: 'get',
            url: url,
            beforeSend: function () {

            },
            success: function (result) {
                console.log('success');
                $('#myModal div.modal-content').html(result);
            },
            error: function (result) {
                console.log(result);
            },
            complete: function (result) {
            }
        });
        */
    });

});

function bindclickUser() {
    $('div .widget-user').each(function (i) {
        $(this).click(function () {
            showUserModal(1, 2);
        })

    });
}

function clearUser() {
    $('#userList').html("");
}

function submitIndex(letter) {
    var url = $('#actUrl').val();   
    $.ajax({
        type: 'get',
        url: url,
        data: { letter: letter },
        beforeSend: function () {
            console.log('beforeSend');
            clearUser();
            $('#ajax-loader').show();
        },
        success: function (result) {
            console.log('success');
            $('#userList').html(result);
            $(function () {
                bindclickUser();
            });
        },
        error: function (result) {
            console.log(result);
        },
        complete: function (result) {
            $('#ajax-loader').hide();
        }
    });
}

function showUserModal(site, userid) {
    
    $('#myModal').modal({
        show: true
    }, {
            site: site,
            userid: userid
        });
}
