using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionPanelManager : MonoBehaviour
{
    [SerializeField] UIPanel uIPanel;
    [SerializeField] MapManager mapManager;
    [SerializeField] GameObject diaPrefab;
    [SerializeField] GameObject diaPoint;
    [SerializeField] Text diaCount;
    [SerializeField] Text heartCount;
    [SerializeField] MovingText movingText;

    public List<GameObject> missionTexts = new List<GameObject>();

    private void Start()
    {
    }


    private void Update()
    {
        Mission_1();
        Mission_2();
        Mission_3();
        Mission_4();
        Mission_5();
        Mission_6();
    }

    public void OpenEventPanel()
    {
        if (uIPanel.CanOtherButton)
        {
            gameObject.SetActive(true);
        }
    }

    //最初の仲間を呼んでみよう
    public void Mission_1()
    {
        int count = GameObject.FindGameObjectsWithTag("Animal").Length;
        if (count >= 1)
        {
            OnMission("Viewport/Content/MissionBoard_1/CompleteButton");
        }
    }

    public void Mission_1_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_1");
    }


    //仲間を３匹に増やそう
    public void Mission_2()
    {
        int count = GameObject.FindGameObjectsWithTag("Animal").Length;
        if (count >= 3)
        {
            OnMission("Viewport/Content/MissionBoard_2/CompleteButton");
        }
    }

    public void Mission_2_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_2");
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


    //動物たちにリンゴを5個食べさせてあげよう
    public void Mission_4()
    {
        if (int.Parse(heartCount.text) >= 50)
        {
            OnMission("Viewport/Content/MissionBoard_4/CompleteButton");
        }
    }

    public void Mission_4_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_4");
    }

    //にわとりの島を出現させよう
    public void Mission_5()
    {
        if (mapManager.OnChickenMap)
        {
            OnMission("Viewport/Content/MissionBoard_5/CompleteButton");
        }
    }

    public void Mission_5_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_5");
    }

    //動物たちにリンゴを20個食べさせてあげよう
    public void Mission_6()
    {
        if (int.Parse(heartCount.text) >= 200)
        {
            OnMission("Viewport/Content/MissionBoard_6/CompleteButton");
        }
    }

    public void Mission_6_Comp()
    {
        MissionComplete("Viewport/Content/MissionBoard_6");
    }

    //ムーブテキスト更新
    void TextGetter()
    {
        GameObject content = transform.Find("Viewport/Content").gameObject;

        missionTexts.Clear();
        for (int i = 0; i < content.transform.childCount; i++)
        {
            if (content.transform.GetChild(i).transform.Find("CompleteButton").gameObject.activeSelf)
            {
                missionTexts.Add(content.transform.GetChild(i).gameObject.transform.Find("MissionText").gameObject);
            }
        }

        movingText.canMoveText = false;
        movingText.Text1.text = missionTexts[0].GetComponent<TextMeshProUGUI>().text;
        movingText.TextSpace();
        movingText.canMoveText = true;
    }

    //ミッション内容達成
    void OnMission(string path)
    {
        GameObject comp_Button = transform.Find(path).gameObject;
        comp_Button.GetComponent<Button>().interactable = true;
    }

    //ミッション完了ボタン押下
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

        //ムービングテキスト更新
        TextGetter();
    }
}
