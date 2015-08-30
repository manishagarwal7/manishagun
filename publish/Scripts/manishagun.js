(function ($) {
    $.fn.blink = function (options) {
        var defaults = {
            delay: 500
        };
        var options = $.extend(defaults, options);

        return this.each(function () {
            var obj = $(this);
            setInterval(function () {
                if ($(obj).css("visibility") == "visible") {
                    $(obj).css('visibility', 'hidden');
                }
                else {
                    $(obj).css('visibility', 'visible');
                }
            }, options.delay);
        });
    }
}(jQuery))

function isNotEmpty(txt) { if (txt == null || txt.length == 0) { return false; } else { return true; } }

function strToHTML(strX) {
    var rx1 = /&/g;
    var rx2 = /</g;
    var rx3 = />/g;

    return strX.replace(rx1, "&amp;").replace(rx2, "&lt;").replace(rx3, "&gt;");
}

function initializeManishShagun() { daysTogo(); }

function daysTogo() {
    var start = new Date();
    var end = new Date("12/15/2013");
    var diff = new Date(end - start);
    var days = diff / 1000 / 60 / 60 / 24;
    $("#tdDaysToGo").html(parseInt(days + 1) + " days to go!");
    $('#tdDaysToGo').blink();

}

function initializeAboutUs(bottomOffsetHeight) {

    bindWindow(bottomOffsetHeight);
}

function initializeHome(bottomOffsetHeight) {

    bindWindow(bottomOffsetHeight);

    var $manishAgunImg = $("#divIndexImage img");

    $manishAgunImg.height($("#divBody").height()/1.5);
    

    $(window).resize(function () {
        $manishAgunImg.height($("#divBody").height() /1.5);
    });

}

function initializeGuestBook(bottomOffsetHeight) {
    bindWindow(bottomOffsetHeight);   

    getGuestBookMiddleMessage(0, true);

    $("#bttnGuestMessagePost").click(function () {

        if (isNotEmpty($("#message_name").val()) && isNotEmpty($("#message_note").val())) {
            saveGuestBookMessage();
            $("#divMessagePost").dialog("destroy");
        }
        else { alert("Both fields are required.");}


        
    });
    
}


function initializeManuharPatrika(bottomOffsetHeight) {    
   
    bindWindow(bottomOffsetHeight);

    var $manuharPatrikaImg = $("#divManuharPatrika img");

    $manuharPatrikaImg.height($("#divBody").height() - 10);

    setTimeout("alignDivToCenter($('#divManuharPatrika'))", 10);
    

    $(window).resize(function () {
        $manuharPatrikaImg.height($("#divBody").height() - 10);
        alignDivToCenter($("#divManuharPatrika"));
    });
    

}

function alignDivToCenter($divObj) {
    var m = ($("#divBody").width() - (160 + 40) - $divObj.width()) / 2;
    var mp = m + "px";
    $divObj.css("margin-left", mp);
}


function setLayoutElementHeights(bottomOffsetHeight) {

    var $divBody = $("#divBody");
    var newHeight = $(window).height() - $divBody.offset().top - bottomOffsetHeight;
    
    $divBody.height(newHeight);

}

function bindWindow(bottomOffsetHeight) {
    setLayoutElementHeights(bottomOffsetHeight);
    $(window).resize(function () { setLayoutElementHeights(bottomOffsetHeight); });
}

function saveGuestBookMessage()  
{
    var name = strToHTML($("#message_name").val());
    var msg = strToHTML($("#message_note").val());

    $.ajax({
        url: "/Home/SaveGuestBookMessage",
        type: "POST",
        data: { name: name, msg: msg },
        success: function () {
            getGuestBookMiddleMessage(0, true);
        },
        error: function (xhr, textStatus, errorThrown) {
            // alert("An error occurred.\n\nxhr response: " + xhr.responseText + "\n\nHTTP status code: " + xhr.status + "\n\nerrorThrown: " + errorThrown);
        }
    });
}

function getGuestBookMiddleMessage(pageNumber, iSNext) {

    showLoaderizer($("#open-guestbook"), "Loading....", function () {
        $.ajax({
            url: "/Home/GuestBookMiddle?currentPageNumber=" + pageNumber + "&IsNext=" + iSNext,
            success: function (returnData) {
                $("#guestbook-middle").html(returnData);
                BindGuestBookMiddle();
                hideLoaderizer($("#open-guestbook"));
            },
            error: function (xhr, textStatus, errorThrown) {
                // alert("An error occurred.\n\nxhr response: " + xhr.responseText + "\n\nHTTP status code: " + xhr.status + "\n\nerrorThrown: " + errorThrown);
            }
        });
    });
    
}

function BindGuestBookMiddle() {

    $("#aGuestMiddleNext").click(function () { getGuestBookMiddleMessage($("#lblPageNumber").text(), true) });
    $("#aGuestMiddlePrevious").click(function () { getGuestBookMiddleMessage($("#lblPageNumber").text(), false) });
    $("#add-message-link").click(function () {

        $("#divMessagePost").dialog({
            modal: true,
            title: "Add a message",
            position: 'center',
            height: 220,
            width: 500
        });

    });
}

function showLoaderizer(ele, txt, callback) {

    //var $divLoaderizer = $('<div class="divLoaderizer">' + txt + '<img src="/images/" /></div>');
    var $divLoaderizer = $('<div class="divLoaderizer">' + txt + '</div>');
    var position = ele.position();
    var height = ele.css("height");

    $divLoaderizer.css("top", position.top).css("left", position.left).css("height", height).css("width", ele.css("width")).css("line-height", height);

    $divLoaderizer.appendTo(ele);

    if (ele.is(":visible")) {
        $divLoaderizer.fadeIn(function () { callback !== undefined ? callback() : null; });
    }
    else {
        callback !== undefined ? callback() : null;
    }

}

function hideLoaderizer(ele) {

    var position = ele.position();
    var height = ele.css("height");

    $("div.divLoaderizer", ele).css("top", position.top).css("left", position.left).css("height", height).css("width", ele.css("width")).css("line-height", height).fadeOut(function () { $(this).remove(); });

}


