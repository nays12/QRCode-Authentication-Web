<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="QRCodeAuth_Web.CreateEvent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Authenticator</title>

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link href="StyleSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="divTitle" style="background-color:transparent">
            <img class="image" src="Images/title.JPG" />
        </div>

    <div class="divPageBody divSection">
        <asp:Label ID="Label1" runat="server" class="lblSubTitles" Text="Event Type"></asp:Label>
        <div class="divSection">
            <asp:Label ID="Label2" runat="server" Class="lbl" Text="Select Event Type"></asp:Label>

            <asp:DropDownList ID="DropDownList1" runat="server" Class="txb">
                <asp:ListItem>Select Type</asp:ListItem>
                <asp:ListItem>Event</asp:ListItem>
                <asp:ListItem>Lecture</asp:ListItem>
                <asp:ListItem>Meeting</asp:ListItem>
            </asp:DropDownList>

        </div>

        <asp:Label ID="Label3" runat="server" Class="lblSubTitles" Text="Evant Details"></asp:Label>
        <div class="divSection">

            <asp:Label ID="Label5" runat="server" Class="lbl" Text="Name of Event:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Class="txb"></asp:TextBox>

            <asp:Label ID="Label6" runat="server" Class="lbl" Text="Creator of the Event:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" Class="txb"></asp:TextBox>

            <asp:Label ID="Label7" runat="server" Class="lbl" Text="Location of the Event:"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" Class="txb"></asp:TextBox>

            <asp:Label ID="Label8" runat="server" Class="lbl" Text="Date:"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" Class="txb"></asp:TextBox>

            <asp:Label ID="Label9" runat="server" Class="lbl" Text="Start Time:"></asp:Label>
            <asp:TextBox ID="TextBox7" runat="server" Class="txb"></asp:TextBox>

            <asp:Label ID="Label10" runat="server" Class="lbl" Text="End Time:"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server" Class="txb"></asp:TextBox>

        </div>
        <asp:Button ID="Button3" runat="server" Class="button btn btn-success" Text="Continue" />


    </div>

    </form>
</body>
</html>
