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
				<asp:Image ID="eventQR" runat="server" Height="300px" Width="300px" src="Images/QRCodes/generatedQR.jpg" ImageAlign="AbsMiddle" />
				<br />
				<asp:GridView ID="gvEvents" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvEvents_SelectedRow">
					<Columns>
						<asp:BoundField HeaderText="Name" ReadOnly="True" DataField="Name" />
						<asp:BoundField HeaderText="Location" ReadOnly="True" DataField="Location" />
						<asp:BoundField HeaderText="Start Time" ReadOnly="True" DataField="StartTime" />
						<asp:BoundField HeaderText="End Time" ReadOnly="True" DataField="EndTime" />
					</Columns>
				</asp:GridView>

				<asp:Label ID="lblName" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblLocation" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblStartTime" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblEndTime" runat="server"></asp:Label>
				<br />
				<asp:Label ID="lblDescription" runat="server"></asp:Label>
				<br />
				<asp:GridView ID="gvCredentials" runat="server"></asp:GridView>
				
			</div>
			<div>
			</div>
         </div>
    </form>
</body>
</html>
