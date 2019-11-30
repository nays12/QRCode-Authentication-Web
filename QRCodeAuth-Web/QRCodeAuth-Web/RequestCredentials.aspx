<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestCredentials.aspx.cs" Inherits="QRCodeAuth_Web.RequestCredentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
            <asp:Label ID="Label2" runat="server" Class="lblSubTitles" Text="Select the credentials to collect"></asp:Label>
            <div class="divSection">
                <asp:CheckBoxList ID="cblRequestedCredentials" runat="server" >
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem>ID Number</asp:ListItem>
                    <asp:ListItem>Date of Birth</asp:ListItem>
                    <asp:ListItem>Address</asp:ListItem>
                    <asp:ListItem>PhoneNumber</asp:ListItem>
                    <asp:ListItem>Major</asp:ListItem>
                    <asp:ListItem>Classification</asp:ListItem>
                    <asp:ListItem>Work Title</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <asp:Button ID="Button1" runat="server" Class="button btn btn-success" Text="Comfirm" />
            <asp:Button ID="Button2" runat="server" Class="button btn btn-success" Text="Cancel" />
        </div>
    </form>
</body>
</html>
