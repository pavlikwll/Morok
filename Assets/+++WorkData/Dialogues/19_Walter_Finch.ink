=== walter_finch ===
= encounter
~ Event("player_control_off")
~ Event("spawn_walter_finch_echo")
Finch: Turn it off. #avatar:finch
Radio: Don’t. #avatar:radio
Finch: Boy. Turn the radio off. #avatar:finch
Radio: He doesn’t get to order you. #avatar:radio
Finch: It can hear me. #avatar:finch
Radio: So can Jack. #avatar:radio
Finch: It isn’t Michael. #avatar:finch
Jack: What? #avatar:jack
Radio: He doesn’t know that. #avatar:radio
Finch: I knew Michael Hale. #avatar:finch
~ Event("radio_voice_outburst")
Radio: LIAR. #avatar:radio_chorus
Finch: I helped this town forget him. #avatar:finch
Jack: Why? #avatar:jack
Finch: Because I was afraid. #avatar:finch
Radio: Ask him what he destroyed. #avatar:radio
Jack: What did you do? #avatar:jack
Finch: I burned the record. Destroyed the photograph. Told his family to leave. #avatar:finch
Radio: And he wants you to trust him. #avatar:radio
Finch: I thought forgetting would weaken it. I was wrong. We only fed it. #avatar:finch
Jack: What is it? #avatar:jack
Finch: Hungry. #avatar:finch
Radio: That’s not an answer. #avatar:radio
Finch: It’s the only one that matters. #avatar:finch
~ Event("finch_explains_cemetery_echo_connection")
~ Event("finch_explains_memory_anchors")
~ Event("show_collected_memory_anchor_summary")
~ Add_State("mayors_seal", 1)
~ Event("mayors_seal_added")
~ Event("unlock_ashwick_cemetery_gate")
~ Event("walter_finch_disappears")
~ Event("objective_open_ashwick_cemetery")
~ Event("player_control_on")
-> END

= radio_afterward
Radio: He admitted it. #avatar:radio
Jack: He was trying to stop you. #avatar:jack
Radio: Me? Jack… You think I’m the thing that did this? #avatar:radio
Jack: I don’t know what you are. #avatar:jack
Radio: Neither do I. I thought you were the one person , who didn’t need me to explain myself. #avatar:radio
Jack: That’s not fair. #avatar:jack
Radio: You’re right. I’m sorry. Forget I said anything. #avatar:radio
~ Event("radio_silent_for_several_minutes")
-> END

= radio_returns
Jack: Are you there? #avatar:jack
Jack: Hello? #avatar:jack
Radio: I didn’t want to bother you. #avatar:radio
Jack: You weren’t. #avatar:jack
Radio: I thought maybe you’d rather listen to Finch. #avatar:radio
Jack: I just want the truth. #avatar:jack
Radio: So do I. Maybe that’s why we’re still together. #avatar:radio
~ Event("finch_aftermath_complete")
-> END
