using UnityEngine;
using UnityEngine.UI;

public class QuitPanel : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private void Awake()
    {
        _yesButton.onClick.AddListener(Application.Quit);
        _noButton.onClick.AddListener(() => gameObject.SetActive(false));
    }
}
