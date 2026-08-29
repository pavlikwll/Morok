VAR emily_drawing_kept = false

=== emily_drawing ===
= start
Emily: You’ve been avoiding me. #avatar:emily #voice:emily_023
Jack: I haven’t. #avatar:jack #voice:jack_111
Emily: Brilliant. Problem solved. #avatar:emily #voice:emily_024
Jack: I’ve been busy. #avatar:jack #voice:jack_112
Emily: With your radio? #avatar:emily #voice:emily_025
Emily: I saw you talking to it. #avatar:emily #voice:emily_026
Jack: So? #avatar:jack #voice:jack_113
Emily: I never said there was anything wrong with that. #avatar:emily #voice:emily_027
Jack: Everyone else does. #avatar:jack #voice:jack_114
Emily: I’m not everyone else. #avatar:emily #voice:emily_028
~ Event("emily_drawing_quest_started")
-> END

= radio_before_drawing
Radio: She’s curious. #avatar:radio #voice:radio_064
Jack: She was worried. #avatar:jack #voice:jack_115
Radio: Maybe. Would you tell her everything? #avatar:radio #voice:radio_065
Jack: I don’t know. #avatar:jack #voice:jack_116
Radio: What if she tells Harris? or your parents? They’d take me away. #avatar:radio #voice:radio_066
Jack: They wouldn’t. #avatar:jack #voice:jack_117
Radio: Then tell her. Go on. I trust you. #avatar:radio #voice:radio_067
~ Event("radio_manipulation_emily_warning")
-> END

= show_drawing
Emily: This was in my sketchbook this morning. #avatar:emily #voice:emily_029
Jack: You drew it. #avatar:jack #voice:jack_118
Emily: No. #avatar:emily #voice:emily_030
Jack: It’s your style. #avatar:jack #voice:jack_119
Emily: That’s what bothers me. #avatar:emily #voice:emily_031
~ Event("show_emily_warning_drawing")
~ Event("show_emily_drawing_back_text")
Radio: Burn it. #avatar:radio #voice:radio_068
Jack: What? #avatar:jack #voice:jack_120
Radio: Sorry. The static… #avatar:radio #voice:radio_069
Jack: You said burn it. #avatar:jack #voice:jack_121
Radio: I don’t know why. Looking at it makes me afraid. #avatar:radio #voice:radio_070
~ Event("present_emily_drawing_choice")
* [Give the drawing back to Emily.]
    ~ emily_drawing_kept = false
    ~ Event("emily_drawing_returned")
    Emily: Thanks. I thought you’d keep it. #avatar:emily #voice:emily_032
    Jack: Why? #avatar:jack #voice:jack_122
    Emily: You’ve been keeping everything else to yourself. #avatar:emily #voice:emily_033
    -> emily_drawing.after_choice
* [Keep the drawing.]
    ~ emily_drawing_kept = true
    ~ Add_State("emily_drawing", 1)
    ~ Event("emily_drawing_added")
    ~ Event("memory_anchor_emily_drawing_unlocked")
    Emily: Okay. Just… Don’t lose it. #avatar:emily #voice:emily_034
    -> emily_drawing.after_choice

= after_choice
Radio: She doesn’t trust you. #avatar:radio #voice:radio_071
Jack: Neither do you. #avatar:jack #voice:jack_123
Radio: I trust you with my life. #avatar:radio #voice:radio_072
~ Event("emily_drawing_quest_complete")
-> END