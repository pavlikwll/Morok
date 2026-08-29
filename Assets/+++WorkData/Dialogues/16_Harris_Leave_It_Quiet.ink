VAR harris_boxes_moved = 0

=== harris_odd_jobs ===
= start
Harris: Jack. Fancy earning a pound? #avatar:harris
Jack: Depends. #avatar:jack
Harris: Five boxes. Door to storeroom. #avatar:harris
Jack: That’s it? #avatar:jack
Harris: That’s honest work. #avatar:harris
~ harris_boxes_moved = 0
~ Event("objective_move_five_harris_boxes")
~ Event("harris_odd_jobs_started")
-> END

= box_delivered
~ harris_boxes_moved += 1
~ Event("harris_box_delivered")
{
    - harris_boxes_moved >= 5:
        ~ Event("harris_five_boxes_complete")
        ~ Event("spawn_precision_screwdriver")
    - else:
        ~ Event("continue_harris_box_job")
}
-> END

= find_screwdriver
~ Add_State("precision_screwdriver", 1)
~ Event("precision_screwdriver_added")
Harris: Cheers. Keep the screwdriver. #avatar:harris
Jack: Really? #avatar:jack
Harris: I’ve got plenty. #avatar:harris
~ Add_State("money_pence", 100)
~ Event("receive_one_pound_from_harris")
~ Event("unlock_repeat_harris_odd_jobs")
~ Event("harris_odd_jobs_complete")
-> END

=== harris_storeroom ===
= start
~ Event("harris_storeroom_door_jammed")
~ Event("objective_enter_harris_storeroom")
~ Event("unlock_storeroom_echo_route")
-> END

= enter_echo_world
~ Event("remove_storeroom_door_in_echo_world")
~ Event("enter_harris_storeroom_echo_world")
~ Event("unlock_examine_harris_ledger")
-> END

= examine_ledger
~ Event("show_harris_ledger_page")
~ Event("show_ledger_entry_four_batteries")
~ Event("show_ledger_entry_wire")
~ Event("show_ledger_entry_cassette")
~ Event("show_ledger_entry_m_hale")
Radio: He knew me. #avatar:radio_child
Jack: Mr Harris? #avatar:jack
Radio: He took my money. Smiled at me. Probably called me ‘son’. #avatar:radio_child
~ Add_State("harris_ledger", 1)
~ Event("harris_ledger_added")
~ Event("objective_show_ledger_to_harris")
-> END

= confront_harris
Jack: Do you remember Michael Hale? #avatar:jack
Harris: …That’s my handwriting, but why would I write down a name… #avatar:harris
Harris: …I can’t remember? #avatar:harris
~ Event("harris_notices_radio")
Harris: Where did you get that Radio? #avatar:harris
Jack: From our attic. #avatar:jack
Harris: Hale House… I hoped nobody would ever switch that thing on again. #avatar:harris
Jack: Why? #avatar:jack
Harris: I don’t know. Some things are better left quiet. #avatar:harris
~ Event("harris_notices_hale_family_photograph")
Harris: This picture… Michael. #avatar:harris
Jack: You remember him? #avatar:jack
Harris: Bits of him. Always taking radios apart. #avatar:harris
Jack: What happened to him? #avatar:jack
Harris: I honestly don’t know. #avatar:harris
Radio: Ask him about the aerial. #avatar:radio
Jack: Did you break the aerial? #avatar:jack
Harris: I think I did. I just wish I remembered why. #avatar:harris
Harris: Jack… Whatever’s talking through that radio… #avatar:harris
Harris: Don’t mistake knowing you, for caring about you. #avatar:harris
~ Add_State("ledger_page", 1)
~ Add_State("money_pence", 200)
~ Event("ledger_page_added")
~ Event("memory_evidence_ledger_page_unlocked")
~ Event("receive_two_pounds_from_harris")
~ Event("unlock_harris_battery_cassette_discount")
~ Event("harris_leave_it_quiet_quest_complete")
-> END

= radio_afterward
Radio: He broke it. #avatar:radio
Jack: To stop you? #avatar:jack
Radio: Maybe. And you chose to fix it. #avatar:radio
Jack: It’s not his fault. #avatar:jack
Radio: When does it become someone’s fault, Jack? #avatar:radio
-> END
