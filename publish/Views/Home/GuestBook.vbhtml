@Code
    Layout = "/Views/Shared/_Layout.vbhtml"
    ViewData("Title") = "Home Page"
End Code

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <title>GuestBook</title>

    <script type="text/javascript">
        $(function () { initializeGuestBook(0); });
    </script>
</head>
<body>
    <div>
        <div id="guestbook">
            <h1>Guestbook</h1>
            Feel free to share your thoughts and wishes as we prepare to celebrate our special day.
            <div id="open-guestbook">
                <div id="guestbook-top"></div>
                <div id="guestbook-middle">
                </div>
                <div id="guestbook-bottom"></div>
            </div>
        </div>
    </div>
    <div id="divMessagePost" class="hidden">

        <table>
            <tr>
                <td><label for="message_name" class="field">Name:</label></td>
                <td><input type="text" size="30" id="message_name"  /></td>
            </tr>
            <tr>
                <td><label for="message_note" class="field">Note:</label></td>
                <td><textarea id="message_note" class="required" rows="3" cols="30"></textarea></td>
            </tr>
        </table>

        <div class="field-group clear-fix">
            <button type="button" name="button" id="bttnGuestMessagePost" >Post Message</button>
        </div>
    </div>
</body>
</html>
