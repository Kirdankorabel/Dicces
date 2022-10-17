using System.Collections.Generic;
using UnityEngine;

public class DiceCreator : MonoBehaviour
{
    [SerializeField] private Dice _dicePrefab;
    [SerializeField] private ImageManager faceInstantiator;

    public Dice[] CreateDices(List<DiceInfo> diceInfos, List<Vector3> positions)
    {
        var dices = new Dice[diceInfos.Count];
        for(var i = 0; i < diceInfos.Count; i++)
            dices[i] = CreateDice(diceInfos[i], positions[i]);
        return dices;
    }

    public Dice CreateDice(DiceInfo diceInfo, Vector3 position)
    {
        var dice = Instantiate(_dicePrefab, position, Quaternion.identity, this.transform);
        dice.SetStartPosition(position).
            DiceInfo = diceInfo;
        faceInstantiator.InstantiateFaces(dice);
        return dice;
    }

    public Sprite GetIcon(int id)
        => faceInstantiator.GetIcon(id);
}
