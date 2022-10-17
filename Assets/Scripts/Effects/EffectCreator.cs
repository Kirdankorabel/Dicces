public class EffectCreator
{
    public void CreateEffect(DicesAction dicesAction, CharacterInfo user, CharacterInfo target)
    {
        EffectType type = dicesAction.effectType;
        switch (dicesAction.effectType)
        {
            case EffectType.Defend:
                user.AddEffect(new Defend(1, dicesAction.value, user, EffectType.Defend));
                break;
            case EffectType.Damage:
                target.AddEffect(new Damage(1, dicesAction.value, target, EffectType.Damage));
                break;
            case EffectType.Health:
                user.AddEffect(new Health(1, dicesAction.value, user, EffectType.Health));
                break;
            case EffectType.Magic:
                target.AddEffect(new MagicDamage(1, dicesAction.value, target, EffectType.Magic));
                break;
            case EffectType.Posion:
                target.AddEffect(new Damage(1, dicesAction.value, target, EffectType.Damage));
                target.AddEffect(new Posion(10, dicesAction.value2, target, EffectType.Posion));
                break;
            case EffectType.SwordAndShield:
                user.AddEffect(new Defend(1, dicesAction.value, user, EffectType.Defend));
                target.AddEffect(new Damage(1, dicesAction.value2, target, EffectType.Damage));
                break;
        }
    }
}
