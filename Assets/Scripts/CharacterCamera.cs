using UnityEngine;
using UnityEngine.UI;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject ZoomOutButton;
    [SerializeField] Button eatButton;
    [SerializeField] Button medicineButton;
    [SerializeField] MissionPanelManager MissionPanelManager;
    public bool onClick = false;
    Transform hitTrn;
    GameObject hitObj;

    //軸調整
    int yAdjust = 5;
    int zAdjust = -7;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //float distance = 100; // 飛ばす&表示するRayの長さ デバッグ
            //float duration = 3;   // 表示期間（秒）デバッグ

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            ////光線可視化　デバッグ
            //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Animal"))
                {
                    hitObj = hit.collider.gameObject;
                    hitTrn = hit.transform;
                    onClick = true;

                    if (hitObj.transform.Find("Canvas/balloon_eat").gameObject.activeSelf)
                    {
                        eatButton.interactable = true;
                    }
                    if (hitObj.transform.Find("Canvas/balloon_medicine").gameObject.activeSelf)
                    {
                        medicineButton.interactable = true;
                    }
                }
            }
        }

        if (onClick)
        {
            //ズーム処理
            MainCamera.transform.position = new Vector3(hitTrn.position.x, hitTrn.position.y + yAdjust, hitTrn.position.z + zAdjust);
            MainCamera.transform.LookAt(hitTrn.position);
            ZoomOutButton.SetActive(true);
        }
        else
        {
            ZoomOutButton.SetActive(false);
        }
    }

    public void OnClickReturn()
    {
        MainCamera.transform.position = new Vector3(0, 10f, -20f);
        MainCamera.transform.rotation = Quaternion.Euler(25f, 0, 0);
        hitObj.transform.Find("Canvas/balloon_eat").gameObject.SetActive(false);
        hitObj.transform.Find("Canvas/balloon_medicine").gameObject.SetActive(false);
        onClick = false;
    }

    public void OnClickEat()
    {
        MissionPanelManager.eatPoint++;
        hitObj.transform.Find("Canvas/balloon_eat").gameObject.SetActive(false);
    }

    public void OnClickMedicine()
    {
        MissionPanelManager.medicinePoint++;
        hitObj.transform.Find("Canvas/balloon_medicine").gameObject.SetActive(false);
    }
}
