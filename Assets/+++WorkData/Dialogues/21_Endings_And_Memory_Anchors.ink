VAR ending_music_box_inserted = false
VAR ending_family_photo_inserted = false
VAR ending_emily_drawing_inserted = false
VAR ending_anchor_count = 0
VAR ending_locked = false

=== endings ===
= begin
~ Event("player_control_off")
~ Event("chapter_two_endings_started")
~ Event("enable_final_chamber_free_movement")
Michael: We can stop. No more fighting. #avatar:michael #voice:michael_113
Jack: And then? #avatar:jack #voice:jack_153
Michael: Remove the name. Open the door. Nobody will ever have to be forgotten again. #avatar:michael #voice:michael_114
Jack: How? #avatar:jack #voice:jack_154
~ Event("michael_voice_chorus")
Michael: We’ll remember them. #avatar:michael #voice:michael_115
~ Event("michael_voice_child")
Michael: Forever. #avatar:michael #voice:michael_116
~ Event("objective_choose_michaels_fate")
~ Event("enable_remove_michael_nameplate")
~ Event("enable_memory_anchor_transmitter")
~ Event("player_control_on")
-> END

= examine_nameplate
{ ending_locked:
    ~ Event("final_choice_already_locked")
- else:
    ~ Event("show_remove_nameplate_prompt")
}
-> END

= remove_nameplate
{ ending_locked:
    ~ Event("final_choice_already_locked")
- else:
    ~ ending_locked = true
    ~ Event("player_control_off")
    ~ Event("lock_final_chamber_interactions")
    ~ Event("remove_michael_nameplate")
    ~ Event("disable_all_memory_anchors")
    ~ Event("bad_ending_started")
    ~ Event("chamber_voices_rise")
    Michael: That’s it. You opened the door. #avatar:michael #voice:michael_117
    Michael: Your choice. Your hands. Your decision. #avatar:michael #voice:michael_118
    Michael: You won’t be forgotten. #avatar:michael #voice:michael_119
    ~ Event("jack_hands_turn_transparent")
    Jack: Michael… #avatar:jack #voice:jack_155
    ~ Event("michael_disappears")
    ~ Event("radios_play_jacks_voice")
    Jack’s Voice: Hello? #avatar:jack_radio #voice:jack_156
    Jack: What’s happening? #avatar:jack #voice:jack_157
    Jack’s Voice: Can anyone hear me? #avatar:jack_radio #voice:jack_158
    ~ Event("jack_dissolves_into_static")
    ~ Event("drop_michael_nameplate")
    ~ Event("show_nameplate_michael_hale")
    ~ Event("change_nameplate_to_jack")
    ~ Event("fade_to_black")
    ~ Event("ending_never_alone_complete")
}
-> END

= examine_transmitter
{ 
- ending_locked:
    ~ Event("final_choice_already_locked")
- ending_anchor_count == 0:
    ~ Event("show_memory_anchor_slots_empty")
- ending_anchor_count == 1:
    ~ Event("show_memory_anchor_slots_one_filled")
- ending_anchor_count == 2:
    ~ Event("show_memory_anchor_slots_two_filled")
- else:
    ~ Event("show_memory_anchor_slots_complete")
}
-> END

= insert_music_box_cylinder
{ 
- ending_locked:
    ~ Event("final_choice_already_locked")
- ending_music_box_inserted:
    ~ Event("memory_anchor_already_inserted")
- else:
    ~ ending_music_box_inserted = true
    ~ ending_anchor_count += 1
    ~ Add_State("music_box_cylinder", -1)
    ~ Event("insert_music_box_cylinder")
    ~ Event("play_music_box_melody")
    Michael: Stop. #avatar:michael #voice:michael_120
    Jack: Edith remembered this. #avatar:jack #voice:jack_159
    Michael: She forgot me. #avatar:michael #voice:michael_121
    Jack: Not completely. #avatar:jack #voice:jack_160
    ~ Event("memory_anchor_music_box_activated")
    -> endings.check_all_anchors
}
-> END

= insert_hale_family_photograph
{ 
- ending_locked:
    ~ Event("final_choice_already_locked")
- ending_family_photo_inserted:
    ~ Event("memory_anchor_already_inserted")
- else:
    ~ ending_family_photo_inserted = true
    ~ ending_anchor_count += 1
    ~ Add_State("hale_family_photograph", -1)
    ~ Event("insert_hale_family_photograph")
    ~ Event("show_hale_family_photograph_restored")
    Michael: That’s… My house. #avatar:michael #voice:michael_122
    Jack: Your family. #avatar:jack #voice:jack_161
    ~ Event("memory_anchor_family_photo_activated")
    -> endings.check_all_anchors
}
-> END

= insert_emily_drawing
{ 
- ending_locked:
    ~ Event("final_choice_already_locked")
- ending_emily_drawing_inserted:
    ~ Event("memory_anchor_already_inserted")
- not emily_drawing_kept:
    ~ Event("emily_drawing_not_available")
- else:
    ~ ending_emily_drawing_inserted = true
    ~ ending_anchor_count += 1
    ~ Add_State("emily_drawing", -1)
    ~ Event("insert_emily_drawing")
    ~ Event("reveal_figures_on_emily_drawing")
    ~ Event("show_emily_drawing_remember_us")
    Michael: What are you doing? #avatar:michael #voice:michael_123
    Jack: Remembering you. #avatar:jack #voice:jack_162
    Michael: I’m right here. #avatar:michael #voice:michael_124
    Jack: Not all of you. #avatar:jack #voice:jack_163
    ~ Event("memory_anchor_emily_drawing_activated")
    -> endings.check_all_anchors
}
-> END

= check_all_anchors
{ ending_anchor_count >= 3:
    ~ Event("all_three_memory_anchors_inserted")
    -> endings.good_ending
- else:
    ~ Event("memory_anchor_inserted")
}
-> END

= good_ending
{ ending_locked:
    ~ Event("final_choice_already_locked")
- else:
    ~ ending_locked = true
    ~ Event("player_control_off")
    ~ Event("lock_final_chamber_interactions")
    ~ Event("good_ending_started")
    ~ Event("michael_voice_child_only")
    Michael: Jack… #avatar:michael #voice:michael_125
    Jack: You’re Michael Hale. #avatar:jack #voice:jack_164
    Michael: I don’t want to disappear. #avatar:michael #voice:michael_126
    Jack: You won’t be forgotten. #avatar:jack #voice:jack_165
    Michael: You don’t know that. #avatar:michael #voice:michael_127
    Jack: Your song is remembered. Your face is remembered. Your name is still here. That’s enough. #avatar:jack #voice:jack_166
    Michael: Please… Don’t turn me off. #avatar:michael #voice:michael_128
    Jack: I’m sorry. But I can’t let you take anyone else. #avatar:jack #voice:jack_167
    ~ Event("jack_switches_radio_off")
    ~ Event("radio_click")
    Michael: Thank you. #avatar:michael #voice:michael_129
    ~ Event("michael_disappears_peacefully")
    ~ Event("ending_remember_me_complete")
}
-> END
