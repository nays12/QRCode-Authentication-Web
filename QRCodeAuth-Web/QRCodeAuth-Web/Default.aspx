﻿<%-- 
Purpose: 
Defines the UI for the page

Contributors: 
Marilin Ortuno
Leonor Ortuno
--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QRCodeAuth_Web.Default" %>

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
            <h1>The Authenticat<img src="Images/Logo.jpg" class="imgLogo" />r </h1>
            <%--<img class="image" src="Images/title.JPG" />--%>
        </div>

        <div class="divPageBody divSection">
            <div class="divSection">
				
                <asp:Label ID="Label2" Class="lblSubTitles" runat="server" Text="6-digit code"></asp:Label>
                
                <asp:TextBox ID="txtCode" Class="txb" runat="server"></asp:TextBox>
				<asp:Button ID="btnLogin" Class="button btn btn-success" runat="server" Text="Login" OnClick="btnLogin_Click"/>
                <asp:RegularExpressionValidator Class="lblError" runat="server" id="revCodeValidator" validationexpression="^[0-9]{6}$" ErrorMessage="Invalid Format: Please enter a 6-digit number." ControlToValidate="txtCode" />
            	<asp:Label ID="lblValidCode" Class="lblError" runat="server"></asp:Label>
				<asp:Label ID="lblStatus" Class="lblError" runat="server"></asp:Label>
            </div>

        </div>

    </form>
</body>
</html>
