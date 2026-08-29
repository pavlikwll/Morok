=== margaret_old_room ===
= start
Mother: Jack? #avatar:mother
Jack: Yeah? #avatar:jack
Mother: I’m looking for a little brass key. #avatar:mother
Mother: It should be in one of the kitchen boxes. #avatar:mother
Jack: Which one? #avatar:jack
Mother: I wish I knew. #avatar:mother
~ Event("objective_find_margarets_brass_key")
~ Event("margaret_old_room_quest_started")
~ Event("unlock_boarded_room_interaction")
-> END

= david_warning
David: Leave that room alone. #avatar:father
Jack: Why? #avatar:jack
David: The floor might not be safe. #avatar:father
Jack: Did you check? #avatar:jack
David: Jack, leave it. #avatar:father
~ Event("david_warned_about_old_room")
-> END

= radio_warning
Radio: He’s probably right. #avatar:radio
Jack: About the room? #avatar:jack
Radio: You shouldn’t go in there. #avatar:radio
Jack: Why does that sound like a challenge? #avatar:jack
Radio: Does it? #avatar:radio
~ Event("unlock_old_room_echo_route")
-> END

= enter_echo_room
~ Event("enter_old_room_echo_world")
~ Event("open_boarded_room_in_echo_world")
~ Event("unlock_boarded_room_from_inside")
~ Event("old_room_unlocked_real_world")
-> END

= open_kitchen_box
~ Add_State("margaret_brass_key", 1)
~ Add_State("hale_family_photograph", 1)
~ Add_State("old_radio_component", 1)
~ Event("margaret_brass_key_added")
~ Event("hale_family_photograph_added")
~ Event("old_radio_component_added")
~ Event("show_hale_family_photograph")
~ Event("highlight_missing_child_on_photograph")
~ Event("objective_return_brass_key_to_margaret")
-> END

= return_key
~ Add_State("margaret_brass_key", -1)
Mother: Where did you find it? #avatar:mother
Jack: In the boarded-up room. #avatar:jack
Mother: Your father told you to stay out of there. #avatar:mother
Jack: I was helping you. #avatar:jack
Mother: And I’m trying to keep you safe. #avatar:mother
~ Add_State("money_pence", 100)
~ Event("receive_one_pound_from_margaret")
~ Event("margaret_old_room_quest_complete")
-> END

= radio_afterward
Radio: You helped her. #avatar:radio
Jack: She was worried. #avatar:jack
Radio: Of course. She just has a quiet way of showing it. #avatar:radio
-> END
