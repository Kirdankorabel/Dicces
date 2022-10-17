using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Face[] _faces;

    private DiceInfo _diceInfo; 
    private Vector3 _startPosition;
    private Vector3 _lastPos;
    private Rigidbody _rigidbody;

    public static event System.Action<DiceInfo> DiceOpened;

    public Face[] Faces => _faces;
    public DiceInfo DiceInfo
    {
        get => _diceInfo;
        set
        {
            if (_diceInfo == null)
                _diceInfo = value;
        }
    }

    void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        DiceOpened?.Invoke(_diceInfo);
        GameController.Scan.Show(this);
    }

    public void Roll()
    {
        var direction = new Vector3(Random.Range(-2f, 2f), Random.Range(2f, 5f), Random.Range(-2f, 2f));
        _rigidbody.AddForce(direction * 200);
        StartCoroutine(GetTopFaceCorutine());
    }

    public Dice SetStartPosition(Vector3 position)
    {
        _startPosition = position;
        return this;
    }

    private void ToStart()
        => StartCoroutine(MoveToStartCorutine());

    private int GetTopFace()
    {
        var posY = 0f;
        var result = 0;
        for (int i = 0; i < 6; i++)
        {
            if (_faces[i].transform.position.y > posY)
            {
                posY = _faces[i].transform.position.y;
                result = i;
            }
        }
        return result;
    }


    private IEnumerator GetTopFaceCorutine()
    {
        while (_lastPos != transform.position)
        {
            _lastPos = transform.position;
            yield return new WaitForSeconds(0.2f);
        }
        ToStart();
        yield break;
    }

    private IEnumerator MoveToStartCorutine()
    {
        var time = Time.time;
        var rotX = Mathf.Round(transform.rotation.eulerAngles.x / 90f) * 90f;
        var rotY = Mathf.Round(transform.rotation.eulerAngles.y / 90f) * 90f;
        var rotZ = Mathf.Round(transform.rotation.eulerAngles.z / 90f) * 90f;
        var targetRotation = Quaternion.Euler(rotX, rotY, rotZ);
        while (transform.rotation != targetRotation || transform.position != _startPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, 10f * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 50f * Time.deltaTime);

            if (Time.time - time > 3)
            {
                _diceInfo.ShowResult(GetTopFace());
                yield break;
            }
            yield return null;
        }
        _diceInfo.ShowResult(GetTopFace());
        yield break;
    }
}
