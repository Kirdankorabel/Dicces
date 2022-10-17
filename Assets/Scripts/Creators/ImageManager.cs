using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private List<Texture2D> textures;
    [SerializeField] private List<Sprite> icons;

    public void InstantiateFaces(Dice dice)
    {
        Face[] faces = dice.Faces;
        DiceInfo diceInfo = dice.DiceInfo;
        for (var i = 0; i < faces.Length; i++)
        {
            var effect = diceInfo.effects[i];
            var texture = textures.Find((texture) => texture.name == effect.effectType.ToString());
            faces[i].SetTexture(texture).SetPower(effect.value, effect.value2);
        }
    }

    public Sprite GetIcon(int id)
        => icons[id % icons.Count];
}
