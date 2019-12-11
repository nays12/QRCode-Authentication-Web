<%-- 
Purpose: 
Defines the UI for the page

Contributors: 
Ortuno Marilin
Naomi Wiggins
--%>

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
            <%--<img class="image" src="Images/title.JPG" />--%>
            <h1>The Authenticat<img src="Images/Logo.jpg" class="imgLogo" />r </h1>
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
                <asp:RequiredFieldValidator ID="rfvName" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtCredentialName"></asp:RequiredFieldValidator>

				<asp:Label ID="lblValue" runat="server" Class="lbl" Text="Value"></asp:Label>
				<asp:TextBox ID="txtValue" runat="server" Class="txb"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvValue" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtValue"></asp:RequiredFieldValidator>

				<asp:Label ID="lblExpDate" runat="server" Class="lbl" Text="Expiration Date"></asp:Label>
				<asp:TextBox ID="txtExpDate" runat="server" Class="txb"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvExpDate" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtExpDate"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtExpDate" Class="lblError" ErrorMessage="*Invalid Date. Please try again. " ValidationExpression="^(?:^(?:(?:(?:(?:(?:0[13578]|1[02])/31)|(?:(?:0[13-9]|1[0-2])/(?:29|30)))/(?:1[6-9]|[2-9]\d)\d{2})|(?:02/29/(?:(?:(?:1[6-9]|[2-9]\d)(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0[1-9])|(?:1[0-2]))/(?:0[1-9]|1\d|2[0-8])/(?:(?:1[6-9]|[2-9]\d)\d{2}))$)$"></asp:RegularExpressionValidator>
                

				<asp:Label ID="lblIssueTo" runat="server" Class="lbl" Text="Issue To"></asp:Label>
				<asp:TextBox ID="txtIssueTo" runat="server" Class="txb"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvIssueTo" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtIssueTo"></asp:RequiredFieldValidator>

			<asp:Label ID="lblStatus" Class="lbl" runat="server"></asp:Label>

			<asp:Button ID="btnCreate" runat="server" Class="button btn btn-success" Text="Create Credential" OnClick="btnCreate_Click" />
			<asp:Button ID="btnDone" runat="server" Text="Done" Class="button btn btn-success" OnClick="btnDone_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Class="BtnCancel btn"/>
		</div>
    </form>
</body>
</html>
