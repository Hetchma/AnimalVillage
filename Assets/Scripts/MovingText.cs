using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingText : MonoBehaviour
{
    float posx;
    float textWidth;

    // Start is called before the first frame update
    void Start()
    {
        textWidth = GetComponent<Text>().preferredHeight;
        posx = GetComponent<RectTransform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        posx -= 5f;
    }
}
