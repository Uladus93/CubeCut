using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float _speed;
    [Range(0, 10)]
    [SerializeField] private float _limit;
    
    private float _direction;
    private float time;
    float randX;
    float randY;
    float randZ;
    private Vector3 _dir;


    void Update()
    {
        time += Time.deltaTime;
        Broad();
        Moving();
    }

    private void Moving()
    {
        _direction = 0.1f;
        if (transform.position.x >= 6)
        {
            randX = Random.Range(-_direction, 0);
        }
        else if (transform.position.x <= 4)
        {
            randX = Random.Range(0, _direction);
        }
        if (transform.position.y >= 6)
        {
            randY = Random.Range(-_direction, 0);
        }
        else if (transform.position.y <= 4)
        {
            randY = Random.Range(0, _direction);
        }
        if (transform.position.z >= 6)
        {
            randZ = Random.Range(-_direction, 0);
        }
        else if (transform.position.z <= 4)
        {
            randZ = Random.Range(0, _direction);
        }
        
        if (time >= 0.5)
        {
            _dir = new Vector3(randX, randY, randZ);
            time = 0;
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
