using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    //カメラオブジェクト
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject ZoomOutButton;
    //[SerializeField] GameObject UICanvas;
    public bool onClick = false;
    Transform hittrn;

    //軸調整
    int yAdjust = 5;
    int zAdjust = -7;

    //private void Awake()
    //{
    //    MainCamera = GameObject.Find("Main Camera");
    //    ZoomOutButton = GameObject.Find("ZoomOutButton");
    //}


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
                    hittrn = hit.transform;
                    onClick = true;
                }
            }
        }

        if (onClick)
        {
            //ズーム処理
            MainCamera.transform.position = new Vector3(hittrn.position.x, hittrn.position.y + yAdjust, hittrn.position.z + zAdjust);
            MainCamera.transform.LookAt(hittrn.position);
            ZoomOutButton.SetActive(true);
            //ZoomOutButton.transform.localPosition = UICanvas.transform.position + new Vector3(0, -50f, 0);
        }
        else
        {
            ZoomOutButton.SetActive(false);
            //ZoomOutButton.transform.localPosition = UICanvas.transform.position + new Vector3(0, 200f, 0);
        }
    }

    public void OnClickReturn()
    {
        MainCamera.transform.position = new Vector3(0, 10f, -20f);
        MainCamera.transform.rotation = Quaternion.Euler(25f, 0, 0);
        onClick = false;
    }
}
