=== talk_to_father_about_radio ===
Jack: Dad, do you think radios can pick up... #avatar:jack #voice:jack_046
Father: Jack, give us a hand with this. #avatar:father #voice:father_009
Jack: I just wanted to ask... #avatar:jack #voice:jack_047
Father: One second. #avatar:father #voice:father_010
~ Event("father_finishes_current_task")
Father: There. #avatar:father #voice:father_011
Father: What was it? #avatar:father #voice:father_012
Jack: Nothing. #avatar:jack #voice:jack_048
~ Event("talk_to_father_about_radio_complete")
~ Event("objective_return_to_jacks_room")
-> END

=== radio_after_father ===
~ Event("player_control_off")
~ Event("radio_switch_on")
Radio: You were going to tell him. #avatar:radio #voice:radio_017
Jack: Were you listening? #avatar:jack #voice:jack_049
Radio: I told you. I hear every word. #avatar:radio #voice:radio_018
Radio: He didn’t. #avatar:radio #voice:radio_019
Jack: He was busy. #avatar:jack #voice:jack_050
Radio: Of course. He always seems busy when you’re talking. #avatar:radio #voice:radio_020
Jack: You don’t know him. #avatar:jack #voice:jack_051
Radio: You’re so right. I’m sorry. #avatar:radio #voice:radio_021
Radio: I shouldn’t judge someone I’ve never met. I just don’t like seeing you go quiet. #avatar:radio #voice:radio_022
~ Event("radio_after_father_complete")
~ Event("start_next_morning_transition")
~ Event("player_control_on")
-> END

=== radio_next_morning ===
~ Event("player_control_off")
~ Event("radio_switch_on")
Jack: Do you remember anything? #avatar:jack #voice:jack_052
Radio: Sometimes. Not properly. #avatar:radio #voice:radio_023
Jack: Like what? #avatar:jack #voice:jack_053
Radio: A corridor. Lockers. Chalk. Someone drawing by a window. #avatar:radio #voice:radio_024
Jack: A school? There’s one nearby. #avatar:jack #voice:jack_054
Radio: Is there? #avatar:radio #voice:radio_025
Jack: You want me to go there? #avatar:jack #voice:jack_055
Radio: No. I don’t want you doing anything because I asked. You don’t owe me anything. #avatar:radio #voice:radio_026
~ Event("pause_short")
Radio: I just thought…if I saw something familiar…maybe I’d remember my name. #avatar:radio #voice:radio_027
~ Event("radio_next_morning_complete")
~ Event("objective_explore_ashwick_school")
~ Event("unlock_ashwick_school")
~ Event("player_control_on")
-> END