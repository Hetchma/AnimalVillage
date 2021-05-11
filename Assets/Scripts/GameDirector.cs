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
    float span = 0.4f;

    int gold = 0;

    int goldRank = 0;
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

        if (Gold.text != "MAX")
        {
            NewMapTrigger();
        }


    }

    void NewMapTrigger()
    {
        if (int.Parse(Gold.text) >= 100 && goldRank == 0)
        {
            DogMapButton.interactable = true;
            goldRank++;
            gold = 0;
            maxgold = 150;
            onRocked_Gold = true;
        }
        else if (int.Parse(Gold.text) >= 150 && goldRank == 1)
        {
            ChickenMapButton.interactable = true;
            goldRank++;
            gold = 0;
            maxgold = 200;
            onRocked_Gold = true;

        }
        else if (int.Parse(Gold.text) >= 200 && goldRank == 2)
        {
            PenguinMapButton.interactable = true;
            goldRank++;
            gold = 0;
            maxgold = 300;
            onRocked_Gold = true;
        }
        else if (int.Parse(Gold.text) >= 300 && goldRank == 3)
        {
            LionMapButton.interactable = true;
            goldRank++;
            gold = 0;
            onRocked_Gold = true;
        }
    }

    void HeartTrigger()
    {
        if (int.Parse(Heart.text) >= 100)
        {

        }
    }

    void DiaTrigger()
    {
        if (int.Parse(Dia.text) >= 100)
        {

        }
    }
}
