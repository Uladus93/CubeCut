using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingOfCube : MonoBehaviour
{
    [SerializeField] GameObject _cube;
    [SerializeField] GameObject _axes;
    [SerializeField] float _speed;
    [SerializeField] float _mouseX;
    [SerializeField] float _mouseY;
    Quaternion orginRotation;

    // Start is called before the first frame update
    void Start()
    {
        orginRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _cube.transform.RotateAround(_axes.transform.position, Vector3.left, _speed * Time.deltaTime );
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _cube.transform.RotateAround(_axes.transform.position, Vector3.right, _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _cube.transform.RotateAround(_axes.transform.position, Vector3.down, _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _cube.transform.RotateAround(_axes.transform.position, Vector3.up, _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _cube.transform.RotateAround(_axes.transform.position, Vector3.forward, _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            _cube.transform.RotateAround(_axes.transform.position, Vector3.back, _speed * Time.deltaTime);
        }
    }
}
