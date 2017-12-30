<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Teams.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Puzzles" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<PAJ:ListPuzzles ID="PuzzleList" runat="server" />
</asp:Content>