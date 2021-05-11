using Unity.VisualScripting;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField] GameObject howToPanel;


    public void OnSettingPanel()
    {
        gameObject.SetActive(true);
    }

    //ゲーム終了ボタン処理
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    public void OnHowToPanel()
    {
        howToPanel.SetActive(true);
    }

    public void OffHowToPanel()
    {
        howToPanel.SetActive(false);
    }

}
