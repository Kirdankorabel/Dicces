public class Posion : Effect
{
    public readonly int MaxValue = 2;
    public Posion(int duration, int value, CharacterInfo target, EffectType effectType) : base(duration, value, target, effectType)
    {
        _duration = duration;
        _value = value;
        _target = target;
    }

    public override void Use()
    {
        _target.ChangeHealth(-_value);
        _duration--;
    }

    public override void ChangeEffectStraght(int value)
    {
        if (_value + value < MaxValue)
            _value += value;
    }
}
