<%@ Page Title="Elite Puzzle Hunt 2010 - Man of the World" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Puzzle2.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Puzzle2" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<span style="font-size: 18px;">Man of the World</span><br/>
Author: Cyberwrath<br/>
Difficulty: Easy
<br /><br />

<strong>Try capping it off!</strong><br/>
<img src="http://elitepuzzlehunt.patrickjohannessen.com/images/face.jpg"/>

<br /><br />

<form id="puzzleAnswerForm" runat="server">
<fieldset>
<legend>Answer</legend>
<label for="answer">Answer:</label> <asp:TextBox id="answer" runat="server" /><br /><asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
<asp:Label ID="Result" runat="server" /><br />
</fieldset>
</form>
</asp:Content>
