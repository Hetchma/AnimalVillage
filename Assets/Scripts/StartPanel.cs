using UnityEngine;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject mainCamera;
    public GameObject UICanvas;

    void Update()
    {
        mainCamera.transform.RotateAround(targetObject.transform.position, new Vector3(0, 1, 0), -0.1f);


        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }

    public void StartButton()
    {
        Destroy(gameObject);
        UICanvas.SetActive(true);
        mainCamera.transform.position = new Vector3(0, 10f, -20f);
        mainCamera.transform.rotation = Quaternion.Euler(25, 0, 0);
    }
}
