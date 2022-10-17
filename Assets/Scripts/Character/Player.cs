public class Player : Character
{
    private void Awake()
    {
        LevelController.LevelCompleted += (res) => Destroy();
        RollButton.Rolled += () =>
            Move();
    }
}
