using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour
{
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }

    public void StartButton()
    {
        Destroy(gameObject);
    }
}