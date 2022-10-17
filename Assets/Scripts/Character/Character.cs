using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected List<Vector3> _positions;
    [SerializeField] private MyProgressBar _progressBar;
    [SerializeField] private EffectAdder _effectUser;

    protected Dice[] _dices;
    protected CharacterInfo _characterInfo;
    protected int _counter;

    public List<Vector3> Positions => _positions;

    public event System.Action Moved;

    public CharacterInfo CharacterInfo
    {
        get => _characterInfo;
        set
        {
            _characterInfo = value;
        }
    }

    private void Awake()
    {
        LevelController.LevelCompleted += (res) => Destroy();
    }

    public Character SetDices(Dice[] dices)
    {
        _dices = dices;
        var _cubes = new List<DiceInfo>();
        foreach (var dice in _dices)
            _cubes.Add(dice.DiceInfo);
        return this;
    }

    public Character SetInfo(CharacterInfo characterInfo)
    {
        _characterInfo = characterInfo;
        _characterInfo.HealthChanged += (value) => _progressBar.BarValue = value;
        _progressBar.SetStartValue(_characterInfo.startHealth);
        return this;
    }

    public Character SetImage(Sprite sprite)
    {
        _icon.sprite = sprite;
        return this;
    }

    public void Move()
    {
        foreach (var dice in _dices)
            dice.Roll();

        foreach (var cube in _characterInfo.diceInfos)
            cube.ResultGotted += (result) =>
            {
                _counter++;
                _characterInfo.RoundAction.Actions.Add(result);
                _effectUser.UseEffect(result);
            };
        StartCoroutine(WaiteResultCorutine(() => Moved?.Invoke(), _characterInfo.diceInfos.Count)); 
    }

    protected void Destroy()
    {
        _characterInfo = null;
        foreach (var dice in _dices)
            Destroy(dice.gameObject);
        _dices = null;
        _characterInfo = null;
    }

    private IEnumerator WaiteResultCorutine(System.Action action, int value)
    {
        var time = Time.time;
        while (_counter < value)
            yield return null;
        _counter = 0;

        action?.Invoke();
        yield break;
    }
}
