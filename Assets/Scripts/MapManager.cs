using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject Dog_Map;
    public GameObject Chicken_Map;
    public GameObject Penguin_Map;
    public GameObject Lion_Map;
    public GameObject PlusMapPanel;
    public Button Dog_Map_B;
    public Button Chicken_Map_B;
    public Button Penguin_Map_B;
    public Button Lion_Map_B;

    public GameDirector GameDirector;

    [SerializeField] GameObject mainCamera;

    [SerializeField] Text Heart;
    [SerializeField] Text Dia;
    [SerializeField] Text Gold;

    public bool OnCatMap = true;
    public bool OnDogMap = false;
    public bool OnChickenMap = false;
    public bool OnPenguinMap = false;
    public bool OnLionMap = false;


    public void Dog_Map_Button()
    {
        NewMapInst(Dog_Map, new Vector3(-12f, 10f, -20f), "0");
        Dog_Map_B.interactable = false;
        GameDirector.onRocked_Gold = false;
        OnDogMap = true;
    }

    public void Chicken_Map_Button()
    {
        NewMapInst(Chicken_Map, new Vector3(-4.5f, 10f, -6.5f), "0");
        Chicken_Map_B.interactable = false;
        GameDirector.onRocked_Gold = false;
        OnChickenMap = true;
    }

    public void Penguin_Map_Button()
    {
        NewMapInst(Penguin_Map, new Vector3(14f, 10f, -4f), "0");
        Penguin_Map_B.interactable = false;
        GameDirector.onRocked_Gold = false;
        OnPenguinMap = true;
    }

    public void Lion_Map_Button()
    {
        NewMapInst(Lion_Map, new Vector3(18.5f, 10f, -23f), "MAX");
        Lion_Map_B.interactable = false;
        OnLionMap = true;
    }

    void NewMapInst(GameObject map, Vector3 mapPos, string goldText)
    {
        Sequence cameraSequence_1 = DOTween.Sequence()
            .Append(mainCamera.transform.DOMove(mapPos, 1f));
        Sequence mapSequence = DOTween.Sequence()
            .Append(map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic));
        Sequence cameraSequence_2 = DOTween.Sequence()
            .Append(mainCamera.transform.DOMove(new Vector3(0, 10, -20), 1f));
        cameraSequence_1.Append(mapSequence).Append(cameraSequence_2);
        cameraSequence_1.Play();

        PlusMapPanel.SetActive(false);
        Gold.text = goldText;

    }
}
