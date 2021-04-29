using UnityEngine;


public class UIPanel : MonoBehaviour
{
    public bool CanOtherButton = true;

    public int eatPoint = 0;
    public int medicinePoint = 0;

    [SerializeField] AudioClip compSE;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void OncompSE()
    {
        audioSource.PlayOneShot(compSE);
    }
}
