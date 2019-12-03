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
			<asp:Button ID="btnGetCredentials" runat="server" Class="button btn btn-success" Text="Get Credentials" OnClick="btnGetCredentials_Click" />

			<asp:Button ID="btnDone" runat="server" Text="Done Updating" Class="button btn btn-success" OnClick="btnDone_Click"/>

			<br />
			<asp:Label ID="lblStatus" style="color:#005073" runat="server"></asp:Label>
			<br />

            <div style="overflow-x:auto">
			<asp:GridView ID="GridView1" class="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="CredentialId" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" >
				<Columns >
					<asp:BoundField DataField="CredentialId" HeaderText="Id No."  />
					<asp:BoundField DataField="CredentialType" HeaderText="Type"  />
					<asp:BoundField DataField="Name" HeaderText="Name"  />
					<asp:BoundField DataField="Value" HeaderText="Value"  />
					<asp:BoundField DataField="IssueDate" HeaderText="Date Issued" DataFormatString="{0:d}" />
					<asp:BoundField DataField="ExpirationDate" HeaderText="Expiring On" DataFormatString="{0:d}" />
					<asp:BoundField DataField="IsValid" HeaderText="Valid"  />
					<asp:BoundField DataField="Issuer" HeaderText="Issuer" />
					<asp:CommandField ShowEditButton="True" />
					<asp:CommandField ShowDeleteButton="true" />
				</Columns>
			</asp:GridView>
            </div>

		</div>
        </div>
    </form>

</body>
</html>
