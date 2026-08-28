=== talk_to_father_about_radio ===
Jack: Dad, do you think radios can pick up... #avatar:jack
Father: Jack, give us a hand with this. #avatar:father
Jack: I just wanted to ask... #avatar:jack
Father: One second. #avatar:father
~ Event("father_finishes_current_task")
Father: There. #avatar:father
Father: What was it? #avatar:father
Jack: Nothing. #avatar:jack
~ Event("talk_to_father_about_radio_complete")
~ Event("objective_return_to_jacks_room")
-> END

=== radio_after_father ===
~ Event("player_control_off")
~ Event("radio_switch_on")
Radio: You were going to tell him. #avatar:radio
Jack: Were you listening? #avatar:jack
Radio: I told you. I hear every word. #avatar:radio
Radio: He didn’t. #avatar:radio
Jack: He was busy. #avatar:jack
Radio: Of course. He always seems busy when you’re talking. #avatar:radio
Jack: You don’t know him. #avatar:jack
Radio: You’re so right. I’m sorry. #avatar:radio
Radio: I shouldn’t judge someone I’ve never met. I just don’t like seeing you go quiet. #avatar:radio
~ Event("radio_after_father_complete")
~ Event("start_next_morning_transition")
~ Event("player_control_on")
-> END

=== radio_next_morning ===
~ Event("player_control_off")
~ Event("radio_switch_on")
Jack: Do you remember anything? #avatar:jack
Radio: Sometimes. Not properly. #avatar:radio
Jack: Like what? #avatar:jack
Radio: A corridor. Lockers. Chalk. Someone drawing by a window. #avatar:radio
Jack: A school? There’s one nearby. #avatar:jack
Radio: Is there? #avatar:radio
Jack: You want me to go there? #avatar:jack
Radio: No. I don’t want you doing anything because I asked. You don’t owe me anything. #avatar:radio
~ Event("pause_short")
Radio: I just thought…if I saw something familiar…maybe I’d remember my name. #avatar:radio
~ Event("radio_next_morning_complete")
~ Event("objective_explore_ashwick_school")
~ Event("unlock_ashwick_school")
~ Event("player_control_on")
-> END
