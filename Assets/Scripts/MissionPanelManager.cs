using UnityEngine;

public class MissionPanelManager : MonoBehaviour
{
    [SerializeField] UIPanel uIPanel;

    public void OpenEventPanel()
    {
        if (uIPanel.CanOtherButton)
        {
            gameObject.SetActive(true);
        }
    }

}
