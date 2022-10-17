public enum EffectType
{
    Defend,
    SwordAndShield,
    Damage,
    Posion,
    Magic,
    Health,
}

public class DicesAction
{
    public readonly EffectType effectType;
    public readonly int value;
    public readonly int value2;

    public DicesAction(EffectType _effect, int _value)
    {
        effectType = _effect;
        value = _value;
    }

    public DicesAction(EffectType _effect, int _value, int _value2)
    {
        effectType = _effect;
        value = _value;
        value2 = _value2;
    }
}
