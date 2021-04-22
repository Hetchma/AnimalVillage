using DG.Tweening;
using UnityEngine;

public class PlusAnimalPanelManager : MonoBehaviour
{
    public GameObject PlusAnimalPanel;
    public GameObject UICamera;
    public GameObject R_Button;
    public GameObject L_Button;
    public GameObject CatPrefab;
    public GameObject DogPrefab;
    public GameObject ChickenPrefab;
    public GameObject PenguinPrefab;
    public GameObject LionPrefab;
    GameObject animal;


    // Update is called once per frame
    void Update()
    {
        if (UICamera.activeSelf && UICamera.transform.localPosition.x <= 1000f)
        {
            L_Button.SetActive(false);
        }
        else if (UICamera.activeSelf)
        {
            L_Button.SetActive(true);
        }

        if (UICamera.activeSelf && UICamera.transform.localPosition.x >= 1400f)
        {
            R_Button.SetActive(false);
        }
        else if (UICamera.activeSelf)
        {
            R_Button.SetActive(true);
        }
    }

    public void OpenPlusAnimalPanel()
    {
        gameObject.SetActive(true);
        R_Button.SetActive(true);
    }

    public void RightButton()
    {
        UICamera.transform.localPosition += new Vector3(100f, 0, 0);
    }

    public void LeftButton()
    {
        UICamera.transform.localPosition += new Vector3(-100f, 0, 0);
    }

    public void PlusAnimal()
    {
        if (UICamera.transform.localPosition == new Vector3(1000f, 0, 0))
        {
            Plus(CatPrefab, new Vector3(0, 5f, 0));
        }
        else if (UICamera.transform.localPosition == new Vector3(1100f, 0, 0))
        {
            Plus(DogPrefab, new Vector3(0, 5f, 0));
        }
        else if (UICamera.transform.localPosition == new Vector3(1200f, 0, 0))
        {
            Plus(ChickenPrefab, new Vector3(0, 5f, 0));
        }
        else if (UICamera.transform.localPosition == new Vector3(1300f, 0, 0))
        {
            Plus(PenguinPrefab, new Vector3(0, 5f, 0));
        }
        else if (UICamera.transform.localPosition == new Vector3(1400f, 0, 0))
        {
            Plus(LionPrefab, new Vector3(0, 5f, 0));
        }


    }
    void Plus(GameObject animalPPrefab, Vector3 vector3)
    {
        animal = Instantiate(animalPPrefab, vector3, Quaternion.Euler(0, 0, 0));
        Sequence sequence = DOTween.Sequence()
        .Append(animal.transform.DORotate(Vector3.up * 180f, 3f))
        .Join(animal.transform.DOMove(new Vector3(0, -5f, 0), 3f).SetRelative());
        sequence.Play();

    }
}
