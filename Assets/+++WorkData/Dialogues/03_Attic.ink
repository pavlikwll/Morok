VAR radio_examined = false

=== parents_after_attic_hatch ===
= ask_mother
Jack: Mum? #avatar:jack #voice:jack_008
Mother: Mm? #avatar:mother #voice:mother_006
Jack: Can I have a look in the attic? #avatar:jack #voice:jack_009
Mother: Just mind yourself. #avatar:mother #voice:mother_007
Jack: Alright. #avatar:jack #voice:jack_010
~ Event("mother_allows_attic")
~ Event("unlock_attic_access")
-> END

= ask_father
Jack: Dad? #avatar:jack #voice:jack_011
Father: Yeah? #avatar:father #voice:father_005
Jack: There’s an attic. #avatar:jack #voice:jack_012
Father: Most houses’ve got one. #avatar:father #voice:father_006
Jack: Can I- #avatar:jack #voice:jack_013
Father: If the floorboards look rotten, keep off ’em. #avatar:father #voice:father_007
Father: And don’t go touching any wiring. #avatar:father #voice:father_008
Jack: Right. #avatar:jack #voice:jack_014
~ Event("father_attic_warning_complete")
-> END

=== attic ===
= examine_electronic_parts
Jack: Valves… #avatar:jack #voice:jack_015
Jack: Grandad used to keep these. #avatar:jack #voice:jack_016
-> END

= examine_old_speaker
Jack: He’d probably say this one’s still perfectly good. #avatar:jack #voice:jack_017
-> END

= examine_radio
{
    - radio_examined == false:
        ~ radio_examined = true
        Jack: Huh… #avatar:jack #voice:jack_018
        ~ Event("jack_picks_up_old_radio")
        Jack: That’s nice, but no batteries and someone’s snapped the aerial. #avatar:jack #voice:jack_019
        ~ Event("unlock_radio_second_examination")

    - else:
        Jack: Grandad would’ve tried fixing it. So will I. #avatar:jack #voice:jack_020
        ~ Event("old_radio_added")
        ~ Event("objective_find_radio_parts")
        ~ Event("unlock_ask_mother_for_money")
}
-> END

= examine_radio_first
~ radio_examined = true
Jack: Huh… #avatar:jack #voice:jack_018
~ Event("jack_picks_up_old_radio")
Jack: That’s nice, but no batteries and someone’s snapped the aerial. #avatar:jack #voice:jack_019
~ Event("unlock_radio_second_examination")
-> END

= examine_radio_again
Jack: Grandad would’ve tried fixing it. So will I. #avatar:jack #voice:jack_020
~ Event("old_radio_added")
~ Event("objective_find_radio_parts")
~ Event("unlock_ask_mother_for_money")
-> END
