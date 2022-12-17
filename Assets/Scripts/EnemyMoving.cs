using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [Range(0, 100)]
    private float _speed;
    public float speed // ENCAPSULATION
    {
        get { return _speed; }
        set
        {
            if (speed < 0)
            {
                _speed = 0;
            }
            else if (speed >= 100)
            {
                _speed = 100;
            }
            else
            {
                _speed = value;
            }
        }
    }
    [Range(0, 10)]
    private float _limit = 10;
    public float limit // ENCAPSULATION
    {
        get { return _limit; }
        set
        {
            if (limit < 0)
            {
                _limit = 0;
            }
            else if (limit >= 30)
            {
                _limit = 30;
            }
            else
            {
                _limit = value;
            }
        }
    }



    private float _direction;
    private float _time;
    float _randX;
    float _randY;
    float _randZ;
    private Vector3 _dir;


    void Update()
    {
        _time += Time.deltaTime;
        Broad();
        Moving();
    }

    private void Moving()
    {
        speed = 50;
        _direction = 0.1f;
        if (transform.position.x >= 6)
        {
            _randX = Random.Range(-_direction, 0);
        }
        else if (transform.position.x <= 4)
        {
            _randX = Random.Range(0, _direction);
        }
        if (transform.position.y >= 6)
        {
            _randY = Random.Range(-_direction, 0);
        }
        else if (transform.position.y <= 4)
        {
            _randY = Random.Range(0, _direction);
        }
        if (transform.position.z >= 6)
        {
            _randZ = Random.Range(-_direction, 0);
        }
        else if (transform.position.z <= 4)
        {
            _randZ = Random.Range(0, _direction);
        }
        
        if (_time >= 0.5)
        {
            _dir = new Vector3(_randX, _randY, _randZ);
            _time = 0;
        }
        transform.Translate(_dir * _speed * Time.deltaTime);
    }
    private void Broad()
    {
        if (transform.position.x >= _limit)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (transform.position.y >= _limit)
        {
            transform.position += new Vector3(0, -1, 0);
        }
        if (transform.position.z >= _limit)
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

    
}
