using UnityEngine;

public class Sea : MonoBehaviour
{
    float waveheight = 0.05f;    //波の高さ
    float T = 7f; //周期

    private void Update()
    {
        float f = 1.0f / T; //周波数
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);
        transform.position = new Vector3(0, sin * waveheight, 0);
    }
}
