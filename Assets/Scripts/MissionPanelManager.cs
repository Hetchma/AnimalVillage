using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanelManager : MonoBehaviour
{
    [SerializeField] UIPanel uIPanel;
    [SerializeField] MapManager mapManager;
    [SerializeField] GameObject diaPrefab;
    [SerializeField] GameObject diaPoint;
    [SerializeField] Text diaCount;


    private void Update()
    {
        Mission_1();
        Mission_3();
    }


    public void OpenEventPanel()
    {
        if (uIPanel.CanOtherButton)
        {
            gameObject.SetActive(true);
        }
    }

    //動物を３匹呼ぼう
    public void Mission_1()
    {
        int count = GameObject.FindGameObjectsWithTag("Animal").Length;
        if (count >= 3)
        {
            OnMission("Viewport/Content/MissionBoard_1/CompleteButton");
        }
    }

    public void Mission_1_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_1");
    }

    public void Mission_2()
    {

    }

    public void Mission_2_Comp()
    {

    }

    //犬の島を出現させよう
    public void Mission_3()
    {
        if (mapManager.OnDogMap)
        {
            OnMission("Viewport/Content/MissionBoard_3/CompleteButton");
        }
    }

    public void Mission_3_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_3");
    }

    void OnMission(string path)
    {
        GameObject comp_Button = transform.Find(path).gameObject;
        comp_Button.GetComponent<Button>().interactable = true;
    }

    void MissionComplete(string path)
    {
        //SE
        uIPanel.OncompSE();

        //イベントパネルUI処理
        GameObject comp_Button = transform.Find(path + "/CompleteButton").gameObject;
        comp_Button.SetActive(false);
        comp_Button.transform.Find("Text").gameObject.GetComponent<Text>().text = "達成";
        GameObject comp_Board = transform.Find(path).gameObject;
        comp_Board.GetComponent<Image>().color = Color.gray;

        //任意ボタン位置にダイヤ画像生成
        GameObject dia = Instantiate(diaPrefab);
        dia.transform.SetParent(uIPanel.transform, false);
        dia.transform.position = comp_Button.transform.position;

        //ダイヤ取得Tween・ポイント追加
        int point = int.Parse(diaCount.text);

        Sequence diaSequence = DOTween.Sequence()
        .Append(dia.transform.DOMove(diaPoint.transform.position, 1f))
        .AppendCallback(() => diaCount.GetComponent<Text>().text = (point + 5).ToString())
        .AppendCallback(() => Destroy(dia));

        //パネル非表示
        gameObject.SetActive(false);
    }
}
