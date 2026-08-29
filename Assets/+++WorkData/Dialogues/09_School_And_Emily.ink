=== school_arrival ===
~ Event("ashwick_school_entered")
~ Event("school_holidays_state")
~ Event("unlock_school_entrance_hall")
~ Event("unlock_school_main_corridor")
~ Event("unlock_school_lockers")
~ Event("unlock_school_art_room")
-> END

=== emily_art_room_intro ===
Emily: You’re not supposed to be here. #avatar:emily #voice:emily_001
Jack: Neither are you. What are you doing? #avatar:jack #voice:jack_056
Emily: Burglary. #avatar:emily #voice:emily_002
Emily: Obviously I’m drawing. #avatar:emily #voice:emily_003
Jack: Oh. #avatar:jack #voice:jack_057
Emily: Do you always interrogate strangers? #avatar:emily #voice:emily_004
Jack: Only burglars. #avatar:jack #voice:jack_058
Emily: Emily. #avatar:emily #voice:emily_005
Jack: Jack. #avatar:jack #voice:jack_059
Emily: The new boy. #avatar:emily #voice:emily_006
Jack: Everyone knows already? #avatar:jack #voice:jack_060
Emily: It’s Ashwick. Someone sneezes and three streets know by teatime. #avatar:emily #voice:emily_007
Emily: Why are you here? #avatar:emily #voice:emily_008
Jack: Just having a look around. #avatar:jack #voice:jack_061
Emily: Looking for anything? #avatar:emily #voice:emily_009
Jack: No. #avatar:jack #voice:jack_062
Emily: Alright. #avatar:emily #voice:emily_010
~ Event("emily_met")
~ Event("unlock_examine_emily_drawings")
-> END

=== examine_emily_drawings ===
~ Event("show_emily_corridor_drawing")
Jack: Who’s that? #avatar:jack #voice:jack_063
Emily: What? #avatar:emily #voice:emily_011
Jack: The kid. #avatar:jack #voice:jack_064
Emily: …I don’t know. #avatar:emily #voice:emily_012
Jack: You don’t remember? #avatar:jack #voice:jack_065
Emily: Sometimes I start with a room. Then there’s someone standing in it. #avatar:emily #voice:emily_013
Jack: That’s normal? #avatar:jack #voice:jack_066
Emily: Absolutely not. Makes the drawings better, though. #avatar:emily #voice:emily_014
Emily: Actually… Have you seen a blue sketchbook? #avatar:emily #voice:emily_015
Jack: No. #avatar:jack #voice:jack_067
Emily: I left it here yesterday. #avatar:emily #voice:emily_016
Emily: Which is impressive… seeing as I’ve already looked in here three times. #avatar:emily #voice:emily_017
~ Event("objective_find_emilys_sketchbook")
~ Event("emily_sketchbook_quest_started")
-> END