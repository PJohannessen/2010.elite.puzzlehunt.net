﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Puzzle7.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.Puzzle7" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<h2>Puzzle 7</h2>

<p>This is the seventh puzzle.</p>

<form id="puzzleAnswerForm" runat="server">
<fieldset>
<legend>Answer</legend>
<label for="answer">Answer:</label> <asp:TextBox id="answer" runat="server" /><br /><asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
<asp:Label ID="Result" runat="server" /><br />
</fieldset>
</form>
<PAJ:ListPuzzleHints ID="PuzzleHints" runat="server" />
</asp:Content>