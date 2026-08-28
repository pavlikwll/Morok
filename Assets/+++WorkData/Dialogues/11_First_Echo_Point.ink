=== first_echo_point_appears ===
~ Event("echo_symbol_appears_on_wall")
Radio: Do you see it? #avatar:radio
Jack: What? #avatar:jack
Radio: The sign. Come closer. Look at it. #avatar:radio
Jack: What happens if I… #avatar:jack
~ Event("show_reality_shift_prompt")
~ Event("enable_first_reality_shift")
-> END

=== first_reality_shift ===
~ Event("player_control_off")
~ Event("enter_echo_world_first_time")
Voices: So that’s where you are. #avatar:radio
Jack: Where am I? #avatar:jack
Radio: I… remember this. #avatar:radio
Radio: Jack… you found it. #avatar:radio
~ Event("unlock_mh_locker_echo_world")
~ Event("first_reality_shift_complete")
~ Event("player_control_on")
-> END

=== open_mh_locker ===
~ Event("open_mh_locker")
~ Add_State("emily_blue_sketchbook", 1)
~ Add_State("broken_quartz_voice_crystal", 1)
~ Add_State("three_children_faded_photo", 1)
~ Add_State("michael_warning_note", 1)
~ Event("emily_blue_sketchbook_added")
~ Event("broken_quartz_voice_crystal_added")
~ Event("three_children_faded_photo_added")
~ Event("michael_warning_note_added")
~ Event("show_michael_warning_note")
Radio: What does it say? #avatar:radio
Jack: ‘Don’t answer when it knows your name.’ #avatar:jack
Radio: That’s strange. #avatar:radio
Jack: You knew my name. #avatar:jack
Radio: Then perhaps… you shouldn’t talk to me. #avatar:radio
Jack: What? #avatar:jack
Radio: If you think I’m dangerous… turn me off. I won’t stop you. #avatar:radio
Jack: No. Not yet. #avatar:jack
Radio: Thank you. #avatar:radio
Jack: Not yet. #avatar:jack
~ Event("radio_voice_very_quiet")
Radio: Thank you. #avatar:radio
~ Event("mh_locker_looted")
~ Event("objective_return_sketchbook_to_emily")
-> END
