VAR boxes_moved = 0

=== moving_boxes ===
~ boxes_moved += 1
{
    - boxes_moved == 1:
        Mother: Just leave that one in the hall. #avatar:mother
        ~ Event("box_01_delivered")
    - boxes_moved == 2:
        Father: Careful. That’s the crockery. #avatar:father
        ~ Event("box_02_delivered")
    - boxes_moved == 3:
        Jack: Which room’s mine? #avatar:jack
        Mother: Upstairs. #avatar:mother
        Jack: Which one? #avatar:jack
        Mother: ... #avatar:mother
        Mother: Whichever one you fancy. #avatar:mother
        ~ Event("box_03_delivered")
    - boxes_moved >= 4:
        Father: Good lad. We’ll manage the rest. #avatar:father
        ~ Event("box_04_delivered")
        ~ Event("objective_find_your_room")
        ~ Event("moving_boxes_complete")
}
-> END

=== bedroom ===
= examine_window
Jack: You can see the cemetery from here. #avatar:jack
-> END

= examine_wardrobe
Jack: At least there’s plenty of room. #avatar:jack
-> END

= examine_old_socket
Jack: Dad’s going to hate that. #avatar:jack
-> END

= examine_attic_hatch
Jack: An attic… #avatar:jack
~ Event("attic_hatch_examined")
~ Event("unlock_ask_about_attic")
-> END
