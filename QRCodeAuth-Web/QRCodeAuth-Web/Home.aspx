<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QRCodeAuth_Web.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Authenticator</title>
    
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="StyleSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="divTitle" style="background-color:transparent">
            <img class="image" src="Images/title.JPG" />
       </div>
        <div class="divPageBody divSection">

			<asp:Label ID="lblWelcome" runat="server"></asp:Label>
			<br />
			<asp:Label ID="lbldeptInfo" runat="server"></asp:Label>
            <br />
			<asp:Label ID="lblWelcome2" runat="server"></asp:Label>

            <asp:Button ID="btnCreateEvent" runat="server" Class="button btn btn-success" Text="Create an Event" OnClick="btnCreateEvent_Click" Visible="False" />
			<asp:Button ID="btnManageEvent" runat="server" Class="button btn btn-success" Text="Manage an Event" OnClick="btnManageEvent_Click" Visible="False" />
            <asp:Button ID="btnRequest" runat="server" Class="button btn btn-success" Text="Request Credentials" OnClick="btnRequest_Click" Visible="False" />
			<asp:Button ID="btnCreateCredential" runat="server" Class="button btn btn-success" Text="Create a Credential" OnClick="btnCreateCredential_Click" Visible="False" />
			<asp:Button ID="btnUpdateCredential" runat="server" Class="button btn btn-success" Text="Update a Credential" OnClick="btnUpdateCredential_Click" Visible="False" />

			<asp:Button ID="btnLogout" runat="server" Class="BtnCancel btn" Text="Logout" OnClick="btnLogout_Click" Visible="True" />
         </div>
    </form>
</body>
</html>
