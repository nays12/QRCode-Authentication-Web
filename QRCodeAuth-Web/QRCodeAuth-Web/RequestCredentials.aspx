<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestCredentials.aspx.cs" Inherits="QRCodeAuth_Web.RequestCredentials" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

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
            <asp:Label ID="lblSubtitle" runat="server" Class="lblSubTitles" Text="Select the credentials to collect"></asp:Label>
            <div class="divSection">
                <asp:CheckBoxList ID="cblRequestedCredentials" runat="server" >
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>Email</asp:ListItem>
                    <asp:ListItem>ID Number</asp:ListItem>
                    <asp:ListItem>Date of Birth</asp:ListItem>
                    <asp:ListItem>Address</asp:ListItem>
                    <asp:ListItem>PhoneNumber</asp:ListItem>
                    <asp:ListItem>Major</asp:ListItem>
                    <asp:ListItem>Classification</asp:ListItem>
                    <asp:ListItem>Work Title</asp:ListItem>
                </asp:CheckBoxList>
				<asp:Image ID="imgQRCode" runat="server" CssClass="image" Height="300px" Width="300px" Visible="False" />
                
			</div>  
			<asp:Label ID="lblOwnerId" style="color:#005073" runat="server"></asp:Label>

            

			<br />
			<asp:Label ID="lblOwnerName" style="color:#005073" runat="server"></asp:Label>

            

			<br />
			<asp:Label ID="lblOwnerType" style="color:#005073" runat="server"></asp:Label>

            

			<br />
			<br />

            <div style="overflow-x:auto">
			<asp:GridView ID="gvCreds" class="GridView" runat="server" AutoGenerateColumns="False">
					<Columns>
						<asp:BoundField DataField="CredentialType" HeaderText="Type" />
						<asp:BoundField DataField="Name" HeaderText="Name" />
						<asp:BoundField DataField="Value" HeaderText="Value" />
						<asp:BoundField DataField="IssueDate" HeaderText="Date Issued" DataFormatString="{0:d}"/>
						<asp:BoundField DataField="ExpirationDate" HeaderText="Expiration Date" DataFormatString="{0:d}" />
						<asp:BoundField DataField="IsValid" HeaderText="Valid" />
					</Columns>
			</asp:GridView>
            </div>
			<asp:Button ID="btnGetCreds" runat="server" Class="button btn btn-success" Text="Get Credentials" OnClick="btnGetCreds_Click" />
            <asp:Button ID="btnConfirm" runat="server" Class="button btn btn-success" Text="Comfirm" OnClick="btnConfirm_Click" />
            <asp:Button ID="btnCancel" runat="server" Class="BtnCancel btn" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </form>
</body>
</html>
