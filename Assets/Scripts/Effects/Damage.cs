public class Damage : Effect
{
    public Damage(int duration, int value, CharacterInfo target, EffectType effectType) : base(duration, value, target, effectType)
    {
        _duration = duration;
        _value = value;
        _target = target;
    }

    public override void Use()
    {
        var damage = _target.Armor - Value;
        if(damage < 0)
            _target.ChangeHealth(damage);
        _duration--;
    }
}
