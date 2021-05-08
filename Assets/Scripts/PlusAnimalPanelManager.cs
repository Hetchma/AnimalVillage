using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlusAnimalPanelManager : MonoBehaviour
{
    public GameObject PlusAnimalPanel;
    public GameObject mainCamera;
    public GameObject UICamera;
    public GameObject R_Button;
    public GameObject L_Button;
    public GameObject CatPrefab;
    public GameObject DogPrefab;
    public GameObject ChickenPrefab;
    public GameObject PenguinPrefab;
    public GameObject LionPrefab;
    [SerializeField] GameObject newNamePanel;
    [SerializeField] GameObject cat_Map;
    [SerializeField] GameObject dog_Map;
    [SerializeField] GameObject chicken_Map;
    [SerializeField] GameObject penguin_Map;
    [SerializeField] GameObject lion_Map;

    [SerializeField] Button plusButton;
    [SerializeField] MapManager mapManager;
    [SerializeField] UIPanel uIPanel;
    [SerializeField] TextMeshProUGUI nameText;

    [SerializeField] Text heartText;
    [SerializeField] Text CostText;

    [SerializeField] ParticleSystem animalParticle;

    GameObject animal;
    InputField inputField;
    Text inputName;

    //軸調整
    int yAdjust = 5;
    int zAdjust = -7;

    //動物生成ハートコスト
    int catCost = 5;
    int dogCost = 10;
    int chickenCost = 20;
    int penguinCost = 30;
    int lionCost = 50;

    // Update is called once per frame
    void Update()
    {
        AnimalCost();
        CanPlusAnimal();

        if (UICamera.activeSelf && UICamera.transform.localPosition.x <= 1000f)
        {
            L_Button.SetActive(false);
        }
        else if (UICamera.activeSelf)
        {
            L_Button.SetActive(true);
        }

        if (UICamera.activeSelf && UICamera.transform.localPosition.x >= 1400f)
        {
            R_Button.SetActive(false);
        }
        else if (UICamera.activeSelf)
        {
            R_Button.SetActive(true);
        }
    }

    public void OpenPlusAnimalPanel()
    {
        if (uIPanel.CanOtherButton)
        {
            gameObject.SetActive(true);
            R_Button.SetActive(true);
        }
    }

    public void RightButton()
    {
        UICamera.transform.localPosition += new Vector3(100f, 0, 0);
        //AnimalCost();
        //CanPlusAnimal();
    }

    public void LeftButton()
    {
        UICamera.transform.localPosition += new Vector3(-100f, 0, 0);
        //AnimalCost();
        //CanPlusAnimal();
    }


    void AnimalCost()
    {
        if (UICamera.transform.localPosition == new Vector3(1000f, 0, 0))
        {
            CostText.text = catCost.ToString();
            nameText.text = "ねこ";
        }
        else if (UICamera.transform.localPosition == new Vector3(1100f, 0, 0))
        {
            CostText.text = dogCost.ToString();
            nameText.text = "いぬ";
        }
        else if (UICamera.transform.localPosition == new Vector3(1200f, 0, 0))
        {
            CostText.text = chickenCost.ToString();
            nameText.text = "にわとり";
        }
        else if (UICamera.transform.localPosition == new Vector3(1300f, 0, 0))
        {
            CostText.text = penguinCost.ToString();
            nameText.text = "ペンギン";
        }
        else if (UICamera.transform.localPosition == new Vector3(1400f, 0, 0))
        {
            CostText.text = lionCost.ToString();
            nameText.text = "ライオン";
        }
    }


    void CanPlusAnimal()
    {
        if (UICamera.transform.localPosition == new Vector3(1000f, 0, 0) && mapManager.OnCatMap && int.Parse(heartText.text) >= catCost)
        {
            plusButton.interactable = true;
        }
        else if (UICamera.transform.localPosition == new Vector3(1100f, 0, 0) && mapManager.OnDogMap && int.Parse(heartText.text) >= dogCost)
        {
            plusButton.interactable = true;
        }
        else if (UICamera.transform.localPosition == new Vector3(1200f, 0, 0) && mapManager.OnChickenMap && int.Parse(heartText.text) >= chickenCost)
        {
            plusButton.interactable = true;
        }
        else if (UICamera.transform.localPosition == new Vector3(1300f, 0, 0) && mapManager.OnPenguinMap && int.Parse(heartText.text) >= penguinCost)
        {
            plusButton.interactable = true;
        }
        else if (UICamera.transform.localPosition == new Vector3(1400f, 0, 0) && mapManager.OnLionMap && int.Parse(heartText.text) >= lionCost)
        {
            plusButton.interactable = true;
        }
        else
        {
            plusButton.interactable = false;
        }
    }


    public void PlusAnimal()
    {
        if (UICamera.transform.localPosition == new Vector3(1000f, 0, 0) && cat_Map.transform.position.y == 0)
        {
            Plus(CatPrefab, new Vector3(0, 6f, 0));
            heartText.text = (int.Parse(heartText.text) - catCost).ToString();

        }
        else if (UICamera.transform.localPosition == new Vector3(1100f, 0, 0) && dog_Map.transform.position.y == 0)
        {
            Plus(DogPrefab, new Vector3(-14f, 7f, -3f));
            heartText.text = (int.Parse(heartText.text) - dogCost).ToString();
        }
        else if (UICamera.transform.localPosition == new Vector3(1200f, 0, 0) && chicken_Map.transform.position.y == 0)
        {
            Plus(ChickenPrefab, new Vector3(-9f, 5f, 10f));
            heartText.text = (int.Parse(heartText.text) - chickenCost).ToString();
        }
        else if (UICamera.transform.localPosition == new Vector3(1300f, 0, 0) && penguin_Map.transform.position.y == 0)
        {
            Plus(PenguinPrefab, new Vector3(13f, 7f, 17f));
            heartText.text = (int.Parse(heartText.text) - penguinCost).ToString();
        }
        else if (UICamera.transform.localPosition == new Vector3(1400f, 0, 0) && lion_Map.transform.position.y == 0)
        {
            Plus(LionPrefab, new Vector3(24f, 7f, -1f));
            heartText.text = (int.Parse(heartText.text) - lionCost).ToString();
        }


    }
    void Plus(GameObject animalPrefab, Vector3 vector3)
    {
        uIPanel.CanOtherButton = false;
        ParticleSystem particle = Instantiate(animalParticle, new Vector3(vector3.x, 2f, vector3.z), Quaternion.identity);

        animal = Instantiate(animalPrefab, vector3, Quaternion.Euler(0, 0, 0));
        inputName = animal.GetComponentInChildren<Text>();

        Sequence cameraSequence_1 = DOTween.Sequence()
          .Append(mainCamera.transform.DOMove(new Vector3(vector3.x, vector3.y + yAdjust, vector3.z + zAdjust), 0))
          .Join(mainCamera.transform.DOMove(new Vector3(0, -5f, 0), 3f).SetRelative());
        cameraSequence_1.Play();

        Sequence animalMoveSequence = DOTween.Sequence()
        .Append(animal.transform.DORotate(Vector3.up * 180f, 3f))
        .Join(animal.transform.DOMove(new Vector3(0, -5f, 0), 3f).SetRelative())
        .AppendCallback(() => newNamePanel.SetActive(true))
        .AppendCallback(() => inputField = GameObject.Find("NameInput").GetComponent<InputField>())
        .AppendCallback(() => particle.Stop());
        animalMoveSequence.Play();

        plusButton.interactable = false;
        gameObject.SetActive(false);
    }

    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        inputName.text = inputField.text;

        //入力フォームのテキストを空にする
        inputField.text = "";

        mainCamera.transform.position = new Vector3(0, 10f, -20f);
        mainCamera.transform.rotation = Quaternion.Euler(25f, 0, 0);
        newNamePanel.SetActive(false);
        uIPanel.CanOtherButton = true;
    }

    //MacOSで改行できないようにする
    public void OnValueChanged()
    {
        string value = this.GetComponent<InputField>().text;
        if (value.IndexOf("\n") != -1)
        {
            this.GetComponent<InputField>().text = value;
        }
    }
}
