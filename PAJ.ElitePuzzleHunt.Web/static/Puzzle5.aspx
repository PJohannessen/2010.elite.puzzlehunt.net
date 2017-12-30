<%@ Page Title="Elite Puzzle Hunt 2010 - Xbox Controller vs. Keyboard" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Puzzle5.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Puzzle5" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<span style="font-size: 18px;">Xbox Controller vs. Keyboard</span><br/>
Author: Infil<br/>
Difficulty: Medium
<br/><br/>

<span style="text-align:center; font-family:Arial; font-size:14px;">

<table border=3 cellpadding=10 cellspacing=10>
<tr>
<td>pro jules<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/01.jpg"/></td>
<td>DeadManFloats<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/02.jpg"/></td>
<td>Hakuna1337<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/03.jpg"/></td>
<td>Fulvor<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/04.jpg"/></td>
<td>Wayori<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/05.jpg"/></td>
<td>adamhoke<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/06.jpg"/></td>
<td>Lord Belphegor<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/07.jpg"/></td>
</tr>
<tr>
<td>yegg<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/08.jpg"/></td>
<td>omgwtfdreadhead<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/09.jpg"/></td>
<td>GeneralPhats<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/10.jpg"/></td>
<td>Stalker3333<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/11.jpg"/></td>
<td>CanadaChad<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/12.jpg"/></td>
<td>FerociousWeight<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/13.jpg"/></td>
<td>Fayd Harkkonnen<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/14.jpg"/></td>
</tr>
<tr>
<td>A7XSkullKid<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/15.jpg"/></td>
<td>GoldenJimbo007<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/16.jpg"/></td>
<td>Ngamer64<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/17.jpg"/></td>
<td>Otaqon<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/18.jpg"/></td>
<td>Neo26988<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/19.jpg"/></td>
<td>ElectTheDesert<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/20.jpg"/></td>
<td>Inferno X44<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/21.jpg"/></td>
</tr>
<tr>
<td>Johnbuckmen<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/22.jpg"/></td>
<td>srX22<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/23.jpg"/></td>
<td>Nena Skywalker<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/24.jpg"/></td>
<td>UnbuckledTurtle<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/25.jpg"/></td>
<td>LOST Nr<br><img src="http://elitepuzzlehunt.patrickjohannessen.com/images/26.jpg"/></td>
</tr>
</table>

<br><br><br>

<table border=1 cellpadding=0 cellspacing=0>
<tr height=100>
<td width=85>&nbsp;</td>
<td width=85>&nbsp;</td>
<td width=85>&nbsp;</td>
<td width=85>Achievement given in German</td>
<td width=85>Character earned for beating drum career</td>
<td width=85>Common letter between mother, father, son</td>
<td width=85>Conference represented by achievement icon</td>
<td width=85>Crab mini-boss on beach world</td>
<td width=85>Padded last line of defense</td>
<td width=85>Achievement for old friendship</td>
<td width=85>&nbsp;</td>
</tr>
</table>
<table border=1 cellpadding=0 cellspacing=0>
<tr height=100>
<td width=85>Race of machinist squad member</td>
<td width=85>Heavy, lovable object in prequel</td>
<td width=85>Chapter one boss</td>
<td width=85>White-clothed poster boy</td>
<td width=85>Enemy directly to your left</td>
<td width=85>Button for changing weapons</td>
<td width=85>Restores all health</td>
<td width=85>Third world, sixth door</td>
<td width=85>Perk to sprint longer</td>
<td width=85>Achievement for using sharp wire</td>
<td width=85>&nbsp;</td>
</tr>
</table>
<table border=1 cellpadding=0 cellspacing=0>
<tr height=100>
<td width=85>&nbsp;</td>
<td width=85>Place to buy health upgrades</td>
<td width=85>Journey presence on disc</td>
<td width=85>Lead character's headquarters</td>
<td width=85>ESRB rating</td>
<td width=85>Male protagonist last name</td>
<td width=85>First achievement obtained in story mode</td>
<td width=85>First name of titular location founder</td>
<td width=85>Battle currency spent on endgame upgrades</td>
<td width=85>Act five, chapter six</td>
</tr>
</table>



</span>


<br /><br />

<form id="puzzleAnswerForm" runat="server">
<fieldset>
<legend>Answer</legend>
<label for="answer">Answer:</label> <asp:TextBox id="answer" runat="server" /><br /><asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
<asp:Label ID="Result" runat="server" /><br />
</fieldset>
</form>
</asp:Content>
