using System.Collections.Generic;
using UnityEngine;

public class EnemysInfos
{

    private static List<CharacterInfo> enemys = new List<CharacterInfo>()
    {
        new CharacterInfo(7, new List<DiceInfo>()
        {
            new DiceInfo(new DicesAction[]
            {
                new DicesAction(EffectType.Damage, 4),
                new DicesAction(EffectType.Damage, 4),
                new DicesAction(EffectType.Damage, 3),
                new DicesAction(EffectType.Damage, 3),
                new DicesAction(EffectType.Damage, 1),
                new DicesAction(EffectType.Damage, 1),
            }),
        }),
        new CharacterInfo(10, new List<DiceInfo>()
        {
            new DiceInfo(new DicesAction[]
            {
                new DicesAction(EffectType.Damage, 3),
                new DicesAction(EffectType.Damage, 3),
                new DicesAction(EffectType.Damage, 2),
                new DicesAction(EffectType.Damage, 2),
                new DicesAction(EffectType.Damage, 2),
                new DicesAction(EffectType.Damage, 2),
            }),

        }),
        new CharacterInfo(15, new List<DiceInfo>()
        {
            new DiceInfo(new DicesAction[]
            {
                new DicesAction(EffectType.Damage, 5),
                new DicesAction(EffectType.Posion, 2, 1),
                new DicesAction(EffectType.Posion, 2, 1),
                new DicesAction(EffectType.Damage, 1),
                new DicesAction(EffectType.Health, 2),
                new DicesAction(EffectType.Health, 2),
            }),

        }),
    };

    public static CharacterInfo GetEnemy(int level)
    {
        if (level < enemys.Count)
            return new CharacterInfo(enemys[level].Health, enemys[level].diceInfos);
        else
            return enemys[Random.Range(0, enemys.Count)];
    }
}
