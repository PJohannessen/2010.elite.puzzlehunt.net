<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Users" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<PAJ:ListUsers ID="UserList" runat="server" />
</asp:Content>
