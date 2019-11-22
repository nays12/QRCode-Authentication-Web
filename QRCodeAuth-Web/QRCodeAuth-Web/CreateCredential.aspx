<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCredential.aspx.cs" Inherits="QRCodeAuth_Web.CreateCredential" %>

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
			<asp:Label ID="Label1" runat="server" class="lblSubTitles" Text="Create New Credential"></asp:Label>

					<div class="divSection">
				<asp:Label ID="lblType" runat="server" Class="lbl" Text="Credential Type"></asp:Label>

				<asp:DropDownList ID="ddlCredentialType" runat="server" Class="txb">
					<asp:ListItem>Name</asp:ListItem>
					<asp:ListItem>Email</asp:ListItem>
					<asp:ListItem>IdNumber</asp:ListItem>
					<asp:ListItem>Birthdate</asp:ListItem>
					<asp:ListItem>Address</asp:ListItem>
					<asp:ListItem Value="Phone_Number">Phone Number</asp:ListItem>
					<asp:ListItem>Major</asp:ListItem>
					<asp:ListItem>Classification</asp:ListItem>
					<asp:ListItem Value="WorkTitle">Work Title</asp:ListItem>
				</asp:DropDownList>

				<asp:Label ID="lblName" runat="server" Class="lbl" Text="Name"></asp:Label>
				<asp:TextBox ID="txtCredentialName" runat="server" Class="txb"></asp:TextBox>

				<asp:Label ID="lblValue" runat="server" Class="lbl" Text="Value"></asp:Label>
				<asp:TextBox ID="txtValue" runat="server" Class="txb"></asp:TextBox>

				<asp:Label ID="lblExpDate" runat="server" Class="lbl" Text="Expiration Date"></asp:Label>
				<asp:TextBox ID="txtExpDate" runat="server" Class="txb"></asp:TextBox>

				<asp:Label ID="lblIssueTo" runat="server" Class="lbl" Text="Issue To"></asp:Label>
				<asp:TextBox ID="txtIssueTo" runat="server" Class="txb"></asp:TextBox>

			</div>
			<asp:Button ID="btnCreate" runat="server" Class="button btn btn-success" Text="Create Credential" OnClick="btnCreate_Click" />
		</div>
    </form>
</body>
</html>
