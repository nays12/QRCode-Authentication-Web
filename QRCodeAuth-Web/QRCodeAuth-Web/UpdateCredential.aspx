<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCredential.aspx.cs" Inherits="QRCodeAuth_Web.UpdateCredential" %>

<%@ Register assembly="Microsoft.AspNet.EntityDataSource" namespace="Microsoft.AspNet.EntityDataSource" tagprefix="ef" %>

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
			<asp:Label ID="Label1" runat="server" class="lblSubTitles" Text="Update a Credential"></asp:Label>
	
		<div class="divSection">

			<asp:Label ID="lblMobileId" runat="server" Class="lbl" Text="Please enter the Id of Mobile Account for which you would like to update Credentials."></asp:Label>
			<asp:TextBox ID="txtMobileId" runat="server" Class="txb"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMobileId" runat="server" Class="lblError" ErrorMessage="* Field Required - Please enter a value." ControlToValidate="txtMobileId"></asp:RequiredFieldValidator>

			<asp:Button ID="btnGetCredentials" runat="server" Class="button btn btn-success" Text="Get Credentials" OnClick="btnGetCredentials_Click" />

			<br />

			<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
				<Columns>
					<asp:BoundField DataField="CredentialType" HeaderText="Type" />
					<asp:BoundField DataField="Name" HeaderText="Name" />
					<asp:BoundField DataField="Value" HeaderText="Value" />
					<asp:BoundField DataField="IssueDate" HeaderText="Date Issued" />
					<asp:BoundField DataField="ExpirationDate" HeaderText="Expiring On" />
					<asp:CheckBoxField DataField="IsValid" HeaderText="Valid" />
					<asp:BoundField DataField="Issuer" HeaderText="Issuer" />
					<asp:CommandField HeaderText="Edit" ShowEditButton="True" />
				</Columns>
			</asp:GridView>

		</div>
        </div>
    </form>
</body>
</html>
