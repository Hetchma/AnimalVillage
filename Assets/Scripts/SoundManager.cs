using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject OnSoundButton;

    public void OnSound()
    {
        OnSoundButton.SetActive(false);
    }

    public void OffSound()
    {
        OnSoundButton.SetActive(true);
    }



}
