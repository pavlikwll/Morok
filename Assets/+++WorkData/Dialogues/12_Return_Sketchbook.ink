=== return_emilys_sketchbook ===
~ Add_State("emily_blue_sketchbook", -1)
~ Event("give_sketchbook_to_emily")
Emily: You found it. #avatar:emily #voice:emily_020
Jack: Yeah. #avatar:jack #voice:jack_083
Jack: A locker. #avatar:jack #voice:jack_084
Emily: Which locker? #avatar:emily #voice:emily_021
Jack: Doesn’t matter. #avatar:jack #voice:jack_085
Emily: Okay? Thanks. #avatar:emily #voice:emily_022
~ Event("emily_sketchbook_quest_complete")
~ Event("jack_walks_away_from_emily")
-> END

=== radio_after_returning_sketchbook ===
Radio: She knew you weren’t telling the truth. #avatar:radio #voice:radio_048
Jack: She didn’t say anything. #avatar:jack #voice:jack_086
Radio: Exactly. #avatar:radio #voice:radio_049
~ Event("radio_after_sketchbook_complete")
-> END