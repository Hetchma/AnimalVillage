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


    [SerializeField] Text Heart;
    [SerializeField] Text Dia;
    [SerializeField] Text Gold;


    public void Dog_Map_Button()
    {
        Dog_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
        Dog_Map_B.interactable = false;
        GameDirector.onRocked_Gold = false;
        Gold.text = "0";
    }

    public void Chicken_Map_Button()
    {
        Chicken_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
        Chicken_Map_B.interactable = false;
        GameDirector.onRocked_Gold = false;
        Gold.text = "0";
    }

    public void Penguin_Map_Button()
    {
        Penguin_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
        Penguin_Map_B.interactable = false;
        GameDirector.onRocked_Gold = false;
        Gold.text = "0";
    }

    public void Lion_Map_Button()
    {
        Lion_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
        Lion_Map_B.interactable = false;
        Gold.text = "MAX";
    }
}
