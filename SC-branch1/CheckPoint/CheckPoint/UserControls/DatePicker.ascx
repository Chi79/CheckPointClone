<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="CheckPoint.Views.UserControls.DatePicker" %>

 <style type="text/css">

.ui-datepicker .ui-datepicker-prev, 
.ui-datepicker .ui-datepicker-next
{
    display:none;
}
.ui-widget.ui-widget-content {
    border: 1px solid #c5c5c5;
    border-radius: 14px;
}
.ui-datepicker .ui-widget{
    border-radius:10px;
}
.ui-datepicker .ui-datepicker-header {
    position: relative;
    padding: .2em 0;
    /*background-color: #10591B;*/
    background-image:url(/Images/buttonshade1.png);
    border-radius: 9px;
}
.ui-state-active, .ui-widget-content .ui-state-active, .ui-widget-header .ui-state-active, a.ui-button:active, .ui-button:active, .ui-button.ui-state-active:hover {
    border: 1px solid #32E236;
    background: #32E236;
    font-weight: normal;
    color: #ffffff;
    -webkit-animation:flashingbutton;
    -webkit-animation-duration:2s;
    -webkit-animation-iteration-count:infinite;
}
 </style>




    <script type="text/javascript">


    $(function () {
    $(".picker").datepicker({
    showOn: "button",
    buttonImage: "/images/calendar2.png",
    buttonImageOnly: true,
    buttonText: "calender",
    beforeShowDay: function (date) {
    var selected = $(this).datepicker('getDate');
    return [selected && date.getTime() === selected.getTime(), ''];
    }
    });
    $('.picker').find('.ui-datepicker-next').remove();
    $('.picker').find('.ui-datepicker-prev').remove();
    $(".picker").datepicker("setDate", $(".picker"))
    });


    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
    prm.add_endRequest(function (sender, e) {
    if (sender._postBackSettings.panelsToUpdate != null) {
    $(".picker").datepicker({
    showOn: "button",
    buttonImage: "/images/calendar2.png",
    buttonImageOnly: true,
    buttonText: "calender",
    beforeShowDay: function (date) {
    var selected = $(this).datepicker('getDate');
    return [selected && date.getTime() === selected.getTime(), ''];
    }
    });
    }
    });
    $('.picker').find('.ui-datepicker-next').remove();
    $('.picker').find('.ui-datepicker-prev').remove();
    };
    </script>