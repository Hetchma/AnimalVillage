using UnityEngine;


public class UIPanel : MonoBehaviour
{
    public bool CanOtherButton = true;
    public int eatPoint = 0;
    public int medicinePoint = 0;

    [SerializeField] Camera mainCamera;
    float posX_Max = 20f;
    float posX_Min = -20f;
    float posZ_Max = 5f;
    float posZ_Min = -20f;
    [SerializeField] AudioClip compSE;
    AudioSource audioSource;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        CameraMove();
    }

    public void OncompSE()
    {
        audioSource.PlayOneShot(compSE);
    }

    void CameraMove()
    {
        Vector3 cam_Pos = mainCamera.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cam_Pos.x += -0.5f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            cam_Pos.x += 0.5f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            cam_Pos.z += 0.5f;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            cam_Pos.z += -0.5f;
        }

        cam_Pos.x = Mathf.Clamp(cam_Pos.x, posX_Min, posX_Max);
        cam_Pos.z = Mathf.Clamp(cam_Pos.z, posZ_Min, posZ_Max);
        mainCamera.transform.position = new Vector3(cam_Pos.x, cam_Pos.y, cam_Pos.z);

        //float posX = 0;
        //float posZ = 0;

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    posX = -1f;
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    posX = 1f;
        //}
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    posZ = 1f;

        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    posZ = -1f;
        //}

        //mainCamera.transform.position += new Vector3(posX, 0, posZ);

    }
}
