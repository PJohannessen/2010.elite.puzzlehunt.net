<%@ Page Title="Elite Puzzle Hunt 2010 - Symbolic Cacophony" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Puzzle7.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Puzzle7" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<span style="font-size: 18px;">Symbolic Cacaphony</span><br/>
Author: Cyberwrath<br/>
Difficulty: Hard
<br/><br/>

<table border=0 cellpadding=0 cellspacing=0>
<tr>
<td>

<ol>
<li>EMBASSY / DRAGOON
<li>SPECTRUM / PUPPETS
<li>CRIBBAGE / PIPELESS
<li>SANGUINE / CUSTARD
<li>RECYCLED / MISORDER
<li>CENTRIC / WRANGLER
<li>ACRES / GROWTH
<li>DECLARED / NINETEEN
<li>TUNIC / ABASH
<li>REMARKS / ALPACAS
<li>TURBOCAR / ORDINARY
<li>SEPPUKU / HOLELESS
<li>BARBARIC / CAPSTONE
<li>PHARMACY / ICONICAL
<li>BADLY / OGRES
</td>
<td width=100>&nbsp;</td>
<td valign=top>
<table border=3 cellpadding=20 cellspacing=0>
<tr>
<td>
________ (1)<br/>
________ (7)<br/>
________ (6)<br/>
________ (8)<br/>
________ (5)<br/>
________ (4)<br/>
</td>
<td valign=top>
________ (8)<br/>
________ (7)<br/>
</td>
<td valign=top>
________ (5)<br/>
________ (4)<br/>
________ (7)<br/>
</td>
<td valign=top>
________ (3)<br/>
________ (1)<br/>
________ (2)<br/>
________ (2)<br/>
</td></tr>
</table>

</td></tr>
</table>

<br><br>

<form id="puzzleAnswerForm" runat="server">
<fieldset>
<legend>Answer</legend>
<label for="answer">Answer:</label> <asp:TextBox id="answer" runat="server" /><br /><asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
<asp:Label ID="Result" runat="server" /><br />
</fieldset>
</form>
</asp:Content>