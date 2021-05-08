using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject ZoomOutButton;
    [SerializeField] Button eatButton;
    [SerializeField] Button medicineButton;
    [SerializeField] UIPanel uIPanel;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject heartPoint;
    [SerializeField] Text heartCount;
    [SerializeField] MissionPanelManager missionPanelManager;

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
        uIPanel.eatPoint++;
        hitObj.transform.Find("Canvas/balloon_eat").gameObject.SetActive(false);
        hitObj.GetComponent<PlayerController>().eventTimer = 10.0f;
        eatButton.interactable = false;
        //OnClickReturn();
        AnimalCare();
    }

    public void OnClickMedicine()
    {
        uIPanel.medicinePoint++;
        hitObj.transform.Find("Canvas/balloon_medicine").gameObject.SetActive(false);
        hitObj.GetComponent<PlayerController>().eventTimer = 10.0f;
        medicineButton.interactable = false;
        //OnClickReturn();
        AnimalCare();
    }

    void AnimalCare()
    {
        //SE
        uIPanel.OncompSE();

        //任意ボタン位置にハート画像生成
        GameObject heart = Instantiate(heartPrefab);
        heart.transform.SetParent(uIPanel.transform, false);
        heart.transform.position = ZoomOutButton.transform.position;

        //ハート取得Tween・ポイント追加
        int point = int.Parse(heartCount.text);

        Sequence heartSequence = DOTween.Sequence()
        .Append(heart.transform.DOMove(heartPoint.transform.position, 1f))
        .AppendCallback(() => heartCount.GetComponent<Text>().text = (point + 10).ToString())
        .AppendCallback(() => missionPanelManager.heartTotalCount += 10)
        .AppendCallback(() => Destroy(heart));
    }
}
