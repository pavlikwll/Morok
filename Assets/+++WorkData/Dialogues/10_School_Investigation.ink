=== examine_mh_locker ===
~ Event("focus_mh_locker_initials")
Radio: … #avatar:radio #voice:radio_028
Jack: What? #avatar:jack #voice:jack_068
Radio: Nothing. #avatar:radio #voice:radio_029
Jack: You reacted. #avatar:jack #voice:jack_069
Radio: Did I? #avatar:radio #voice:radio_030
Jack: Those letters mean something. #avatar:jack #voice:jack_070
Radio: I don’t know. I wish I did. #avatar:radio #voice:radio_031
~ Event("mh_initials_discovered")
-> END

=== examine_school_camera ===
Jack: Camera. #avatar:jack #voice:jack_071
Emily: Photography Club. Closed years ago. #avatar:emily #voice:emily_018
Jack: Can I take it? #avatar:jack #voice:jack_072
Emily: You’re asking the girl who’s currently trespassing. I’m probably not the authority. #avatar:emily #voice:emily_019
~ Event("school_camera_examined")
~ Event("school_camera_is_broken")
-> END

=== examine_unlabelled_cassette ===
~ Event("focus_unlabelled_cassette")
Radio: Jack. #avatar:radio #voice:radio_032
Jack: What? #avatar:jack #voice:jack_073
Radio: TAKE THAT. #avatar:radio #voice:radio_033
Radio: Sorry. I mean… could you? #avatar:radio #voice:radio_034
~ Add_State("unlabelled_cassette", 1)
~ Event("unlabelled_cassette_added")
~ Event("unlock_play_school_recording")
-> END

=== play_school_recording ===
~ Event("cassette_recording_start")
Teacher: Attendance.
~ Event("recording_read_several_names")
Teacher: Michael Hale?
~ Event("recording_silence")
Teacher: Michael?
Child: He’s right there.
Teacher: That’s strange. I could’ve sworn...
~ Event("cassette_recording_distorts")
Jack: Michael. Is that you? #avatar:jack #voice:jack_074
Radio: I don’t know. But when she said it… it hurt. #avatar:radio #voice:radio_035
Radio: Maybe that means something. #avatar:radio #voice:radio_036
~ Event("michael_hale_name_discovered")
~ Event("school_recording_complete")
~ Event("spawn_first_echo_point")
-> END