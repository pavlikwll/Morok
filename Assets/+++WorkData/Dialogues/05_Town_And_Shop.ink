=== town ===
= edith_intro
Edith: You’re the boy from the old Hale House. #avatar:edith
Jack: The what? #avatar:jack
Edith: …Did I say Hale? #avatar:edith
Jack: Yeah. #avatar:jack
Edith: How very odd. #avatar:edith
Edith: Never mind me, dear. #avatar:edith
~ Event("edith_intro_complete")
~ Event("first_hale_house_hint_discovered")
-> END

=== harris_shop ===
= introduction
Harris: Afternoon. #avatar:harris
Harris: You must be the new family. #avatar:harris
Jack: Is it really that obvious? #avatar:jack
Harris: Son, I know everyone in Ashwick. #avatar:harris
Harris: Well… almost everyone. #avatar:harris
~ Event("harris_intro_complete")
~ Event("open_store_shopping")
-> END

= examine_batteries
Jack: These ought to do. #avatar:jack
~ Event("batteries_discovered")
-> END

= examine_telescope_aerial
Jack: Close enough. #avatar:jack
~ Event("telescope_aerial_discovered")
-> END

= shopping_paid
~ Event("household_shopping_purchased")
~ Event("radio_parts_purchased")
~ Event("objective_return_home")
-> END
