using UnityEngine;
using UnityEngine.InputSystem;

public class VoiceTestDummy : MonoBehaviour
{
    [SerializeField] private DialogueVoicePlayer voicePlayer;
    [SerializeField] private string character = "jack";

    private int lineNumber = 1;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            string voiceId = character + "_" + lineNumber.ToString("000");

            Debug.Log("Playing Voice: " + voiceId);

            voicePlayer.PlayVoice(voiceId);

            lineNumber++;
        }
    }
}