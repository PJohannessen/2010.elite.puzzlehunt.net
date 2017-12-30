<%@ Page Title="Elite Puzzle Hunt 2010 - Gotta Solve 'Em All" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Puzzle4.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Puzzle4" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<span style="font-size: 18px;">Gotta Solve 'Em All</span><br/>
Author: QB<br/>
Difficulty: Easy
<br/><br/>

<table border=0 cellpadding=0 cellspacing=0>
<tr><td width=60>#086</td><td>look</td></tr>
<tr><td width=60>#120</td><td>inflicted with iron oxide</td></tr>
<tr><td width=60>#108</td><td>lightly poking or stroking a sensitive part of the body</td></tr>
<tr><td width=60>#050</td><td>overturned a pinball machine?</td></tr>
<tr><td width=60>#097</td><td>miniature horse</td></tr>
<tr><td width=60>#121</td><td>current</td></tr>
<tr><td width=60>#029</td><td>decree</td></tr>
<tr><td width=60>#042</td><td>swell</td></tr>
<tr><td width=60>#046</td><td>practice boxing</td></tr>
<tr><td width=60>#023</td><td>Japanese alcohol</td></tr>
<tr><td width=60>#121</td><td>slaveowner</td></tr>
<tr><td width=60>#066</td><td>hunt illegally</td></tr>
<tr><td width=60>#010</td><td>proof of purchase</td></tr>
<tr><td width=60>#073</td><td>a vocal expression</td></tr>
<tr><td width=60>#146</td><td>a popular red wine</td></tr>


</table>

<br /><br />

<form id="puzzleAnswerForm" runat="server">
<fieldset>
<legend>Answer</legend>
<label for="answer">Answer:</label> <asp:TextBox id="answer" runat="server" /><br /><asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
<asp:Label ID="Result" runat="server" /><br />
</fieldset>
</form>
</asp:Content>
