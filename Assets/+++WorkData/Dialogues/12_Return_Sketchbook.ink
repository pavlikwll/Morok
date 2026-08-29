=== return_emilys_sketchbook ===
~ Add_State("emily_blue_sketchbook", -1)
~ Event("give_sketchbook_to_emily")
Emily: You found it. #avatar:emily
Jack: Yeah. #avatar:jack
Emily: Where? #avatar:emily
Jack: A locker. #avatar:jack
Emily: Which locker? #avatar:emily
Jack: Doesn’t matter. #avatar:jack
Emily: Okay? Thanks. #avatar:emily
~ Event("emily_sketchbook_quest_complete")
~ Event("jack_walks_away_from_emily")
-> END

=== radio_after_returning_sketchbook ===
Radio: She knew you weren’t telling the truth. #avatar:radio
Jack: She didn’t say anything. #avatar:jack
Radio: Exactly. #avatar:radio
~ Event("radio_after_sketchbook_complete")
-> END
