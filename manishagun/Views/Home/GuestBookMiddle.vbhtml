@imports manishagun.Manishagun.Web
@ModelType GuestBookMiddleModel
<div id="guestbook-header">
    <div id="message-count">@Model.MessageCount  messages</div>
    <div id="add-message"><a id="add-message-link" href="#">Add a message</a></div>
    <div class="clear-fix"></div>
</div>
<ul class="guestbook-message-list" id="guestbook-messages">
    <li>
        <div class="message-information">
            <div class="message-name">@Model.MessageLeftName </div>
            <div class="message-time">@Model.MessageLeftTime </div>
            <div class="clear-fix"></div>
        </div>

        <div class="message-note">
            <p>@Model.MessageLeftNote</p>
        </div>
    </li>
</ul>
<ul class="guestbook-message-list odd-message-list">
    <li>
        <div class="message-information">
            <div class="message-name">@Model.MessageRightName </div>
            <div class="message-time">@Model.MessageRightTime </div>
            <div class="clear-fix"></div>
        </div>

        <div class="message-note">
            <p>@Model.MessageRightNote</p>
        </div>
    </li>
</ul>
<div class="clear-fix"></div>
<div class="float-left">Page <label id="lblPageNumber">@Model.PageNumber</label></div>
<div class="float-right">
    @If Model.IsPreviousAvailable Then
         @<a id="aGuestMiddlePrevious" href="#">Previous</a>
    End If
    @If Model.IsNextAvailable AndAlso Model.IsPreviousAvailable Then
        @Html.Raw(" - ")
    End If     
    @If Model.IsNextAvailable Then
        @<a id="aGuestMiddleNext" href="#">Next</a>
    End If        
</div>
<div class="clear-fix"></div>