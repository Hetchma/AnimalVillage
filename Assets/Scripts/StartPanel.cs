using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartPanel : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject mainCamera;
    public GameObject UICanvas;
    [SerializeField] TextMeshProUGUI startText;

    public float DurationSeconds;
    public Ease EaseType;

    private void Awake()
    {
        //DOTween.SetTweensCapacity(Tween数, Sequence数);
        DOTween.Init();
    }


    void Update()
    {
        mainCamera.transform.RotateAround(targetObject.transform.position, new Vector3(0, 1, 0), -0.2f);

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Sequence startSequence = DOTween.Sequence()
        //startText.DOFade(0.0f, this.DurationSeconds).SetEase(this.EaseType).SetLoops(-1, LoopType.Yoyo);
        //.AppendCallback(() => startText.color += new Color32(0, 0, 0, 255));

    }

    public void StartButton()
    {
        Destroy(gameObject);
        UICanvas.SetActive(true);
        mainCamera.transform.position = new Vector3(0, 10f, -20f);
        mainCamera.transform.rotation = Quaternion.Euler(25, 0, 0);
    }
}
