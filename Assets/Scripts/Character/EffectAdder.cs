using UnityEngine;

public class EffectAdder : MonoBehaviour
{
    [SerializeField] private EffectUI shield;
    [SerializeField] private EffectUI damage;

    public void UseEffect(DicesAction effect)
    {
        EffectType type = effect.effectType;
        switch (type)
        {
            case EffectType.Defend:
                shield.AddValue(effect.value);
                break;
            case EffectType.Damage:
                damage.AddValue(effect.value);
                break;
            case EffectType.Posion:
                damage.AddValue(effect.value);
                break;
            case EffectType.SwordAndShield:
                shield.AddValue(effect.value2);
                damage.AddValue(effect.value);
                break;
            default:
                break;
        }
    }
}
