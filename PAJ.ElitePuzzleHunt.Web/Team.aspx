<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" CodeBehind="Team.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Team" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<PAJ:ViewTeam ID="ViewTeam" runat="server" />
<form id="joinTeamForm" runat="server" clientidmode="Static">
<fieldset>
<legend>Join Team</legend>
<label for="password">Password:</label> <asp:TextBox id="password" TextMode="Password" runat="server" /><br />
<asp:Label ID="Result" runat="server" /><br />
<asp:Button id="Submit" runat="server" Text="Join Team" onclick="Submit_Click" />
</fieldset>
</form>
</asp:Content>
