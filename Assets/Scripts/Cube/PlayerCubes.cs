using System.Collections.Generic;

public static class PlayerCubes
{
    public static readonly List<DiceInfo> dices = new List<DiceInfo>
        {
        new DiceInfo(new DicesAction[]
        {
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.Damage, 1),
            new DicesAction(EffectType.Damage, 1),
            new DicesAction(EffectType.Defend, 1),
            new DicesAction(EffectType.Defend, 1),

        }),
        new DiceInfo(new DicesAction[]
        {
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.Posion, 1,1),
            new DicesAction(EffectType.Defend, 1),
            new DicesAction(EffectType.Defend, 1),
            new DicesAction(EffectType.SwordAndShield, 1,1),

        }),
        new DiceInfo(new DicesAction[]
        {
            new DicesAction(EffectType.Defend, 2),
            new DicesAction(EffectType.Defend, 2),
            new DicesAction(EffectType.Defend, 1),
            new DicesAction(EffectType.Defend, 1),
            new DicesAction(EffectType.Damage, 1),
            new DicesAction(EffectType.Damage, 1),

        }),
        new DiceInfo(new DicesAction[]
        {
            new DicesAction(EffectType.Health, 3),
            new DicesAction(EffectType.Health, 3),
            new DicesAction(EffectType.Health, 2),
            new DicesAction(EffectType.Health, 2),
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.SwordAndShield, 1,1),

        }),
        new DiceInfo(new DicesAction[]
        {
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.Damage, 2),
            new DicesAction(EffectType.Defend, 2),
            new DicesAction(EffectType.Defend, 2),
            new DicesAction(EffectType.Health, 3),
            new DicesAction(EffectType.Posion, 1,1),

        }),
    };
}
