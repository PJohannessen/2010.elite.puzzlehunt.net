<%@ Page Title="Elite Puzzle Hunt 2010 - Overheard at Grauman's" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Puzzle1.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Puzzle1" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">

<span style="font-size: 18px;">Overheard at Grauman's</span><br/>
Author: Shep<br/>
Difficulty: Easy
<br/><br/>

Allow me to introduce myself. I am Ernst Stavro Blofeld.<br/>
I coulda been a contender.<br/>
And like that... he's gone.<br/>
Here's looking at you, kid.<br/>
I love the smell of napalm in the morning!<br/>
What's the most you ever lost on a coin toss?<br/>
You talkin' to me?<br/>
Fat man, you shoot a great game of pool.<br/>
Houston, we have a problem.<br/>
Vote for Pedro.<br/>
Why so serious?<br/>
My precious...<br/>
Man, you come right out of a comic book.<br/>
I'll be back!<br/>
This is my house, I have to defend it.<br/>
You know, Billy. We blew it.<br/>
Choose life.<br/>
Last night I dreamt I went to Manderley again.<br/>
It's a hell of a thing killin' a man.<br/>
I'm the king of the world!<br/>
The price is wrong, bitch!<br/>

<br><br>

<form id="puzzleAnswerForm" runat="server">
<fieldset>
<legend>Answer</legend>
<label for="answer">Answer:</label> <asp:TextBox id="answer" runat="server" /><br /><asp:Button id="Submit" runat="server" Text="Submit" onclick="Submit_Click" />
<asp:Label ID="Result" runat="server" /><br />
</fieldset>
</form>
</asp:Content>
