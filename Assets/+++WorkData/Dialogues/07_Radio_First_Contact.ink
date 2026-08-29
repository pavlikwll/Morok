=== radio_repair ===
~ Event("player_control_off")
~ Event("radio_repair_begin")
~ Event("insert_radio_batteries")
~ Event("attach_telescope_aerial")
~ Add_State("radio_batteries", -1)
~ Add_State("telescope_aerial", -1)
~ Event("old_radio_repaired")
~ Event("radio_turn_knob_01")
~ Event("radio_play_music_fragment")
~ Event("radio_turn_knob_02")
~ Event("radio_play_conversation_fragment_01")
~ Event("radio_turn_knob_03")
~ Event("radio_play_conversation_fragment_02")
~ Event("radio_static_rises")
Radio: …someone… #avatar:radio #voice:radio_001
Jack: Hello? #avatar:jack #voice:jack_035
Radio: …wait. #avatar:radio #voice:radio_002
Jack: What? #avatar:jack #voice:jack_036
Radio: You heard us. #avatar:radio #voice:radio_003
Radio: Him. #avatar:radio #voice:radio_004
Radio: Her. #avatar:radio #voice:radio_005
Radio: Me. Don’t turn it off. #avatar:radio #voice:radio_006
Jack: Who are you? #avatar:jack #voice:jack_037
Radio: I… …don’t know. #avatar:radio #voice:radio_007
Jack: How are you doing this? #avatar:jack #voice:jack_038
Radio: Doing what? #avatar:radio #voice:radio_008
Jack: Talking to me. #avatar:jack #voice:jack_039
Radio: You’re talking to me too. #avatar:radio #voice:radio_009
Jack: Where are you? #avatar:jack #voice:jack_040
Radio: I don’t know anymore. I thought no one would ever answer. #avatar:radio #voice:radio_010
Jack: You can hear me? #avatar:jack #voice:jack_041
Radio: Every word. You’re the first one who’s stayed. Thank you, Jack. #avatar:radio #voice:radio_011
Jack: I never told you my name. #avatar:jack #voice:jack_042
~ Event("radio_click_off")
~ Event("radio_switches_off_itself")
~ Event("first_radio_contact_complete")
~ Event("unlock_second_radio_contact")
~ Event("player_control_on")
-> END

=== radio_second_contact ===
~ Event("player_control_off")
~ Event("radio_switch_on")
Jack: How did you know my name? #avatar:jack #voice:jack_043
Radio: Someone downstairs mentioned it. #avatar:radio #voice:radio_012
Radio: You’re frightened. #avatar:radio #voice:radio_013
Jack: No. #avatar:jack #voice:jack_044
Radio: That's nothing to be ashamed of. #avatar:radio #voice:radio_014
Radio: I was frightened too. #avatar:radio #voice:radio_015
Jack: Of what? #avatar:jack #voice:jack_045
Radio: Being alone. #avatar:radio #voice:radio_016
~ Event("radio_click_off")
~ Event("radio_switches_off_itself")
~ Event("second_radio_contact_complete")
~ Event("objective_talk_to_father")
~ Event("player_control_on")
-> END
