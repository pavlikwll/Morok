=== edith_glasses === 
= start
Edith: Jack, dear? Would you have a look around for me? #avatar:edith #voice:edith_005
Jack: What am I looking for? #avatar:jack #voice:jack_096
Edith: My glasses. #avatar:edith #voice:edith_006
~ Event("objective_find_ediths_glasses")
~ Event("edith_glasses_quest_started")
~ Event("spawn_edith_glasses_near_bench")
-> END

= give_back_glasses
~ Event("edith_glasses_found")
Edith: Oh dear… Thank you, love. #avatar:edith #voice:edith_007
~ Add_State("money_pence", 20)
~ Add_State("chocolate_bar", 1)
~ Event("receive_twenty_pence_from_edith")
~ Event("chocolate_bar_added")
~ Event("edith_glasses_quest_complete")
-> END

=== edith_music_box ===
= start
Edith: I used to have a little music box. I do wonder whatever became of it… #avatar:edith #voice:edith_008
~ Event("objective_find_ediths_music_box")
~ Event("edith_music_box_quest_started")
~ Event("spawn_echo_childrens_room_near_edith_bench")
~ Event("spawn_the_mute_beside_music_box")
-> END

= take
~ Event("the_mute_watches_silently")
~ Add_State("edith_music_box", 1)
~ Event("edith_music_box_added")
~ Event("escape_echo_childrens_room")
~ Event("objective_return_music_box_to_edith")
-> END

= return_music_box
~ Add_State("edith_music_box", -1)
~ Event("edith_winds_music_box")
~ Event("play_music_box_melody")
Edith: … There was a boy. #avatar:edith #voice:edith_009
Jack: Michael? #avatar:jack #voice:jack_097
Edith: I’m sorry… I can’t remember. #avatar:edith #voice:edith_010
~ Add_State("music_box_cylinder", 1)
~ Event("music_box_cylinder_added")
~ Event("memory_anchor_music_box_unlocked")
~ Event("edith_music_box_quest_complete")
-> END

= radio_afterward
Radio: She almost remembered me. #avatar:radio #voice:radio_073
Jack: So… you are Michael? #avatar:jack #voice:jack_098
Radio: Maybe I was. Does it matter …if nobody remembers? #avatar:radio #voice:radio_074
-> END