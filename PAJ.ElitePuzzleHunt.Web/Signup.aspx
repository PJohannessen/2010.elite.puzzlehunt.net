<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" CodeBehind="Signup.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Signup" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<form id="signupForm" runat="server">
<fieldset>
<legend>Signup</legend>
<label for="username">Username:</label> <asp:TextBox id="username" runat="server" /><br />
<label for="password">Password:</label> <asp:TextBox id="password" TextMode="Password" runat="server" /><br />
<asp:Label ID="Result" runat="server" /><br />
<asp:Button id="Submit" runat="server" Text="Create User" onclick="Submit_Click" />
</fieldset>
</form>
</asp:Content>
