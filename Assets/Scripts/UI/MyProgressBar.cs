using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class MyProgressBar : MonoBehaviour
{
    [Header("Bar Setting")]
    public Color BarColor;
    public Color BarBackGroundColor;
    public Sprite BarBackGroundSprite;
    [Range(1f, 100f)]
    public int Alert = 20;
    public Color BarAlertColor;

    [SerializeField] private Image bar, barBackground;
    [SerializeField] private Text txtTitle;
    private int barValue;

    private int startVaue;

    public int BarValue
    {
        get => barValue;

        set
        {
            barValue = value;
            UpdateValue(barValue);
        }
    }

    public void SetStartValue(int value)
    {
        startVaue = value;
        barValue = value;
        txtTitle.text = value + "/" + startVaue;
        bar.fillAmount = 1f;
    }


    private void Awake()
    {
        txtTitle = transform.Find("Text").GetComponent<Text>();
        barBackground = transform.Find("BarBackground").GetComponent<Image>();
    }

    private void Start()
    {
        bar.color = BarColor;
        barBackground.color = BarBackGroundColor;
        barBackground.sprite = BarBackGroundSprite;

        UpdateValue(barValue);
    }

    void UpdateValue(int value)
    {
        barValue = value;
        var fillAmount = (float)value / (float)startVaue;
        txtTitle.text = value + "/" + startVaue;

        if (bar.fillAmount > fillAmount)
            StartCoroutine(BarChangedCorutine(fillAmount, -1));
        if (bar.fillAmount < fillAmount)
            StartCoroutine(BarChangedCorutine(fillAmount, 1));
    }

    private IEnumerator BarChangedCorutine(float fillAmount, int value)
    {
        {
            while (Mathf.Abs(bar.fillAmount - fillAmount) > 0.01f)
            {
                bar.fillAmount = bar.fillAmount + value * 0.5f * Time.deltaTime;
                yield return null;
            }
        }
        yield break;
    }
}
