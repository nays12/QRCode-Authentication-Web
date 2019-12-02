<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="QRCodeAuth_Web.CreateEvent" %>

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
			<asp:Label ID="Label1" runat="server" class="lblSubTitles" Text="Create New Event"></asp:Label>

			<div class="divSection">
				<asp:Label ID="Label2" runat="server" Class="lbl" Text="Event Type"></asp:Label>

				<asp:DropDownList ID="ddlEventType" runat="server" Class="txb">
					<asp:ListItem>Event</asp:ListItem>
					<asp:ListItem>Lecture</asp:ListItem>
					<asp:ListItem>Meeting</asp:ListItem>
				</asp:DropDownList>

				<asp:Label ID="Label5" runat="server" Class="lbl" Text="Name of Event"></asp:Label>
				<asp:TextBox ID="txtName" runat="server" Class="txb"></asp:TextBox>

				<asp:Label ID="Label7" runat="server" Class="lbl" Text="Event Location"></asp:Label>
				<asp:TextBox ID="txtLocation" runat="server" Class="txb"></asp:TextBox>

				<asp:Label ID="Label8" runat="server" Class="lbl" Text="Date"></asp:Label>
				<asp:TextBox ID="txtDate" runat="server" Class="txb" TextMode="Date"></asp:TextBox>

				<asp:Label ID="Label9" runat="server" Class="lbl" Text="Start Time"></asp:Label>
				<asp:TextBox ID="txtStartTime" runat="server" Class="txb" TextMode="DateTime"></asp:TextBox>

				<asp:Label ID="Label10" runat="server" Class="lbl" Text="End Time"></asp:Label>
				<asp:TextBox ID="txtEndTime" runat="server" Class="txb" TextMode="DateTime"></asp:TextBox>

				<asp:Label ID="Label11" runat="server" Class="lbl" Text="Description"></asp:Label>
				<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Class="txb" Height="60px"></asp:TextBox>

				<asp:Label ID="Label3" runat="server" Class="lbl" Text="Credentials Required"></asp:Label>

				<asp:CheckBoxList ID="cblCredentialsNeeded" runat="server">
					<asp:ListItem>Name</asp:ListItem>
					<asp:ListItem>Email</asp:ListItem>
					<asp:ListItem Value="IdNumber">School ID</asp:ListItem>
					<asp:ListItem>Birthdate</asp:ListItem>
					<asp:ListItem>Address</asp:ListItem>
					<asp:ListItem Value="PhoneNumber">Phone Number</asp:ListItem>
					<asp:ListItem>Major</asp:ListItem>
					<asp:ListItem>Classification</asp:ListItem>
					<asp:ListItem Value="WorkTitle">Work Title</asp:ListItem>
				</asp:CheckBoxList>

			</div>
			<asp:Label ID="lblStatus" runat="server"></asp:Label>
			<asp:Button ID="btnCreate" runat="server" Class="button btn btn-success" Text="Create Event" OnClick="btnCreate_Click" />
			<asp:Button ID="btnManage" runat="server" Class="button btn btn-success" Text="Manage Event" OnClick="btnManage_Click" />
			<asp:Button ID="btnDone" runat="server" Class="button btn btn-secondary" Text="Done" OnClick="btnDone_Click" />
		</div>
    </form>
</body>
</html>
