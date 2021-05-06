using UnityEngine;

public class UICharacter : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.8f, 0));
    }
}
