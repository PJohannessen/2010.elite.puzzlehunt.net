<%@ Page Title="" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Web.FAQ" %>
<%@ Register Assembly="PAJ.ElitePuzzleHunt.WebControls" Namespace="PAJ.ElitePuzzleHunt.WebControls" TagPrefix="PAJ" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<h2>FAQ</h2>

<p>
<strong>How can we contact you?</strong><br />
See the <%= Html.RouteLink("Contacts", "Contacts") %> page. To send email directly
to Infil, please send to <strong>infil AT the-elite DOT net</strong>. Please avoid
using AIM or MSN for hunt queries.
</p>

<p>
<strong>There's a mistake in this puzzle!</strong><br />
Orly? Please send an email to Infil explaining where you think the
mistake is. If the mistake is real, we will immediately make the
correction and inform the teams. If it is not a mistake, we will let
you know that you need to keep thinking about the puzzle.
</p>

<p>
<strong>What does the difficulty rating mean?</strong><br />
While not always accurate, the difficulty is an attempt at measuring
how many complex or time-consuming steps there are between you and the
final answer. Typically easy puzzles can be solved with just a small
amount of insight and a bit of googling, whereas hard puzzles will
need some solid lateral thinking skills, probably coupled with a large
amount of googling or specific subject research. Do take the
difficulty ratings with a grain of salt, as a puzzle's difficulty can
be easily misjudged.
</p>

<p>
<strong>When will we know all the answers?</strong><br />
After the hunt is over, full solutions will be posted for each
puzzle. While the hunt is ongoing, you will immediately know if you've
answered correctly via the Answers page.
</p>

<p>
<strong>I'm totally, totally stuck. Now what?</strong>
Well, maybe try taking a break and working on another puzzle.
Usually time away from a puzzle may help you get some fresh eyes on it
later. Have you tried to connect the title to the puzzle yet? You can
also always wait for a hint to be revealed, as they'll usually point
you in the correct direction, or give you something new to try. Don't
be afraid to try to randomly search the internet for random keywords
or associations based on the puzzle's data, or to do some research on
some concepts which seem central to the puzzle. Ask a friend (not
involved with the hunt of course) or discuss with your teammate
various ideas for what the different elements of the puzzle could
mean. Try to think outside the box where possible. Sometimes you just
have to "look at" the puzzle for a good while until you can come with
some connection. Don't be afraid to scrap your past notions of how
you're "sure" the puzzle must work, which may be keeping you back from
the key insight needed to progress. A surprising amount of progress
can be made simply by asking "What does this look like to you?", and
then following it up with "okay, then what does that imply?"
</p>

<p>
<strong>Your hunt sucks!</strong>
Well, this is our first time making a hunt, so we tried our best. Sorry
that it wasn't up to your expectations, broseph.
</p>
</asp:Content>