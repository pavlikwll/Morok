=== examine_mh_locker ===
~ Event("focus_mh_locker_initials")
Radio: … #avatar:radio
Jack: What? #avatar:jack
Radio: Nothing. #avatar:radio
Jack: You reacted. #avatar:jack
Radio: Did I? #avatar:radio
Jack: Those letters mean something. #avatar:jack
Radio: I don’t know. I wish I did. #avatar:radio
~ Event("mh_initials_discovered")
-> END

=== examine_school_camera ===
Jack: Camera. #avatar:jack
Emily: Photography Club. Closed years ago. #avatar:emily
Jack: Can I take it? #avatar:jack
Emily: You’re asking the girl who’s currently trespassing. I’m probably not the authority. #avatar:emily
~ Event("school_camera_examined")
~ Event("school_camera_is_broken")
-> END

=== examine_unlabelled_cassette ===
~ Event("focus_unlabelled_cassette")
Radio: Jack. #avatar:radio
Jack: What? #avatar:jack
Radio: TAKE THAT. #avatar:radio
Radio: Sorry. I mean… could you? #avatar:radio
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
Jack: Michael. Is that you? #avatar:jack
Radio: I don’t know. But when she said it… it hurt. #avatar:radio
Radio: Maybe that means something. #avatar:radio
~ Event("michael_hale_name_discovered")
~ Event("school_recording_complete")
~ Event("spawn_first_echo_point")
-> END
