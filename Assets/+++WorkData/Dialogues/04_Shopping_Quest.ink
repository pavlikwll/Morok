=== mother_shopping_quest ===
Jack: Mum? #avatar:jack #voice:jack_021
Mother: What is it, love? #avatar:mother #voice:mother_008
Jack: Could I have some money? #avatar:jack #voice:jack_022
Mother: What for? #avatar:mother #voice:mother_009
Jack: Just something. #avatar:jack #voice:jack_023
Mother: Well, that’s terribly convincing. #avatar:mother #voice:mother_010
Jack: It’s for a project. #avatar:jack #voice:jack_024
Mother: What sort of project? #avatar:mother #voice:mother_011
Jack: I’ll show you when it’s working. #avatar:jack #voice:jack_025
Mother: Tell you what. #avatar:mother #voice:mother_012
Mother: I need some milk, a loaf of bread, and some washing powder. #avatar:mother #voice:mother_013
Mother: Pop down to Store and bring those back. #avatar:mother #voice:mother_014
~ Add_Money(300)
~ Event("receive_three_pounds")
~ Event("shopping_list_received")
Mother: Whatever you’ve got left, you can keep. #avatar:mother #voice:mother_015
Jack: Really? #avatar:jack #voice:jack_026
Mother: Within reason. #avatar:mother #voice:mother_016
Mother: Don’t come back with a bicycle. #avatar:mother #voice:mother_017
~ Event("objective_buy_household_shopping")
~ Event("unlock_route_to_store")
-> END