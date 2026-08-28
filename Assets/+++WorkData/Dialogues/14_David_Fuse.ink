=== david_fuse ===
= start
Father: Jack. Could you pop down and buy a replacement fuse? I’ll pay you back. #avatar:father
~ Event("objective_buy_replacement_fuse")
~ Event("david_fuse_quest_started")
~ Event("unlock_replacement_fuse_at_harris")
-> END

= buy_fuse
~ Add_State("replacement_fuse", 1)
~ Event("replacement_fuse_purchased")
~ Event("objective_return_fuse_to_david")
-> END

= return_fuse
~ Add_State("replacement_fuse", -1)
~ Event("david_installs_replacement_fuse")
~ Event("lights_fail_after_fuse_installation")
~ Event("objective_investigate_power_in_echo_world")
~ Event("unlock_echo_power_cable")
-> END

= follow_echo_cable
~ Event("show_disappearing_echo_power_cable")
~ Event("follow_echo_power_cable")
~ Add_State("old_copper_coil", 1)
~ Event("old_copper_coil_added")
~ Event("restore_house_power_on_return")
-> END

= complete
Father: You fixed it? Nice work. #avatar:father
~ Add_State("money_pence", 300)
~ Event("receive_three_pounds_from_david")
~ Event("david_fuse_quest_complete")
-> END

= radio_afterward
Radio: He sounded surprised. #avatar:radio
Jack: He said I did well. #avatar:jack
Radio: He did. #avatar:radio
~ Event("pause_short")
Radio: Like he wasn’t expecting you to. #avatar:radio
-> END
