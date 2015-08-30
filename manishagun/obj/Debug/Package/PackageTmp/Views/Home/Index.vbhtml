@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "Home Page"
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>

        <script type="text/javascript">
            $(function () { initializeHome(0); });
    </script>    
</head>
<body>
    <div id="indexText" class="float-left">
        Welcome to our wedding website! Thank you for visiting, we hope that you'll find all the information you need about our wedding here. Please come back often, as we will be adding new details regularly!
        We can't wait to see all of you on our Big Day!
        <br />
        <br />
        Lots and lots of love,
        <br />
        Shagun and Manish
        <br />
        <br />
        PS: Don't forget to Sign Our Guestbook and RSVP while you're here!
    </div>
    <div id="divIndexImage" class="float-left">
        <img  src ="/Images/HUMTUM.jpg" alt="" />
    </div>
    <div class="clear-fix"></div>
</body>
</html>
