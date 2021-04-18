using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    //カメラオブジェクト
    public GameObject mainCamera;
    bool onClick = false;


    //軸調整
    int yAdjust = 5;
    int zAdjust = -10;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Animal"))
                {
                    OnClickCharacter();
                }
            }
        }

        if (onClick)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + yAdjust, transform.position.z + zAdjust);
            mainCamera.transform.LookAt(transform.position);
        }
    }

    public void OnClickCharacter()
    {
        onClick = true;
    }

}