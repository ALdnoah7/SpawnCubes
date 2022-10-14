using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CubeMove : MonoBehaviour
{
    private float _speed;
    private Vector3 _endPos;

    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, _endPos, Time.deltaTime * _speed);
        Destroy(gameObject, 15f);
    }

    public void SetSettings(float speed, Vector3 endPos)
    {
        _speed = speed;
        _endPos = endPos;
    }
}
