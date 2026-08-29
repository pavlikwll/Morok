VAR boxes_moved = 0

=== moving_boxes ===
~ boxes_moved += 1
{
- boxes_moved == 1:
        Mother: Just leave that one in the hall. #avatar:mother #voice:mother_003
        ~ Event("box_01_delivered")
    - boxes_moved == 2:
        Father: Careful. That’s the crockery. #avatar:father #voice:father_003
        ~ Event("box_02_delivered")
    - boxes_moved == 3:
        Jack: Which room’s mine? #avatar:jack #voice:jack_002
        Mother: Upstairs. #avatar:mother #voice:mother_004
        Jack: Which one? #avatar:jack #voice:jack_003
        Mother: Whichever one you fancy. #avatar:mother #voice:mother_005
        ~ Event("box_03_delivered")
    - boxes_moved >= 4:
        Father: Good lad. We’ll manage the rest. #avatar:father #voice:father_004
        ~ Event("box_04_delivered")
        ~ Event("objective_find_your_room")
        ~ Event("moving_boxes_complete")
}
-> END

=== bedroom ===
= examine_window
Jack: You can see the cemetery from here. #avatar:jack #voice:jack_004
-> END

= examine_wardrobe
Jack: At least there’s plenty of room. #avatar:jack #voice:jack_005
-> END

= examine_old_socket
Jack: Dad’s going to hate that. #avatar:jack #voice:jack_006
-> END

= examine_attic_hatch
Jack: An attic… #avatar:jack #voice:jack_007
~ Event("attic_hatch_examined")
~ Event("unlock_ask_about_attic")
-> END