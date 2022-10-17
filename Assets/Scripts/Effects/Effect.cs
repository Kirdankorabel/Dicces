public abstract class Effect
{
    public readonly EffectType effectType;
    public int _duration;
    protected int _value;
    protected CharacterInfo _target;

    public int Value => _value;
    public int Duration => _duration;

    public Effect(int duration, int value, CharacterInfo target, EffectType _effectType)
    {
        _duration = duration;
        _value = value;
        _target = target;
        effectType = _effectType;
    }

    public virtual void ChangeEffectStraght(int value)
        => _value += value;

    public abstract void Use();
}
