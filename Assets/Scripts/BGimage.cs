using UnityEngine;
using UnityEngine.EventSystems;

public class BGimage : MonoBehaviour
{
    public GameObject PlusAnimlalPanel;
    public GameObject PlusMapPanel;
    public GameObject MissionView;
    public GameObject SettingPanel;

    void Start()
    {
        //EventTriggerコンポーネントを取得
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();

        //イベントの設定に入る
        EventTrigger.Entry entry = new EventTrigger.Entry();

        //PointerDown(押した瞬間に実行する)イベントタイプを設定
        entry.eventID = EventTriggerType.PointerDown;

        //関数を設定
        entry.callback.AddListener((x) =>
        {
            Trigger();
        });

        //イベントの設定をEventTriggerに反映
        eventTrigger.triggers.Add(entry);
    }

    public void Trigger()
    {
        if (PlusAnimlalPanel.activeSelf)
        {
            PlusAnimlalPanel.SetActive(false);
        }
        if (PlusMapPanel.activeSelf)
        {
            PlusMapPanel.SetActive(false);
        }
        if (MissionView.activeSelf)
        {
            MissionView.SetActive(false);
        }
        if (SettingPanel.activeSelf)
        {
            SettingPanel.SetActive(false);
        }
    }
}
