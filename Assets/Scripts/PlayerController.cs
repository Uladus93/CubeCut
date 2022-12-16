using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int _limit = 9;
    [SerializeField] private int _speed;
    [SerializeField] private float _timeLimit;
    float _time;
    [SerializeField] private GameObject _enemy;
    private float _rndX;
    private float _rndY;
    private float _rndZ;
    void Start()
    {
        transform.position = new Vector3(0, 0, 10); 
    }

    void Update()
    {
        _time += Time.deltaTime;
        Moving();
        Broad();
    }

    private void Moving()
    {
        if (transform.position.x >= -_limit && transform.position.y >= -_limit && transform.position.z >= -_limit)
        {

            if (Input.GetKey(KeyCode.O) && _time >= _timeLimit)
            {
                transform.position += new Vector3(0, 0, 1);
                _time = 0;
            }

            if (Input.GetKey(KeyCode.Alpha7) && _time >= _timeLimit)
            {
                transform.position += new Vector3(1, 0, 0);
                _time = 0;
            }

            if (Input.GetKey(KeyCode.Z) && _time >= _timeLimit)
            {
                transform.position += new Vector3(0, -1, 0);
                _time = 0;
            }
        }
        if (transform.position.x <= _limit && transform.position.y <= _limit && transform.position.z <= _limit)
        {
            if (Input.GetKey(KeyCode.Alpha8) && _time >= _timeLimit)
            {
                transform.position += new Vector3(-1, 0, 0);
                _time = 0;
            }
            if (Input.GetKey(KeyCode.P) && _time >= _timeLimit)
            {
                transform.position += new Vector3(0, 0, -1);
                _time = 0;
            }
            if (Input.GetKey(KeyCode.A) && _time >= _timeLimit)
            {
                transform.position += new Vector3(0, 1, 0);
                _time = 0;
            }
        }
    }
    private void Broad()
    {
        if (transform.position.x > _limit)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (transform.position.y > _limit)
        {
            transform.position += new Vector3(0, -1, 0);
        }
        if (transform.position.z > _limit)
        {
            transform.position += new Vector3(0, 0, -1);
        }
        if (transform.position.x < 0)
        {
            transform.position += new Vector3(1, 0, 0);
        }
        if (transform.position.y < 0)
        {
            transform.position += new Vector3(0, 1, 0);
        }
        if (transform.position.z < 0)
        {
            transform.position += new Vector3(0, 0, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Score._point++;
            TimeLess._timeDown++;
            _rndX = transform.position.x < 5 ? 10 : 0;
            _rndY = transform.position.y < 5 ? 10 : 0;
            _rndZ = transform.position.z < 5 ? 10 : 0;
            Instantiate(_enemy, new Vector3(_rndX, _rndY, _rndZ), Quaternion.identity);
        }
    }
}
