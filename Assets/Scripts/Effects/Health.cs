public class Health : Effect
{
    public Health(int duration, int value, CharacterInfo target, EffectType effectType) : base(duration, value, target, effectType)
    {
        _duration = duration;
        _value = value;
        _target = target;
    }

    public override void Use()
    {
        _target.ChangeHealth(_value);
        _duration--;
    }
}
