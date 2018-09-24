/// <reference path="jquery-3.3.1.min.js" />

//$(document).ready(function () {
//    setInterval(function () {
//        countNotification();
//    }, 1000);

//    $('#wavesDark').click(function () {
//        $('#noti-details').empty();
//        detailsNotification();
//    });

//    $('#noti-details').on('click', '.notiId', function (e) {
//        e.preventDefault();
//        var eid = parseInt($(this).attr('data-id'));
//        $('#approvedBtn').attr('data-id', eid);
//        $('#myModal').modal('show');
//        showNotification(eid);
//    });

//    $('#approvedBtn').click(function (e) {
//        e.preventDefault();
//        var eid = parseInt($(this).attr('data-id'));
//        $('#myModal').modal('hide');
//        hideSeenNotification(eid);
//    });


//});


//function showNotification(id) {

//    $.ajax({
//        url: '/Notification/NotificationDetails',
//        type: 'GET',
//        dataType: 'json',
//        data: { reqid: id },
//        success: function (data) {
//            console.log(data);
//            $.each(data, function (index, row) {
//                $('#myModal #eventTitle').text(row.eventname);
//                var $description = $('<div/>');
//                $description.append($('<p/>').html('<b>City:</b>' + row.city));
//                $description.append($('<p/>').html('<b>Area:</b>' + row.area));
//                $description.append($('<p/>').html('<b>Event Type:</b>' + row.eventcategory));
//                $description.append($('<p/>').html('<b>Venue:</b>' + row.venue));
//                $description.append($('<p/>').html('<b>Event Date:</b>' + row.date));
//                $('#myModal #pDetails').empty().html($description);

//                $('#myModal').modal();
//            })
//        }

//    })
//}


//function countNotification() {
//    $.ajax({
//        url: '/Notification/NotificationCount',
//        type: 'GET',
//        dataType: 'json',
//        success: function (res) {
//            if (res === false) {
//                $('#noti-span').hide();
//            } else {
//                $('#noti-span').show();
//                $('#noti-span').text(res);
//            }
//        }
//    });
//}
//function hideSeenNotification(id) {
//    $.ajax({
//        url: '/Notification/HideSeenNotification',
//        type: 'POST',
//        data: { eventId: id },
//        dataType: 'json',
//        success: function (res) {
//            if (res == true) {
//                window.location.href = '/EventRequest/Index';
//            }
//            console.log(res);
//        }
//    });
//}

//function detailsNotification() {
//    $.ajax({
//        url: '/Notification/GetNotification',
//        type: 'GET',
//        dataType: 'json',
//        success: function (res) {
//            var html;
//            if (res.length == 0) {
//                html = '<span style="padding:5px;display: block;text - align: center;">No Request Found</span>';
//                $('#noti-details').append(html);
//            } else {
//                $.each(res, function (index, row) {
//                    html = '<a data-id="' + row.id
//                        + '" class="dropdown-item notiId" href = "javascript:void(0)">' + row.name + '</a>';
//                    $('#noti-details').append(html);
//                });
//            }
//        }
//    });
//}