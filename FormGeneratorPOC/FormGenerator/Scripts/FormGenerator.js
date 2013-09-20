﻿$.noConflict();
$(document).ready(function () {

    $('input[validate="True"]').each(function () {
        if ($(this).attr("controlname") == "date") {
            $(this).datepicker();
        }
    });

    //    $('input[validate="True"]').each(function () {

    //        if ($(this).attr("controlname") == "date") {

    //            $(this).datepicker();

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }

    //            $(this).blur(function () {
    //                if ($(this).val() == "") {
    //                    showErrorBorder($(this), true);
    //                }
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //        }
    //        else if ($(this).attr("controlname") == "generic text"
    //                    || $(this).attr("controlname") == "first name"
    //                    || $(this).attr("controlname") == "last name"
    //                    || $(this).attr("controlname") == "city"
    //                    || $(this).attr("controlname") == "zip code"
    //                    || $(this).attr("controlname") == "company"
    //                    ) {

    //            $(this).blur(function () {

    //                if ($(this).val() == "")
    //                    showErrorBorder($(this), true);
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }
    //        }
    //        else if ($(this).attr("controlname") == "email") {

    //            $(this).blur(function () {

    //                if (!IsEmail($(this).val()))
    //                    showErrorBorder($(this), true);
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }
    //        }
    //        else if ($(this).attr("controlname") == "phone") {

    //            $(this).blur(function () {

    //                if (!IsPhoneNumber($(this).val()))
    //                    showErrorBorder($(this), true);
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }
    //        }
    //        else if ($(this).attr("controlname") == "number") {

    //            $(this).blur(function () {

    //                if (!IsInt($(this).val()))
    //                    showErrorBorder($(this), true);
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }

    //        }
    //        else if ($(this).attr("controlname") == "url") {

    //            $(this).blur(function () {

    //                if (!validateURL($(this).val()))
    //                    showErrorBorder($(this), true);
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }
    //        }

    //    });

    //    $('textarea[validate="True"]').each(function () {

    //        if ($(this).attr("controlname") == "comments") {

    //            $(this).blur(function () {

    //                if ($(this).val() == "")
    //                    showErrorBorder($(this), true);
    //                else
    //                    showErrorBorder($(this), false);
    //            });

    //            if ($.browser.msie) {
    //                SetUpTexBoxBehavior($(this).attr('id'));
    //            }
    //        }
    //    });

    //    $('select[validate="True"]').each(function () {

    //        $(this).change(function () {

    //            if ($(this).attr("selectedIndex") == "0")
    //                showErrorBorder($(this), true);
    //            else
    //                showErrorBorder($(this), false);
    //        });
    //    });

    $('#lblErrorMessage').hide();
});

function IsValid() {

    try {

        isValid = true;

        $('input[validate="True"]').each(function () {

            if ($(this).attr("controlname") == "generic text"
                    || $(this).attr("controlname") == "first name"
                    || $(this).attr("controlname") == "last name"
                    || $(this).attr("controlname") == "city"
                    || $(this).attr("controlname") == "zip code"
                    || $(this).attr("controlname") == "company"
                    || $(this).attr("controlname") == "suite"
                    || $(this).attr("controlname") == "street address"
                    || $(this).attr("controlname") == "date"
                    ) {

                if ($(this).val() == "") {
                    showErrorBorder($(this), true);
                    isValid = false;
                }
                else
                    showErrorBorder($(this), false);
            }
            else if ($(this).attr("controlname") == "email") {

                if (!IsEmail($(this).val())) {
                    showErrorBorder($(this), true);
                    isValid = false;
                }
                else
                    showErrorBorder($(this), false);
            }
            else if ($(this).attr("controlname") == "phone") {

                if (!IsPhoneNumber($(this).val())) {
                    showErrorBorder($(this), true);
                    isValid = false;
                }
                else
                    showErrorBorder($(this), false);
            }
            else if ($(this).attr("controlname") == "number") {

                if (!IsInt($(this).val()))
                    showErrorBorder($(this), true);
                else
                    showErrorBorder($(this), false);
            }
            else if ($(this).attr("controlname") == "url") {

                if (!validateURL($(this).val())) {
                    showErrorBorder($(this), true);
                    isValid = false;
                }
                else
                    showErrorBorder($(this), false);
            }

        });

        $('textarea[validate="True"]').each(function () {

            if ($(this).attr("controlname") == "comments") {

                if ($(this).val() == "") {
                    showErrorBorder($(this), true);
                    isValid = false;
                }
                else
                    showErrorBorder($(this), false);
            }
        });

        $('select[validate="True"]').each(function () {

            if ($(this).attr("selectedIndex") == "0") {
                showErrorBorder($(this), true);
                isValid = false;
            }
            else
                showErrorBorder($(this), false);

        });

        if (isValid == false) {
            $('#lblErrorMessage').show();
            $('#lblSuccessMessage').hide();
        }
        else {
            $('#lblErrorMessage').hide();
            $('#lblSuccessMessage').show();
        }

        return isValid;

    }
    catch (e) {

        $('#lblErrorMessage').show();
        return false;
    }
}


function validateURL(textval) {
    var urlregex = new RegExp("^(http:\/\/www.|https:\/\/www.|ftp:\/\/www.|www.){1}([0-9A-Za-z]+\.)");
    return urlregex.test(textval);
}

function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function IsPhoneNumber(phone) {
    var regex = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    return regex.test(phone);
}

function IsInt(number) {
    var regex = /^\d+$/;
    return regex.test(number);
}

function IsDate(input) {
    var validformat = /^\d{2}\/\d{2}\/\d{4}$/
    var returnval = false

    if (!validformat.test(input))
        returnval = false
    else {
        var monthfield = input.split('/')[0]
        var dayfield = input.split('/')[1]
        var yearfield = input.split('/')[2]
        var dayobj = new Date(yearfield, monthfield - 1, dayfield)

        if ((dayobj.getMonth() + 1 != monthfield) || (dayobj.getDate() != dayfield) || (dayobj.getFullYear() != yearfield))
            returnval = false
        else
            returnval = true
    }
    alert(returnval);
    return returnval
}

function showErrorBorder(element, toggle) {

    if (toggle == true)
        element.css({ 'border-width': 'medium', 'border-color': '#FF8C00' });
    else
        element.css({ 'border-width': '', 'border-color': '#A4B97F' });
}


function autoResize(id) {
    var newheight;
    var newwidth;

    if (document.getElementById) {
        newheight = document.getElementById(id).contentWindow.document.body.scrollHeight;
        newwidth = document.getElementById(id).contentWindow.document.body.scrollWidth;
    }

    document.getElementById(id).height = (newheight) + "px";
    document.getElementById(id).width = (newwidth) + "px";
}

function SetUpTexBoxBehavior(elementID) {

    var phValue = $('#' + elementID).attr('placeholder'); ;

    $("#" + elementID).val(phValue).addClass('watermark');

    $("#" + elementID).blur(function () {
        if ($(this).val() == "") {
            $(this).val(phValue);
            $(this).addClass('watermark');
        }
        else
            $("#" + elementID).css({ 'border-width': '', 'border-color': '#A4B97F' });
    });

    $("#" + elementID).focus(function () {
        if ($(this).val() == phValue)
            $(this).val('').removeClass('watermark');
    });
}