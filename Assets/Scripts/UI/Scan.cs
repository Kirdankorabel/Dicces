using UnityEngine;
using UnityEngine.UI;

public class Scan : MonoBehaviour
{
    [SerializeField] private Image[] images = new Image[6];
    [SerializeField] private Text[] texts = new Text[6];
    [SerializeField] private Button CloseButton;

    private void Awake()
    {
        GameController.Scan = this;
        this.gameObject.SetActive(false);
        CloseButton.onClick.AddListener(() => this.gameObject.SetActive(false));
    }

    public void Show(Dice dice)
    {
        this.gameObject.SetActive(true);
        for (var i = 0; i < 6; i++)
        {
            images[i].material = new Material(images[i].material);
            if(dice.DiceInfo.effects[i].value2 != 0)
                texts[i].text = $"{dice.DiceInfo.effects[i].value}/{dice.DiceInfo.effects[i].value2}";
            else
                texts[i].text = dice.DiceInfo.effects[i].value.ToString();
             images[i].material.mainTexture = dice.Faces[i].GetTexture;
        }
    }
}
