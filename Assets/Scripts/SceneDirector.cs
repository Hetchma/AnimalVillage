using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneDirector : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
    }
}
