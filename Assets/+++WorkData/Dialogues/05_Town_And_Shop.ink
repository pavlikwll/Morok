=== town ===
= edith_intro
Edith: You’re the boy from the old Hale House. #avatar:edith #voice:edith_001
Jack: The what? #avatar:jack #voice:jack_027
Edith: …Did I say Hale? #avatar:edith #voice:edith_002
Jack: Yeah. #avatar:jack #voice:jack_028
Edith: How very odd. #avatar:edith #voice:edith_003
Edith: Never mind me, dear. #avatar:edith #voice:edith_004
~ Event("edith_intro_complete")
~ Event("first_hale_house_hint_discovered")
-> END

=== harris_shop ===
= introduction
Harris: Afternoon. #avatar:harris #voice:harris_001
Harris: You must be the new family. #avatar:harris #voice:harris_002
Jack: Is it really that obvious? #avatar:jack #voice:jack_029
Harris: Son, I know everyone in Ashwick. #avatar:harris #voice:harris_003
Harris: Well… almost everyone. #avatar:harris #voice:harris_004
~ Event("harris_intro_complete")
~ Event("open_store_shopping")
-> END

= examine_batteries
Jack: These ought to do. #avatar:jack #voice:jack_030
~ Event("batteries_discovered")
-> END

= examine_telescope_aerial
Jack: Close enough. #avatar:jack #voice:jack_031
~ Event("telescope_aerial_discovered")
-> END

= shopping_paid
~ Event("household_shopping_purchased")
~ Event("radio_parts_purchased")
~ Event("objective_return_home")
-> END