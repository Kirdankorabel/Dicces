using UnityEngine;
using UnityEngine.UI;

public class Face : MonoBehaviour
{
    [SerializeField] private Text _powerText;

    private MaterialPropertyBlock _propertyBlock;
    private Texture2D _texture;

    public Texture2D GetTexture
        => _texture;

    public Face SetTexture(Texture2D texture)
    {
        _propertyBlock = new MaterialPropertyBlock();
        gameObject.GetComponent<MeshRenderer>().SetPropertyBlock(_propertyBlock);
        gameObject.GetComponent<MeshRenderer>().material.mainTexture = texture;
        _texture = texture;

        return this;
    }

    public Face SetPower(int value, int value2)
    {
        if (value2 != 0)
            _powerText.text = $"{value}/{value2}";
        else
            _powerText.text = value.ToString();
        return this;
    }
}
