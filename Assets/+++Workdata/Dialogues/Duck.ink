=== duck ===


= test
# portrait:player1
test:1
# portrait:player2
test:2
# portrait:dad1
test:3
# portrait:dad2
test:4
# portrait:mam1
test:5
# portrait:mam2
test:6
# portrait:zlo1
test:7
# portrait:zlo2
test:8
# portrait:measures1
test:9
# portrait:measures2
test:10
# portrait:stor1
test:11
# portrait:stor2
test:12
# portrait:girl1
test:13
# portrait:girl2
test:14
->END




= apples_start
# portrait:player
Duck: Hey, can you do me a favour?
# portrait:dad
Robot: Uh, sure?
# portrait:mam
Duck: Can you pick up some <color=\#AA0000>apples</color> in the forest for me?
# portrait:zlo
Robot: Yeah, I can do that.

-> END

= apples_running
# portrait:measures
Duck: Hey, do you have my <color=\#AA0000>apples</color>?
# portrait:stor
Robot: Not yet. But I'm working on it!
-> END

= apples_delivering
# portrait:girl
Robot: Here are your <color=\#AA0000>apples</color>.<br>Freshly gathered from the forest.
# portrait:player
Duck: Thanks a bunch!
# portrait:dad
<i>munch munch munch</i>
# portrait:mam
Tasty!
-> END

= apples_finished
Duck:<i>munch munch munch</i>
-> END
