<%@ Page Title="Elite Puzzle Hunt 2010 - Rules" Language="C#" MasterPageFile="~/ElitePuzzleHunt.Master" AutoEventWireup="true" CodeBehind="Rules.aspx.cs" Inherits="PAJ.ElitePuzzleHunt.Rules" %>
<asp:Content ID="ClientContent" ContentPlaceHolderID="ContentPlaceholder" runat="server">
<h2>Rules</h2>

<h3>Teams:</h3>
<ul>
<li>Each team consists of a maximum of 2 people, at least one of which
must be a member of the Elite or Mario Kart communities. We're trying
to avoid teams containing a non-Elite "ringer", since our puzzles are
fairly modest in scope and expert solvers would likely have no trouble
with them, so please don't try to do that.</li>
<li>There is to be absolutely no collaboration between members of two
different teams on hunt-related topics. This includes things like
trading answers, giving hints, telling another team that you have or
haven't solved a certain puzzle, or otherwise circumventing the system
that distributes the puzzles/hints. In general, if it feels like
you're cheating, you probably are. Please don't.</li>
<li>Registration is done at the appropriate link on the left sidebar. Once
you have joined a team, you <em>cannot leave it</em>, so pick wisely!</li>
</ul>

<h3>Puzzles</h3>
<ul>
<li>There are 10 puzzles in this hunt of varying difficulty for you to
solve. They are all available at the start of the hunt, and are
accessed from the <%= Html.RouteLink("Puzzles page", "puzzles-browse") %>.
To solve a puzzle, type the case- and spacing-insensitive answer in the
Answers page. You are not penalized for incorrect guesses, and you may
guess as many times as you like for each puzzle. You will be informed if
you have entered the correct answer, and then you can move on to other
puzzles.</li>

<li>>Unlike the structure of some other hunts, this hunt is designed to
work on the time schedule of each individual team. When either of the
team members clicks to get access to a puzzle for the first time, a
puzzle-specific timer will start for that team. This timer will be in
effect until you submit the correct answer, at which point it will
stop. Points will be awarded to the <em>fastest 5 teams</em> that solve
each puzzle, in the order of: 8 points, 6 points, 4 points, 2 points,
and 1 point in order of speed. If you are the 6th fastest team (or you
don't manage to solve it at all), you will not receive points for this
puzzle. The timer may be readjusted at the organizer's discretion
based on the structure of certain puzzles. You will be able to see
your timers on the Puzzles page, but you will <strong>not</strong> be able to
see any other team's timers, including how many teams have solved a
given puzzle. You won't know until the hunt is over, so keep trying:
chances are, if you're stuck on a puzzle, other people are too, so you
may still be able to earn points on the puzzle. Don't give up!</li>

<li>Because of this structure, you can start the puzzle at the most
convenient time for your team, with no negative consequences for
scoring. If you are not here when the hunt starts, or you've solved
all your active puzzles and want to sleep, it will not hurt your
team's chances of scoring points. Be careful about "just taking a
look" at a puzzle that you don't intend to invest immediate time in
solving, however, as that will start your timer! It is expected that
both team members will come to an agreement on when to start the timer
for each puzzle, as their schedules allow. <strong>Please be careful about
this</strong>, as there will be a near zero tolerance policy about
restarting timers.</li>

<li>Three hints will be provided periodically after you have begun
solving a puzzle, in case you find yourself not making any progress.
The first hint will be given 6 hours after the puzzle's timer has
started, the second hint will be given 12 hours after, and the third
hint will be given 18 hours after. These will appear on the page of that
specific puzzle, and will give some insight as to how to progress through
the various stages of the puzzle. If you are stuck on a puzzle, waiting
for the next available hint is one option, though you may potentially score
fewer points due to time elapsed.</li>

<li>Some of the competitors have also written puzzles that are in the
hunt. We've struggled to come up with a fair scoring system for this
(there may not be one), but we're going to go with the following. You
may choose one of the following two options:
a) If one of the members of a team has written a puzzle, you may
accept the points value of 3rd place for your team (4 points). The
five fastest teams will still obtain the points as described above.
You will then not solve this puzzle. <strong>Do NOT</strong> start your timer
for this puzzle before notifying Infil or Neo about your decision. If
you do, you will be forced to go with...
b) You may choose to attempt to solve this puzzle, providing that the
author of the puzzle <strong>does not discuss anything with his
teammate</strong> about it. Yes, this is the honor system, but I trust the
puzzle authors enough. If you choose this option, you must then solve
the puzzle as normal with just one person. The author may not provide
any hints or clues, any "you're on the right track"s, or discuss the
puzzle in any way, shape, or form with his teammate. I can't really
police this, but when I say no discussion, I really mean <strong>NO</strong>
discussion. However, you will receive 1 extra point, in addition to
the points received for your speed ranking, for solving it in this
fashion. </li>

