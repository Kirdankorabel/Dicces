using UnityEngine;
using UnityEngine.UI;

public class ResultUIPanel : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Text _levelCounter;
    [SerializeField] private Text _result;
    [SerializeField] private Text _buttonText;

    public static System.Action PlayNext;

    private void Awake()
    {
        _nextButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            PlayNext?.Invoke();
        });
        LevelController.LevelCompleted += (result) =>
        {
            gameObject.SetActive(true);
            _levelCounter.text = $"{GameController.LevelCounter + 1} / {GameController.levelsCount}";
            if (result)
            {
                _result.text = "You win!";
                _buttonText.text = "Play next";
            }
            else
            {
                _result.text = "You lose!";
                _buttonText.text = "restart";
            }
        };
        gameObject.SetActive(false);
    }
}
