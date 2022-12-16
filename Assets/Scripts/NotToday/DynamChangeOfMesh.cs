using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamChangeOfMesh : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _cube;
    private float _posX, _posY, _posZ;
    private Vector3[] _verticesOfPlayer = new Vector3[8];
    private Vector3[] _verticesOfMesh;
    private int[] _trianglesOfMesh;
    private Vector3[] _verticesMeshOfCube;
    private Mesh _mesh;
    private byte _countOfTwins;
    private byte[] _twins = new byte[8];
    private int[] _twinsFromCube = new int[8];

    void Start()
    {

    }

    void FixedUpdate()
    {
        _posX = _player.transform.position.x;
        _posY = _player.transform.position.y;
        _posZ = _player.transform.position.z;
    }

    private void VercitesOfPlayer()
    {
        _verticesOfPlayer[0] = new Vector3(_posX - 0.5f, _posY - 0.5f, _posZ - 0.5f);
        _verticesOfPlayer[1] = new Vector3(_posX - 0.5f, _posY - 0.5f, _posZ + 0.5f);
        _verticesOfPlayer[2] = new Vector3(_posX + 0.5f, _posY - 0.5f, _posZ - 0.5f);
        _verticesOfPlayer[3] = new Vector3(_posX + 0.5f, _posY - 0.5f, _posZ + 0.5f);
        _verticesOfPlayer[4] = new Vector3(_posX - 0.5f, _posY + 0.5f, _posZ - 0.5f);
        _verticesOfPlayer[5] = new Vector3(_posX - 0.5f, _posY + 0.5f, _posZ + 0.5f);
        _verticesOfPlayer[6] = new Vector3(_posX + 0.5f, _posY + 0.5f, _posZ - 0.5f);
        _verticesOfPlayer[7] = new Vector3(_posX + 0.5f, _posY + 0.5f, _posZ + 0.5f);
    }

    private void CountOfTwins()
    {
        _countOfTwins = 0;
        _verticesMeshOfCube = new Vector3[_cube.GetComponent<MeshFilter>().mesh.vertices.Length];
        _verticesMeshOfCube = _cube.GetComponent<MeshFilter>().mesh.vertices;
        for (int i = 0; i < _verticesOfPlayer.Length; i++)
        {
            _twins[i] = 0;
            _twinsFromCube[i] = -1;
            for (int j = 0; j < _verticesMeshOfCube.Length; j++)
            {
                if (_verticesOfPlayer[i] == _verticesMeshOfCube[j])
                {
                    _countOfTwins++;
                    _twins[i] = 1;
                    _twinsFromCube[i] = j;
                    break;
                }
            }
        }
    }

    private void ChangeVerticesAndTriangles()
    {
        _trianglesOfMesh = _cube.GetComponent<MeshFilter>().mesh.triangles;
        if (_countOfTwins == 7)
        {
            _verticesOfMesh = new Vector3[_verticesMeshOfCube.Length];
            _verticesOfMesh = _verticesMeshOfCube;
            for (int i = 0; i < _twins.Length; i++)
            {
                if (_twins[i] == 0)
                {
                    if (i >= 4)
                    {                        
                        _verticesOfMesh[_twinsFromCube[i - 4]] = _verticesOfPlayer[i];
                        break;
                    }
                }
            }  
        }
    }

    private void OnTriggerStay(Collider other)
    {
       VercitesOfPlayer();
       CountOfTwins();
        ChangeVerticesAndTriangles();
       
    }
}
