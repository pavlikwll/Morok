=== cemetery_chapter ===
= begin
~ Event("objective_open_ashwick_cemetery")
-> END

= open_gates
~ Event("player_control_off")
~ Event("use_mayors_seal")
~ Add_State("mayors_seal", -1)
~ Event("open_ashwick_cemetery_gate")
Radio: He gave you the key. #avatar:radio
Jack: He wants me to find your grave. #avatar:jack
Radio: Do you believe him? You needn’t decide yet. #avatar:radio
~ Event("objective_find_michael_hale_grave")
~ Event("player_control_on")
-> END

= examine_michael_grave
~ Event("player_control_off")
~ Event("show_michael_hale_gravestone")
~ Event("show_gravestone_echo_symbol")
Jack: Michael Hale. #avatar:jack
~ Event("radio_voice_michael_clear")
Radio: That was me. #avatar:radio
~ Event("radio_voice_chorus_overlay")
Radio: I think. #avatar:radio_chorus
Jack: Is this where Finch trapped you? #avatar:jack
Radio: It’s where he left me. #avatar:radio
Jack: That’s not the same thing. #avatar:jack
~ Event("unlock_echo_cemetery_shift")
~ Event("player_control_on")
-> END

= enter_echo_cemetery
~ Event("player_control_off")
~ Event("shift_to_echo_cemetery")
~ Event("open_michael_grave")
~ Event("reveal_staircase_beneath_grave")
Jack: There’s nothing in the grave. #avatar:jack
Radio: I told you. #avatar:radio
Jack: Told me what? #avatar:jack
Radio: I’m still here. #avatar:radio
~ Event("objective_descend_beneath_grave")
~ Event("player_control_on")
-> END

= enter_underground_chamber
~ Event("player_control_off")
~ Event("enter_underground_echo_chamber")
~ Event("reveal_michael_distorted_form")
~ Event("michael_idle_animation_start")
~ Event("objective_approach_michael")
~ Event("player_control_on")
-> END

= first_face_to_face
~ Event("player_control_off")
Michael: Jack. #avatar:michael
Jack: Michael? #avatar:jack
Michael: You found me. #avatar:michael
Jack: You knew this place was here. #avatar:jack
Michael: Not at first. I remembered bits.. #avatar:michael
Jack: Why do you sound like all those people? #avatar:jack
Michael: Finch used memories to keep me here. #avatar:michael
Jack: He said they kept the Echo shut. #avatar:jack
Michael: He called it a seal. A prison sounds kinder when you give it another name. #avatar:michael
Jack: What do you want? #avatar:jack
Michael: Nothing you don’t choose for yourself. #avatar:michael
Michael: Remove it, my name.. #avatar:michael
Jack: Your name? #avatar:jack
Michael: It belongs to the boy buried above us. #avatar:michael
Jack: You are that boy. #avatar:jack
~ Event("michael_voice_chorus")
Michael: I was. #avatar:michael_chorus
~ Event("michael_voice_child")
Michael: I’m still alive. #avatar:michael
~ Event("start_final_combat_sequence")
~ Event("michael_remains_idle")
~ Event("spawn_nameless_echo_creatures")
~ Event("player_control_on")
-> END

= after_final_wave
~ Event("player_control_off")
~ Event("despawn_all_echo_creatures")
~ Event("michael_stands_beside_transmitter")
Michael: It’s over. #avatar:michael_child
Jack: You sent them after me. #avatar:jack
Michael: I was scared. Take off the name and open the door. #avatar:michael_child
Jack: For you. #avatar:jack
Michael: For both of us. #avatar:michael_child
Jack: This feels wrong. #avatar:jack
~ Event("michael_voice_monster")
Michael: Just trust me. #avatar:michael_monster
Jack: What was that? #avatar:jack
Jack: Who are you? #avatar:jack
~ Event("michael_voice_chorus")
Michael: MICHAEL HALE. #avatar:michael_chorus
~ Event("michael_voice_child")
Michael: What’s left of him. #avatar:michael_child
~ Event("final_combat_complete")
~ Event("unlock_final_choice_chamber")
~ Event("player_control_on")
-> END
