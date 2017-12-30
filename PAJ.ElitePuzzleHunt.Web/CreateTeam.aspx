<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="CreateTeam.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.CreateTeam" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<form id="createTeamForm" runat="server" clientidmode="Static">
<fieldset>
<legend>Create Team</legend>
<label for="teamName">Team name:</label> <asp:TextBox id="teamName" runat="server" ClientIDMode="Static" /><br />
<label for="password">Password:</label> <asp:TextBox id="password" TextMode="Password" runat="server" ClientIDMode="Static" /><br />
<asp:Label ID="Result" runat="server" /><br />
<asp:Button id="Submit" runat="server" Text="Create Team" onclick="Submit_Click" />
</fieldset>
</form>
</asp:Content>
