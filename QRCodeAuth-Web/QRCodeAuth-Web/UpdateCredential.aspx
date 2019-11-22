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

<%--			<ef:EntityDataSource ID="dsWebSystemData" runat="server" ConnectionString="name=WebSystemData" DefaultContainerName="WebSystemData">
			</ef:EntityDataSource>--%>

			<asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
				<FooterStyle BackColor="White" ForeColor="#000066" />
				<HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
				<RowStyle ForeColor="#000066" />
				<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
				<SortedAscendingCellStyle BackColor="#F1F1F1" />
				<SortedAscendingHeaderStyle BackColor="#007DBB" />
				<SortedDescendingCellStyle BackColor="#CAC9C9" />
				<SortedDescendingHeaderStyle BackColor="#00547E" />
			</asp:GridView>

			<asp:GridView ID="GridView2" runat="server">
			</asp:GridView>
			<ef:EntityDataSource ID="EntityDataSource1" runat="server" OnSelecting="EntityDataSource1_Selecting">
			</ef:EntityDataSource>

		</div>
        	</div>
    </form>
</body>
</html>