<li>We understand that the scoring system may prove to be unfair in the
end (and we will reevaluate the system after the hunt), but we're
going to try the system out and see how it goes. Since this is just
for fun anyway, we hope people will keep this in mind.</li>
</ul>

<h3>How to Solve Puzzles</h3>
<ul>
<li>Each puzzle has a title. All puzzles are solvable without the title,
but it may give you some insight on how to proceed at some stage of
the solving process, or it may make sense in retrospect after the
puzzle has been solved. If you are stuck solving a puzzle, consider
trying to deduce some meaning out of the title and how it might
influence the interpretation of the puzzle's data.</li>
<li>The meat of each puzzle will be a seemingly random collection of
information. Unlike traditional puzzles such as crosswords that have a
predictable and well-known structure, the goal of each puzzle in this
hunt is to discover a single hidden word (or phrase) by following a
series of steps using deductive reasoning. You may need to find
patterns in the information presented to you, liken it to traditional
forms of puzzles, or do some research and make some sort of lateral
"leap" based on patterns in the data or the puzzle's layout.</li>
<li>Doing research is not only allowed, it is encouraged and essentially
mandatory. You can use the internet to its fullest extent to help you
solve puzzles. You can use computer programs (such as web anagrammers
or crossword solvers) if you feel that may be important. In fact,
using Google or Wikipedia is almost a mandatory first step for most
puzzles you will see in this or any other hunt. You may ask family and
friends, who may be knowledgable on a particular topic, for their
insight in a puzzle. The only stipulation here is that the person
assisting you: a) is not a member of any other team in the hunt, and
b) has not already assisted another team on the same puzzle. Please
read part b) again.</li>
<li>The puzzles are designed such that you will "know" you are on the
right track, since things should fall into place nicely, and the
puzzle begins to transform towards the ultimate goal of finding a
single word or phrase. As such, when you see certain patterns or
similarities between the data in the puzzle, it is almost certain that
these patterns or similarities are intentional, and you should further
explore what this implies. Noticing these patterns with a keen eye is
important to being a good solver.</li>
<li>It may be difficult for first-time hunters to transform a bunch of
information to a single word. Most puzzles are done in multiple
"steps", such that the first thing to do with the puzzle may not
relate to the final answer at all. If you have an inkling as to what
some information relates to, explore it. Write down your ideas and see
if they come together later. As you explore the puzzle, you will
likely see "how" you are supposed to get a word or phrase out of it.
Don't worry about it at the start. (Note: with words and numbers,
common tricks are to read down the starting letter (or diagonal) of
the words to form new words, or to use numbers to index into matching
words)</li>
<li>Use <a href="http://docs.google.com/">Google Docs</a> spreadsheets to catalog all your thought processes,
and share the document with your teammate. This is an absolutely
imperative way to share all the information you've collected, and it
also is an easy way for one person to work on the puzzle while the
other person is away (he can then just check the spreadsheet later for
any new leads). It's also the perfect way to do joint research so you
always know what has or hasn't been looked at, since the spreadsheet
updates in real time. Start by copying down the puzzle into the
spreadsheet and making notes of what you see, then start filling in
information as need be. Every single team should use Google Docs to
solve these puzzles. Take it from us, your life will be made
substantially easier.</li>
<li>Check out tips on other puzzle sites' help pages, such as:
<a href="http://puzzle.cisra.com.au/guide.php">CiSRA Puzzle Competition Website</a>
They can give important tips for what to do when you are stuck, or how to go
about solving certain types of puzzles.</li>
</ul>

<h3>Website</h3>
<ul>
<li>
Only one website account per hunter is permitted. You must be present in a team before any attempt at
puzzles can be made.
</li>
<li>
As this website has been custom made in order to meet our Hunt requirements, there may still be
some bugs and/or flaws associated with the functionality of the website, despite all efforts to
avoid this. If you believe you have encountered such a problem, particularly if it has somehow
affected the timing, scoring or validity of a puzzle, you are asked are to inform either Infil or
Neo as soon as possible so that the situation can be rectified. Any <em>intentional</em>, <em>malicious</em>
exploitation of such an error will result in a team's immediate disqualification from the hunt.
</li>
</ul>
</asp:Content>
