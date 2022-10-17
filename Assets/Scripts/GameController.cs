using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private GameObject _quitPanel;

    public static readonly int levelsCount = 12;
    private static int _levelCounter = 0;
    public static Scan Scan { get; set; }
    public static Round Round { get; set; }

    public static int LevelCounter => _levelCounter;

    private void Awake()
    {
        levelController.LoadLevel(_levelCounter);
        levelController.StartRound();

        LevelController.LevelCompleted += (result) => 
        StartCoroutine(Waiter.WaiteCoroutine(() => 
        {
            if (result)
                _levelCounter++;
            else
                _levelCounter = 0;
        }, 1f));

        ResultUIPanel.PlayNext += () =>
        {
            levelController.LoadLevel(_levelCounter);
            levelController.StartRound();
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _quitPanel.gameObject.SetActive(true);
    }
}
