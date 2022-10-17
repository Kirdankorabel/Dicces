using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Character _player;
    [SerializeField] private Character _enemy;
    [SerializeField] private DiceCreator _diceCreator;
    [SerializeField] private RollButton _rollButton;

    private Round _round;

    public static event Action<bool> LevelCompleted;

    private void Awake()
    {
        _enemy.Moved += () => _rollButton.ShowButton();
    }

    public void LoadLevel(int level)
    {
        _player.SetInfo(new CharacterInfo(20, PlayerCubes.dices))
            .SetDices(_diceCreator.CreateDices(_player.CharacterInfo.diceInfos, _player.Positions));
        _player.CharacterInfo.Die += () => LevelCompleted?.Invoke(false);
        _enemy.SetInfo(EnemysInfos.GetEnemy(level))
            .SetImage(_diceCreator.GetIcon(UnityEngine.Random.Range(0, 10)))
            .SetDices(_diceCreator.CreateDices(_enemy.CharacterInfo.diceInfos, _enemy.Positions));
        _enemy.CharacterInfo.Die += () => LevelCompleted?.Invoke(true);
    }

    public void StartRound()
    {
        StartCoroutine(Waiter.WaiteCoroutine(() =>
        {
            _round = new Round(_player, _enemy);
            _round.RoundEnded += () => StartRound();
        }, 1f));
    }
}
