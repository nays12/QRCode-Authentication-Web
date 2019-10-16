﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QRCodeAuth_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Authenticator</title>
    
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <link href="StyleSheet.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="divTitle" style="background-color:transparent">
            <img class="image" src="Images/title.JPG" />
        </div>

        <div class="divPageBody divSection">
            <asp:Button ID="Button1" Class="button btn btn-success" runat="server" Text="Log In to Web" />
            <div class="divSection">
                <asp:Label ID="Label2" Class="lblSubTitles" runat="server" Text="6-digit code"></asp:Label>
                
                <asp:TextBox ID="TextBox1" Class="txb" runat="server"></asp:TextBox>
                
                <br />
            </div>

        </div>

    </form>
</body>
</html>
