using UnityEngine;

public class PlusPanelManager : MonoBehaviour
{
    public GameObject PlusAnimalPanel;
    public GameObject UICamera;
    public GameObject R_Button;
    public GameObject L_Button;

    // Start is called before the first frame update
    void Start()
    {

    }

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

    public void ClosePlusAnimalPanel()
    {
        gameObject.SetActive(false);
        R_Button.SetActive(false);
    }

    public void RightButton()
    {
        UICamera.transform.localPosition += new Vector3(100f, 0, 0);
    }

    public void LeftButton()
    {
        UICamera.transform.localPosition += new Vector3(-100f, 0, 0);
    }
}
