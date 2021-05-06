using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovingText : MonoBehaviour
{
    public TextMeshProUGUI Text1;
    public Image panel;
    float textWidth;
    float panelWidth;
    float textSpeed = 150f;
    int textLenMax = 30;
    string latestText;
    public bool canMoveText = true;

    private void Start()
    {
        TextSpace();
    }

    void Update()
    {
        if (canMoveText)
        {
            Text1.rectTransform.position += new Vector3(-textSpeed, 0, 0) * Time.deltaTime;

            if (Text1.rectTransform.localPosition.x < -(panelWidth / 2 + textWidth / 2))
            {
                Text1.rectTransform.localPosition = new Vector3(0, 0, 0);
                Text1.rectTransform.localPosition += new Vector3(panelWidth / 2 + textWidth / 2 + 20f, 0, 0);
            }
        }
    }

    //文字数が短い場合スペースで埋める
    public void TextSpace()
    {
        if (Text1.text != null)
        {
            //文字数を取得
            int len = Text1.text.Length;

            if (len < textLenMax)
            {
                for (int i = 0; i < textLenMax - len; i++)
                {
                    Text1.text += " ";
                }
            }
        }

        textWidth = Text1.preferredWidth;
        panelWidth = panel.rectTransform.sizeDelta.x;
    }

}
