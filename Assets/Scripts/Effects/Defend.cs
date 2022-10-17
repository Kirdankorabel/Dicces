public class Defend : Effect
{
    public Defend(int duration, int value, CharacterInfo target, EffectType effectType) : base(duration, value, target, effectType)
    {
        _duration = duration;
        _value = value;
        _target = target;
    }

    public override void Use()
    {
        _target.Armor += _value;
        _duration--;
    }
}
