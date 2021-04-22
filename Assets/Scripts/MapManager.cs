using DG.Tweening;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject Dog_Map;
    public GameObject Chicken_Map;
    public GameObject Penguin_Map;
    public GameObject Lion_Map;
    public GameObject PlusMapPanel;

    public void Dog_Map_Button()
    {
        Dog_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
    }

    public void Chicken_Map_Button()
    {
        Chicken_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
    }

    public void Penguin_Map_Button()
    {
        Penguin_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
    }

    public void Lion_Map_Button()
    {
        Lion_Map.transform.DOMove(new Vector3(0, 0, 0), 2f).SetEase(Ease.OutElastic);
        PlusMapPanel.SetActive(false);
    }
}
