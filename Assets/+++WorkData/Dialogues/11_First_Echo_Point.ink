=== first_echo_point_appears ===
~ Event("echo_symbol_appears_on_wall")
Radio: Do you see it? #avatar:radio #voice:radio_037
Jack: What? #avatar:jack #voice:jack_075
Radio: The sign. Come closer. Look at it. #avatar:radio #voice:radio_038
Jack: What happens if I… #avatar:jack #voice:jack_076
~ Event("show_reality_shift_prompt")
~ Event("enable_first_reality_shift")
-> END

=== first_reality_shift ===
~ Event("player_control_off")
~ Event("enter_echo_world_first_time")
Voices: So that’s where you are. #avatar:radio #voice:radio_039
Jack: Where am I? #avatar:jack #voice:jack_077
Radio: I… remember this. #avatar:radio #voice:radio_040
Radio: Jack… you found it. #avatar:radio #voice:radio_041
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
Radio: What does it say? #avatar:radio #voice:radio_042
Jack: ‘Don’t answer when it knows your name.’ #avatar:jack #voice:jack_078
Radio: That’s strange. #avatar:radio #voice:radio_043
Jack: You knew my name. #avatar:jack #voice:jack_079
Radio: Then perhaps… you shouldn’t talk to me. #avatar:radio #voice:radio_044
Jack: What? #avatar:jack #voice:jack_080
Radio: If you think I’m dangerous… turn me off. I won’t stop you. #avatar:radio #voice:radio_045
Jack: No. Not yet. #avatar:jack #voice:jack_081
Radio: Thank you. #avatar:radio #voice:radio_046
Jack: Not yet. #avatar:jack #voice:jack_082
~ Event("radio_voice_very_quiet")
Radio: Thank you. #avatar:radio #voice:radio_047
~ Event("mh_locker_looted")
~ Event("objective_return_sketchbook_to_emily")
-> END