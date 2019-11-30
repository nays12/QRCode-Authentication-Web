<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageEvent.aspx.cs" Inherits="QRCodeAuth_Web.ManageEvent" %>

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
		        <div class="divPageBody divSection" style="height:1000px;">
            <div class="divSection">
				<asp:Label ID="lblOptions" runat="server"></asp:Label>
				<br />
				<asp:DropDownList ID="ddlActiveEvents" runat="server">
				</asp:DropDownList>
				<asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select Event" />
				<br />

				<asp:Label ID="lblName" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblLocation" runat="server"></asp:Label>
				<br />

				<asp:Label ID="lblDate" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblStartTime" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblEndTime" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblDescription" runat="server"></asp:Label>
				<br />
				<br />
				<asp:Image ID="imgEventQr" runat="server" Height="300px" Width="300px" Visible="False" />
				<br />
				<br />
				<asp:Label ID="lblInstr" runat="server"></asp:Label>
				<br />
				<br />
				<asp:GridView ID="gvCreds" runat="server" AutoGenerateColumns="False">
					<Columns>
						<asp:BoundField DataField="Owner" HeaderText="Owner Id" />
						<asp:BoundField DataField="CredentialType" HeaderText="Type" />
						<asp:BoundField DataField="Name" HeaderText="Name" />
						<asp:BoundField DataField="Value" HeaderText="Value" />
					</Columns>
				</asp:GridView>
				<br />
				<asp:Button ID="btnDone" runat="server" Text="Done" Class="button btn btn-success" OnClick="btnDone_Click"/>
				
			</div>
         </div>
    </form>
</body>
</html>
