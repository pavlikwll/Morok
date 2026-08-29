=== cemetery_chapter ===
= begin
~ Event("objective_open_ashwick_cemetery")
-> END

= open_gates
~ Event("player_control_off")
~ Event("use_mayors_seal")
~ Add_State("mayors_seal", -1)
~ Event("open_ashwick_cemetery_gate")
Radio: He gave you the key. #avatar:radio #voice:radio_075
Jack: He wants me to find your grave. #avatar:jack #voice:jack_135
Radio: Do you believe him? You needn’t decide yet. #avatar:radio #voice:radio_076
~ Event("objective_find_michael_hale_grave")
~ Event("player_control_on")
-> END

= examine_michael_grave
~ Event("player_control_off")
~ Event("show_michael_hale_gravestone")
~ Event("show_gravestone_echo_symbol")
Jack: Michael Hale. #avatar:jack #voice:jack_136
~ Event("radio_voice_michael_clear")
Radio: That was me. #avatar:radio #voice:radio_077
~ Event("radio_voice_chorus_overlay")
Radio: I think. #avatar:radio_chorus #voice:radio_078
Jack: Is this where Finch trapped you? #avatar:jack #voice:jack_137
Radio: It’s where he left me. #avatar:radio #voice:radio_079
Jack: That’s not the same thing. #avatar:jack #voice:jack_138
~ Event("unlock_echo_cemetery_shift")
~ Event("player_control_on")
-> END

= enter_echo_cemetery
~ Event("player_control_off")
~ Event("shift_to_echo_cemetery")
~ Event("open_michael_grave")
~ Event("reveal_staircase_beneath_grave")
Jack: There’s nothing in the grave. #avatar:jack #voice:jack_139
Radio: I told you. #avatar:radio #voice:radio_080
Jack: Told me what? #avatar:jack #voice:jack_140
Radio: I’m still here. #avatar:radio #voice:radio_081
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
Michael: Jack. #avatar:michael #voice:radio_082
Jack: Michael? #avatar:jack #voice:jack_141
Michael: You found me. #avatar:michael #voice:radio_083
Jack: You knew this place was here. #avatar:jack #voice:jack_142
Michael: Not at first. I remembered bits.. #avatar:michael #voice:radio_084
Jack: Why do you sound like all those people? #avatar:jack #voice:jack_143
Michael: Finch used memories to keep me here. #avatar:michael #voice:radio_085
Jack: He said they kept the Echo shut. #avatar:jack #voice:jack_144
Michael: He called it a seal. A prison sounds kinder when you give it another name. #avatar:michael #voice:radio_086
Jack: What do you want? #avatar:jack #voice:jack_145
Michael: Nothing you don’t choose for yourself. #avatar:michael #voice:radio_087
Michael: Remove it, my name.. #avatar:michael #voice:radio_088
Jack: Your name? #avatar:jack #voice:jack_146
Michael: It belongs to the boy buried above us. #avatar:michael #voice:radio_089
Jack: You are that boy. #avatar:jack #voice:jack_147
~ Event("michael_voice_chorus")
Michael: I was. #avatar:michael_chorus #voice:radio_090
~ Event("michael_voice_child")
Michael: I’m still alive. #avatar:michael #voice:radio_091
~ Event("start_final_combat_sequence")
~ Event("michael_remains_idle")
~ Event("spawn_nameless_echo_creatures")
~ Event("player_control_on")
-> END

= after_final_wave
~ Event("player_control_off")
~ Event("despawn_all_echo_creatures")
~ Event("michael_stands_beside_transmitter")
Michael: It’s over. #avatar:michael_child #voice:radio_092
Jack: You sent them after me. #avatar:jack #voice:jack_148
Michael: I was scared. Take off the name and open the door. #avatar:michael_child #voice:radio_093
Jack: For you. #avatar:jack #voice:jack_149
Michael: For both of us. #avatar:michael_child #voice:radio_094
Jack: This feels wrong. #avatar:jack #voice:jack_150
~ Event("michael_voice_monster")
Michael: Just trust me. #avatar:michael_monster #voice:radio_095
Jack: What was that? #avatar:jack #voice:jack_151
Jack: Who are you? #avatar:jack #voice:jack_152
~ Event("michael_voice_chorus")
Michael: MICHAEL HALE. #avatar:michael_chorus #voice:radio_096
~ Event("michael_voice_child")
Michael: What’s left of him. #avatar:michael_child #voice:radio_097
~ Event("final_combat_complete")
~ Event("unlock_final_choice_chamber")
~ Event("player_control_on")
-> END
