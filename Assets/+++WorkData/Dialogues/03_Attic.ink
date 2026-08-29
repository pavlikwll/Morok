VAR radio_examined = false

=== parents_after_attic_hatch ===
= ask_mother
Jack: Mum? #avatar:jack
Mother: Mm? #avatar:mother
Jack: Can I have a look in the attic? #avatar:jack
Mother: Just mind yourself. #avatar:mother
Jack: Alright. #avatar:jack
~ Event("mother_allows_attic")
~ Event("unlock_attic_access")
-> END

= ask_father
Jack: Dad? #avatar:jack
Father: Yeah? #avatar:father
Jack: There’s an attic. #avatar:jack
Father: Most houses’ve got one. #avatar:father
Jack: Can I- #avatar:jack
Father: If the floorboards look rotten, keep off ’em. #avatar:father
Father: And don’t go touching any wiring. #avatar:father
Jack: Right. #avatar:jack
~ Event("father_attic_warning_complete")
-> END

=== attic ===
= examine_electronic_parts
Jack: Valves… #avatar:jack
Jack: Grandad used to keep these. #avatar:jack
-> END

= examine_old_speaker
Jack: He’d probably say this one’s still perfectly good. #avatar:jack
-> END

= examine_radio
{
    - radio_examined == false:
        ~ radio_examined = true
        Jack: Huh… #avatar:jack
        ~ Event("jack_picks_up_old_radio")
        Jack: That’s nice, but no batteries and someone’s snapped the aerial. #avatar:jack
        ~ Event("old_radio_added")
        ~ Event("unlock_radio_second_examination")
    - else:
        Jack: Grandad would’ve tried fixing it. So will I. #avatar:jack
        ~ Event("objective_find_radio_parts")
        ~ Event("unlock_ask_mother_for_money")
}
-> END

= examine_radio_first
~ radio_examined = true
Jack: Huh… #avatar:jack
~ Event("jack_picks_up_old_radio")
Jack: That’s nice, but no batteries and someone’s snapped the aerial. #avatar:jack
~ Event("old_radio_added")
~ Event("unlock_radio_second_examination")
-> END

= examine_radio_again
Jack: Grandad would’ve tried fixing it. So will I. #avatar:jack
~ Event("objective_find_radio_parts")
~ Event("unlock_ask_mother_for_money")
-> END
