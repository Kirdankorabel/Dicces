public class DiceInfo
{
    public readonly DicesAction[] effects;

    public event System.Action<DicesAction> ResultGotted;

    public DiceInfo(DicesAction[] _effects)
    {
        effects = _effects;
    }

    public void ShowResult(int number)
    {
        ResultGotted?.Invoke(effects[number]);
        ResultGotted = null;
    }
}
