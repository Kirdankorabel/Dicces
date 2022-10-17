using System;

public class Round
{
    private Character _player;
    private Character _enemie;
    private EffectCreator effectCreator = new EffectCreator();

    public static Action RoundStarted;
    public Action RoundEnded;

    private Action del;

    public Round(Character player, Character enemy)
    {
        GameController.Round = this;
        del = new Action(UseAllEffects);
        _enemie = enemy; 
        _player = player;
        RoundStarted?.Invoke();
        _player.Moved += del;
        LevelController.LevelCompleted += (res) => RoundEnded = null;
        Roll();
    }

    public void Roll()
    {
        if(_enemie.CharacterInfo != null)
            _enemie.Move();
    }

    private void UseAllEffects()
    {
        CreateEffects();
        var values = Enum.GetValues(typeof(EffectType));
        for (var i = 0; i < values.Length; i++)
        {
            var effectType = (EffectType)values.GetValue(i);
            UseEfeect(effectType, _player);
            UseEfeect(effectType, _enemie);
        }
        _player.Moved -= del;
        RoundEnded?.Invoke();
    }

    private void CreateEffects()
    {
        foreach (var action in _player.CharacterInfo.RoundAction.Actions)
            effectCreator.CreateEffect(action, _player.CharacterInfo, _enemie.CharacterInfo);
        foreach (var action in _enemie.CharacterInfo.RoundAction.Actions)
            effectCreator.CreateEffect(action, _enemie.CharacterInfo, _player.CharacterInfo);
    }

    private void UseEfeect(EffectType effectType, Character character)
    {
        if(character.CharacterInfo != null)
            character.CharacterInfo.UseEffect(effectType);
    }
}
