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
            <%--<img class="image" src="Images/title.JPG" />--%>
            <h1>The Authenticat<img src="Images/Logo.jpg" class="imgLogo" />r </h1>
        </div>
		        <div class="divPageBody divSection">
            <div class="divSection">
				<asp:Label ID="lblOptions" style="color:#005073" runat="server"></asp:Label>
				<br />
				<asp:DropDownList ID="ddlActiveEvents" runat="server">
				</asp:DropDownList>
				<asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select Event" />
				<br />

				<asp:Label ID="lblName" style="color:#005073" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblLocation" style="color:#005073" runat="server"></asp:Label>
				<br />

				<asp:Label ID="lblDate" style="color:#005073" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblStartTime" style="color:#005073" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblEndTime" style="color:#005073" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblDescription" style="color:#005073" runat="server"></asp:Label>
				<br />
				<br />
				<asp:Image ID="imgEventQr" runat="server" Height="300px" Width="300px" Visible="False" />
				<br />
				<br />
				<asp:Label ID="lblInstr" style="color:#005073" runat="server"></asp:Label>

                <div style="overflow-x:auto">
				<asp:GridView ID="gvCreds" class="GridView" runat="server" AutoGenerateColumns="False">
					<Columns>
						<asp:BoundField DataField="Owner" HeaderText="Owner Id" />
						<asp:BoundField DataField="CredentialType" HeaderText="Type" />
						<asp:BoundField DataField="Name" HeaderText="Name" />
						<asp:BoundField DataField="Value" HeaderText="Value" />
					</Columns>
				</asp:GridView>
                </div>
				<br />
				<asp:Button ID="btnDone" runat="server" Text="Done" Class="button btn btn-success" OnClick="btnDone_Click"/>
				
			</div>
         </div>
    </form>
</body>
</html>
