using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] Text Heart;
    [SerializeField] Text Dia;
    [SerializeField] Text Gold;
    [SerializeField] Button DogMapButton;
    [SerializeField] Button ChickenMapButton;
    [SerializeField] Button PenguinMapButton;
    [SerializeField] Button LionMapButton;

    float currentTime;
    float span = 0.1f;

    int heart = 0;
    int dia = 0;
    int gold = 0;

    int goldCount = 0;
    int maxgold = 100;
    public bool onRocked_Gold = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span && gold <= maxgold && !onRocked_Gold)
        {
            gold++;
            currentTime = 0f;
            Gold.text = gold.ToString();
        }

        if (int.Parse(Heart.text) >= 100)
        {

        }
        if (int.Parse(Dia.text) >= 100)
        {

        }

        if (int.Parse(Gold.text) >= 100 && goldCount == 0)
        {
            DogMapButton.interactable = true;
            goldCount++;
            Gold.text = "0";
            gold = 0;
            maxgold = 150;
            onRocked_Gold = true;
        }
        else if (int.Parse(Gold.text) >= 150 && goldCount == 1)
        {
            ChickenMapButton.interactable = true;
            goldCount++;
            Gold.text = "0";
            gold = 0;
            maxgold = 200;
            onRocked_Gold = true;

        }
        else if (int.Parse(Gold.text) >= 200 && goldCount == 2)
        {
            PenguinMapButton.interactable = true;
            goldCount++;
            Gold.text = "0";
            gold = 0;
            maxgold = 300;
            onRocked_Gold = true;
        }
        else if (int.Parse(Gold.text) >= 300 && goldCount == 3)
        {
            LionMapButton.interactable = true;
            goldCount++;
            gold = 0;
            Gold.text = "MAX";
            onRocked_Gold = true;
        }
    }
}
