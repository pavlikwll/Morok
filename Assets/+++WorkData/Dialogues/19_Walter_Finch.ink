=== walter_finch ===
= encounter
~ Event("player_control_off")
~ Event("spawn_walter_finch_echo")
Finch: Turn it off. #avatar:finch #voice:finch_001
Radio: Don’t. #avatar:radio #voice:radio_098 
Finch: Boy. Turn the radio off. #avatar:finch #voice:finch_002
Radio: He doesn’t get to order you. #avatar:radio #voice:radio_099
Finch: It can hear me. #avatar:finch #voice:finch_003
Radio: So can Jack. #avatar:radio #voice:radio_100
Finch: It isn’t Michael. #avatar:finch #voice:finch_004
Jack: What? #avatar:jack #voice:jack_124
Radio: He doesn’t know that. #avatar:radio #voice:radio_101
Finch: I knew Michael Hale. #avatar:finch #voice:finch_005
~ Event("radio_voice_outburst")
Radio: LIAR. #avatar:radio_chorus #voice:radio_102
Finch: I helped this town forget him. #avatar:finch #voice:finch_006
Jack: Why? #avatar:jack #voice:jack_125
Finch: Because I was afraid. #avatar:finch #voice:finch_007
Radio: Ask him what he destroyed. #avatar:radio #voice:radio_103
Jack: What did you do? #avatar:jack #voice:jack_126
Finch: I burned the record. Destroyed the photograph. Told his family to leave. #avatar:finch #voice:finch_008
Radio: And he wants you to trust him. #avatar:radio #voice:radio_104
Finch: I thought forgetting would weaken it. I was wrong. We only fed it. #avatar:finch #voice:finch_009
Jack: What is it? #avatar:jack #voice:jack_127
Finch: Hungry. #avatar:finch #voice:finch_010
Radio: That’s not an answer. #avatar:radio #voice:radio_105
Finch: It’s the only one that matters. #avatar:finch #voice:finch_011
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
Radio: He admitted it. #avatar:radio #voice:radio_106
Jack: He was trying to stop you. #avatar:jack #voice:jack_128
Radio: Me? Jack… You think I’m the thing that did this? #avatar:radio #voice:radio_107
Jack: I don’t know what you are. #avatar:jack #voice:jack_129
Radio: Neither do I. I thought you were the one person who didn’t need me to explain myself. #avatar:radio #voice:radio_108
Jack: That’s not fair. #avatar:jack #voice:jack_130
Radio: You’re right. I’m sorry. Forget I said anything. #avatar:radio #voice:radio_109
~ Event("radio_silent_for_several_minutes")
-> END

= radio_returns
Jack: Are you there? #avatar:jack #voice:jack_131
Jack: Hello? #avatar:jack #voice:jack_132
Radio: I didn’t want to bother you. #avatar:radio #voice:radio_110
Jack: You weren’t. #avatar:jack #voice:jack_133
Radio: I thought maybe you’d rather listen to Finch. #avatar:radio #voice:radio_111
Jack: I just want the truth. #avatar:jack #voice:jack_134
Radio: So do I. Maybe that’s why we’re still together. #avatar:radio #voice:radio_112
~ Event("finch_aftermath_complete")
-> END