<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Teams" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<PAJ:ListTeams ID="TeamList" runat="server" />
<span>Want a <%= Html.RouteLink("new team", "team-create")%>?</span>
</asp:Content>