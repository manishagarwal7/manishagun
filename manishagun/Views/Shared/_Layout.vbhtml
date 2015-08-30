<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@ViewData("Title")- Vivah</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/jquery-ui.min.js"></script>
    <link type="text/css" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.9.2/themes/black-tie/jquery-ui.css" rel="Stylesheet" />
    <script src="@Url.Content("/scripts/manishagun.js")" type="text/javascript"></script>
    <link href="/Content/Guestbook.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () { initializeManishShagun(); });       
    </script>    
</head>
<body id="mainBody" oncontextmenu="return false;" >
    <div id="divHeader">
        <div class="content-wrapper">
            <div class="float-left">
                <div id="logo" class="float-left">
                   <img  src ="/Images/MSLOGO.jpg" alt=""/>
                </div>
                <div id="headerText" class="float-left">                    
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                Manish & Shagun                            
                            </td>
                        </tr>
                        <tr>
                            <td>
                                15 December, 2013    
                            </td>
                            <td id="tdDaysToGo">
                            </td>
                        </tr>
                    </table>                                       
                </div>                
            </div>            
        </div>
    </div>
    <div id="divBody" class="content-wrapper clear-fix">
        <div class="float-left">
            <table id="menu">
                <tr><td>@Html.ActionLink("Home", "Index", "Home")</td></tr>
                <tr><td>@Html.ActionLink("About Us", "AboutUs", "Home")</td></tr>
                 <tr><td>@Html.ActionLink("Guestbook", "GuestBook", "Home")</td></tr>
                <tr><td>@Html.ActionLink("Manuhar Patrika", "ManuharPatrika", "Home")</td></tr>
            </table>
         </div>
        <div class="float-left main-content">
             @RenderBody()
        </div>       
    </div>
    @*<div id="divFooter">*@
        @*<div class="content-wrapper clear-fix">*@
            @*<div class="float-left">*@
                @*<p>&copy; @DateTime.Now.Year - MaNiShAgUn</p>*@                
            @*</div>*@
            @*<div class="float-right">*@
                @*<object height="0" width="100" data="/Music/MRSK.mp3"></object>*@
            @*</div>*@
        @*</div>*@
    @*</div>*@
</body>
</html>
