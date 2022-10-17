using System;
using System.Collections.Generic;

public class CharacterInfo 
{
    public readonly int startHealth;
    public readonly List<DiceInfo> diceInfos;

    private List<DicesAction> _actions = new List<DicesAction>();
    private List<Effect> _effects = new List<Effect>();
    private int _health;

    public event Action Die;
    public event Action<int> HealthChanged;

    public int Health
    { 
        get => _health;
        set
        {
            _health = value;
            HealthChanged?.Invoke(_health);
        }
    }

    public int Armor { get; set; }

    public List<DicesAction> Actions => _actions;

    public CharacterInfo (int _startHealth, List<DiceInfo> _diceInfos)
    {
        startHealth = _startHealth;
        Health = startHealth;
        diceInfos = _diceInfos;
        Round.RoundStarted += () => NextRound();

        LevelController.LevelCompleted += (res) => Clear();
    }

    public void UseEffect(EffectType effectType)
    {
        var effect = _effects.Find((effect) => effect.effectType == effectType);
        if (effect != null)
            effect.Use();
    }

    public void AddEffect(Effect effect)
    {
        var oldEffect = _effects.Find((_effect) => _effect.effectType == effect.effectType);
        if (oldEffect != null)
            oldEffect.ChangeEffectStraght(effect.Value);
        else
            _effects.Add(effect);
    }

    public void NextRound()
    {
        Armor = 0;
        _effects.RemoveAll((effect) => effect.Duration < 1);
    }

    public void ChangeHealth(int value)
    {
        var result = _health + value;
        if (result <= 0)
        {
            Health = 0;
            Die?.Invoke();
        }
        else if (result > startHealth)
            Health = startHealth;
        else
            Health = result;
    }

    private void Clear()
    {
        Die = null;
        _effects.Clear();
        HealthChanged = null;
    }
}
