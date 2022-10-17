using UnityEngine;
using UnityEngine.UI;

public class RollButton : MonoBehaviour
{
    [SerializeField] private Button _rollButton;
    public static event System.Action Rolled;

    private void Start()
    {
        _rollButton.onClick.AddListener(() =>
        {
            Rolled?.Invoke();
            _rollButton.gameObject.SetActive(false);
        }); 
        _rollButton.gameObject.SetActive(false);
    }

    public void ShowButton()
        => _rollButton.gameObject.SetActive(true);
}
