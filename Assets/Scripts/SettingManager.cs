using UnityEngine;

public class SettingManager : MonoBehaviour
{
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

}
