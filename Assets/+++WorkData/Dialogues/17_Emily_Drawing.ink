VAR emily_drawing_kept = false

=== emily_drawing ===
= start
Emily: You’ve been avoiding me. #avatar:emily
Jack: I haven’t. #avatar:jack
Emily: Brilliant. Problem solved. #avatar:emily
Jack: I’ve been busy. #avatar:jack
Emily: With your radio? #avatar:emily
Emily: I saw you talking to it. #avatar:emily
Jack: So? #avatar:jack
Emily: I never said there was anything wrong with that. #avatar:emily
Jack: Everyone else does. #avatar:jack
Emily: I’m not everyone else. #avatar:emily
~ Event("emily_drawing_quest_started")
-> END

= radio_before_drawing
Radio: She’s curious. #avatar:radio
Jack: She was worried. #avatar:jack
Radio: Maybe. Would you tell her everything? #avatar:radio
Jack: I don’t know. #avatar:jack
Radio: What if she tells Harris? or your parents? They’d take me away. #avatar:radio
Jack: They wouldn’t. #avatar:jack
Radio: Then tell her. Go on. I trust you. #avatar:radio
~ Event("radio_manipulation_emily_warning")
-> END

= show_drawing
Emily: This was in my sketchbook this morning. #avatar:emily
Jack: You drew it. #avatar:jack
Emily: No. #avatar:emily
Jack: It’s your style. #avatar:jack
Emily: That’s what bothers me. #avatar:emily
~ Event("show_emily_warning_drawing")
~ Event("show_emily_drawing_back_text")
Radio: Burn it. #avatar:radio
Jack: What? #avatar:jack
Radio: Sorry. The static… #avatar:radio
Jack: You said burn it. #avatar:jack
Radio: I don’t know why. Looking at it makes me afraid. #avatar:radio
~ Event("present_emily_drawing_choice")
* [Give the drawing back to Emily.]
    ~ emily_drawing_kept = false
    ~ Event("emily_drawing_returned")
    Emily: Thanks. I thought you’d keep it. #avatar:emily
    Jack: Why? #avatar:jack
    Emily: You’ve been keeping everything else to yourself. #avatar:emily
    -> emily_drawing.after_choice
* [Keep the drawing.]
    ~ emily_drawing_kept = true
    ~ Add_State("emily_drawing", 1)
    ~ Event("emily_drawing_added")
    ~ Event("memory_anchor_emily_drawing_unlocked")
    Emily: Okay. Just… Don’t lose it. #avatar:emily
    -> emily_drawing.after_choice

= after_choice
Radio: She doesn’t trust you. #avatar:radio
Jack: Neither do you. #avatar:jack
Radio: I trust you with my life. #avatar:radio
~ Event("emily_drawing_quest_complete")
-> END
