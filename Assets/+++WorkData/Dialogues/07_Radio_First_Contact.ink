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
Radio: …someone… #avatar:radio
Jack: Hello? #avatar:jack
Radio: …wait. #avatar:radio
Jack: What? #avatar:jack
Radio: You heard us. #avatar:radio
Radio: Him. #avatar:radio
Radio: Her. #avatar:radio
Radio: Me. Don’t turn it off. #avatar:radio
Jack: Who are you? #avatar:jack
Radio: I… …don’t know. #avatar:radio
Jack: How are you doing this? #avatar:jack
Radio: Doing what? #avatar:radio
Jack: Talking to me. #avatar:jack
Radio: You’re talking to me too. #avatar:radio
Jack: Where are you? #avatar:jack
Radio: I don’t know anymore. I thought no one would ever answer. #avatar:radio
Jack: You can hear me? #avatar:jack
Radio: Every word. You’re the first one who’s stayed. Thank you, Jack. #avatar:radio
Jack: I never told you my name. #avatar:jack
~ Event("radio_click_off")
~ Event("radio_switches_off_itself")
~ Event("first_radio_contact_complete")
~ Event("unlock_second_radio_contact")
~ Event("player_control_on")
-> END

=== radio_second_contact ===
~ Event("player_control_off")
~ Event("radio_switch_on")
Jack: How did you know my name? #avatar:jack
Radio: Someone downstairs mentioned it. #avatar:radio
Radio: You’re frightened. #avatar:radio
Jack: No. #avatar:jack
Radio: That's nothing to be ashamed of. #avatar:radio
Radio: I was frightened too. #avatar:radio
Jack: Of what? #avatar:jack
Radio: Being alone. #avatar:radio
~ Event("radio_click_off")
~ Event("radio_switches_off_itself")
~ Event("second_radio_contact_complete")
~ Event("objective_talk_to_father")
~ Event("player_control_on")
-> END
