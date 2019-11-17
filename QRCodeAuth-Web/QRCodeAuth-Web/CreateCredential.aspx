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
				<asp:Label ID="Label2" runat="server" Class="lbl" Text="Credential Type"></asp:Label>

				<asp:DropDownList ID="ddlCredentialType" runat="server" Class="txb">
					<asp:ListItem>Name</asp:ListItem>
					<asp:ListItem>Email</asp:ListItem>
					<asp:ListItem>IdNumber</asp:ListItem>
					<asp:ListItem>Birthdate</asp:ListItem>
					<asp:ListItem>Address</asp:ListItem>
					<asp:ListItem Value="Phone_Number">Phone Number</asp:ListItem>
					<asp:ListItem>Major</asp:ListItem>
					<asp:ListItem>Classification</asp:ListItem>
				</asp:DropDownList>
			    <asp:RequiredFieldValidator ID="rfvCredentialType" runat="server" Class="lblError" ErrorMessage="* Please select a credentail Type. " ControlToValidate="ddlCredentialType"></asp:RequiredFieldValidator>

				<asp:Label ID="txtName" runat="server" Class="lbl" Text="Name"></asp:Label>
				<asp:TextBox ID="txtCredentialName" runat="server" Class="txb"></asp:TextBox>

			    <asp:RequiredFieldValidator ID="rfvName" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtCredentialName"></asp:RequiredFieldValidator>

				<asp:Label ID="Label6" runat="server" Class="lbl" Text="Value"></asp:Label>
				<asp:TextBox ID="txtValue" runat="server" Class="txb"></asp:TextBox>

			    <asp:RequiredFieldValidator ID="rfvValue" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtValue"></asp:RequiredFieldValidator>

				<asp:Label ID="Label7" runat="server" Class="lbl" Text="Expiration Date"></asp:Label>
				<asp:TextBox ID="txtExpDate" runat="server" Class="txb"></asp:TextBox>

				        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtExpDate" Class="lblError" ErrorMessage="*Invalid Date. Please try again. " ValidationExpression="^((0|1)\d{1})/((0|1|2)\d{1})/((19|20)\d{2})$"></asp:RegularExpressionValidator>

			    <asp:RequiredFieldValidator ID="rfvExpDate" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtExpDate"></asp:RequiredFieldValidator>

				<asp:Label ID="Label8" runat="server" Class="lbl" Text="Issue To"></asp:Label>
				<asp:TextBox ID="txtIssueTo" runat="server" Class="txb"></asp:TextBox>

			    <asp:RequiredFieldValidator ID="rfvIssueTo" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtIssueTo"></asp:RequiredFieldValidator>

			</div>
			<asp:Button ID="btnCreate" runat="server" Class="button btn btn-success" Text="Create Credential" OnClick="btnCreate_Click" />
		</div>
    </form>
</body>
</html>
