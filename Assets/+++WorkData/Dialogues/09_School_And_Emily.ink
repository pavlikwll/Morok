=== school_arrival ===
~ Event("ashwick_school_entered")
~ Event("school_holidays_state")
~ Event("unlock_school_entrance_hall")
~ Event("unlock_school_main_corridor")
~ Event("unlock_school_lockers")
~ Event("unlock_school_art_room")
-> END

=== emily_art_room_intro ===
Emily: You’re not supposed to be in here. #avatar:emily
Jack: Neither are you. What are you doing? #avatar:jack
Emily: Burglary. #avatar:emily
Emily: Obviously I’m drawing. #avatar:emily
Jack: Oh. #avatar:jack
Emily: Do you always interrogate strangers? #avatar:emily
Jack: Only burglars. #avatar:jack
Emily: Emily. #avatar:emily
Jack: Jack. #avatar:jack
Emily: The new boy. #avatar:emily
Jack: Everyone knows already? #avatar:jack
Emily: It’s Ashwick. Someone sneezes and three streets know by teatime. #avatar:emily
Emily: Why are you here? #avatar:emily
Jack: Just having a look around. #avatar:jack
Emily: Looking for anything? #avatar:emily
Jack: No. #avatar:jack
Emily: Alright. #avatar:emily
~ Event("emily_met")
~ Event("unlock_examine_emily_drawings")
-> END

=== examine_emily_drawings ===
~ Event("show_emily_corridor_drawing")
Jack: Who’s that? #avatar:jack
Emily: What? #avatar:emily
Jack: The kid. #avatar:jack
Emily: …I don’t know. #avatar:emily
Jack: You don’t remember? #avatar:jack
Emily: Sometimes I start with a room. Then there’s someone standing in it. #avatar:emily
Jack: That’s normal? #avatar:jack
Emily: Absolutely not. Makes the drawings better, though. #avatar:emily
Emily: Actually… Have you seen a blue sketchbook? #avatar:emily
Jack: No. #avatar:jack
Emily: I left it here yesterday. Which is impressive… seeing as I’ve already looked in here three times. #avatar:emily
~ Event("objective_find_emilys_sketchbook")
~ Event("emily_sketchbook_quest_started")
-> END
