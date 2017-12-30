<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Login" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<form id="loginForm" runat="server">
<fieldset>
<legend>Login</legend>
<label for="username">Username:</label> <asp:TextBox id="username" runat="server" /><br />
<label for="password">Password:</label> <asp:TextBox id="password" TextMode="Password" runat="server" /><br />
<asp:Label ID="Result" runat="server" /><br />
<asp:Button id="Submit" runat="server" Text="Login" onclick="Submit_Click" />
</fieldset>
</form>
<%= Html.RouteLink("Need an account?", "user-signup") %>
</asp:Content>
