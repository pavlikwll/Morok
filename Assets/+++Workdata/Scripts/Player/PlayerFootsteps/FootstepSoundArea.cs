using UnityEngine;

[CreateAssetMenu(fileName = "New Footstep Area", menuName = "Morok/Footstep/SoundArea")]
public class FootstepSoundArea : ScriptableObject
{
    public Area area;
    public string fmodFootstepEvent = "default";
}
