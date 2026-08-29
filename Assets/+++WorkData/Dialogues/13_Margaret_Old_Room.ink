=== margaret_old_room ===
= start
Mother: Jack? #avatar:mother #voice:mother_022
Jack: Yeah? #avatar:jack #voice:jack_087
Mother: I’m looking for a little brass key. #avatar:mother #voice:mother_023
Mother: It should be in one of the kitchen boxes. #avatar:mother #voice:mother_024
Jack: Which one? #avatar:jack #voice:jack_088
Mother: I wish I knew. #avatar:mother #voice:mother_025
~ Event("objective_find_margarets_brass_key")
~ Event("margaret_old_room_quest_started")
~ Event("unlock_boarded_room_interaction")
-> END

= david_warning
Father: Leave that room alone. #avatar:father #voice:father_013
Jack: Why? #avatar:jack #voice:jack_089
Father: The floor might not be safe. #avatar:father #voice:father_014
Jack: Did you check? #avatar:jack #voice:jack_090
Father: Jack, leave it. #avatar:father #voice:father_015
~ Event("david_warned_about_old_room")
-> END

= radio_warning
Radio: He’s probably right. #avatar:radio #voice:radio_050
Jack: About the room? #avatar:jack #voice:jack_091
Radio: You shouldn’t go in there. #avatar:radio #voice:radio_051
Jack: Why does that sound like a challenge? #avatar:jack #voice:jack_092
Radio: Does it? #avatar:radio #voice:radio_052
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
Mother: Where did you find it? #avatar:mother #voice:mother_026
Jack: In the boarded-up room. #avatar:jack #voice:jack_093
Mother: Your father told you to stay out of there. #avatar:mother #voice:mother_027
Jack: I was helping you. #avatar:jack #voice:jack_094
Mother: And I’m trying to keep you safe. #avatar:mother #voice:mother_028
~ Add_State("money_pence", 100)
~ Event("receive_one_pound_from_margaret")
~ Event("margaret_old_room_quest_complete")
-> END

= radio_afterward
Radio: You helped her. #avatar:radio #voice:radio_053
Jack: She was worried. #avatar:jack #voice:jack_095
Radio: Of course. She just has a quiet way of showing it. #avatar:radio #voice:radio_054
-> END
