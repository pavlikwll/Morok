=== mother_shopping_quest ===
Jack: Mum? #avatar:jack
Mother: What is it, love? #avatar:mother
Jack: Could I have some money? #avatar:jack
Mother: What for? #avatar:mother
Jack: Just something. #avatar:jack
Mother: Well, that’s terribly convincing. #avatar:mother
Jack: It’s for a project. #avatar:jack
Mother: What sort of project? #avatar:mother
Jack: I’ll show you when it’s working. #avatar:jack
Mother: Tell you what. #avatar:mother
Mother: I need some milk, a loaf of bread, and some washing powder. #avatar:mother
Mother: Pop down to Store and bring those back. #avatar:mother
~ Add_State("money_pence", 300)
~ Event("receive_three_pounds")
~ Event("shopping_list_received")
Mother: Whatever you’ve got left, you can keep. #avatar:mother
Jack: Really? #avatar:jack
Mother: Within reason. #avatar:mother
Mother: Don’t come back with a bicycle. #avatar:mother
~ Event("objective_buy_household_shopping")
~ Event("unlock_route_to_store")
-> END
