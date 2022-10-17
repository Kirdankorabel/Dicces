using UnityEngine;
using UnityEngine.UI;

public class EffectUI : MonoBehaviour
{
    [SerializeField] Text text;

    private int _value;

    private void Awake()
    {
        Round.RoundStarted += () =>
        {
            _value = 0;
            gameObject.SetActive(false);
        }; 
    }

    public void AddValue(int value)
    {
        _value += value;
        gameObject.SetActive(true);
        text.text = _value.ToString();
    }
}
