<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.User" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<PAJ:ViewUser ID="ViewUser" runat=server />
</asp:Content>
