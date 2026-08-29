=== echo_twins ===
= encounter
~ Event("player_control_off")
~ Event("spawn_echo_twins")
~ Event("twins_face_jack")
Twins: Do you want to play? #avatar:twins #voice:twins_001
* [Yes.]
    ~ Event("twins_choice_yes")
    -> echo_twins.begin_combat
* [No.]
    ~ Event("twins_choice_no")
    -> echo_twins.begin_combat

= begin_combat
Twins: You already are. #avatar:twins #voice:twins_002
~ Event("start_twins_combat")
~ Event("player_control_on")
-> END
