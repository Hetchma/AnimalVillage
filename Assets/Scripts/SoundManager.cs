using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject OnSoundButton;
    AudioSource[] audioSources;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void OnSound()
    {
        OnSoundButton.SetActive(false);
        audioSources[0].mute = true;
        audioSources[1].mute = true;
    }

    public void OffSound()
    {
        OnSoundButton.SetActive(true);
        audioSources[0].mute = false;
        audioSources[1].mute = false;
    }

}
