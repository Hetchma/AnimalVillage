using UnityEngine;

public class CharacterUI : MonoBehaviour
{

    private RectTransform myRectTfm;

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 自身の向きをカメラに向ける
        myRectTfm.LookAt(Camera.main.transform);
        transform.Rotate(new Vector3(0f, -180f, 0f));

    }
}