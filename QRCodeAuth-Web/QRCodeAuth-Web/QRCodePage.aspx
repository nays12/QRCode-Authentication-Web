<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QRCodePage.aspx.cs" Inherits="QRCodeAuth_Web.QRCodePage" %>

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
            <div class="divSection">
				<asp:Image ID="imageQRCode" class="image" runat="server" Height="300px" Width="300px" src="Images/QRCodes/generatedQR.jpg"/>
                <asp:Button ID="btnDone" Class="button btn btn-success" runat="server" Text="Done" OnClick="btnDone_Click" />
			</div>  
         </div>
    </form>
</body>
</html>
