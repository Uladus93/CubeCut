using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class GeneratePlayer : MonoBehaviour
{
    private Vector3[] _vertices;
    private Mesh _mesh;
    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        _mesh.name = "Player";
        SetVertices();
        SetTriangles();
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = _mesh;
    }

    private void SetVertices()
    {
        _vertices = new Vector3[8];
        _vertices[0] = new Vector3(0, 0, 0);
        _vertices[1] = new Vector3(0, 0, 1);
        _vertices[2] = new Vector3(0, 1, 0);
        _vertices[3] = new Vector3(0, 1, 1);
        _vertices[4] = new Vector3(1, 0, 0);
        _vertices[5] = new Vector3(1, 0, 1);
        _vertices[6] = new Vector3(1, 1, 0);
        _vertices[7] = new Vector3(1, 1, 1);
        _mesh.vertices = _vertices;
    }

    private void SetTriangles()
    {
        var trianglesFront = new int[6] { 1, 5, 3, 3, 5, 7 };
        var trianglesBack = new int[6] { 0, 2, 4, 4, 2, 6 };
        var trianglesLeft = new int[6] { 0, 1, 2, 2, 1, 3 };
        var trianglesRight = new int[6] { 5, 4, 7, 7, 4, 6 };
        var trianglesBottom = new int[6] { 0, 4, 1, 1, 4, 5 };
        var trianglesTop = new int[6] { 2, 3, 6, 6, 3, 7 };

        _mesh.subMeshCount = 6;
        _mesh.SetTriangles(trianglesFront, 0);
        _mesh.SetTriangles(trianglesBack, 1);
        _mesh.SetTriangles(trianglesLeft, 2);
        _mesh.SetTriangles(trianglesRight, 3);
        _mesh.SetTriangles(trianglesBottom, 4);
        _mesh.SetTriangles(trianglesTop, 5);
    }

    //private void OnDrawGizmos()
    //{
    //    if (_vertices == null)
    //    {
    //        return;
    //    }
    //    foreach (var vertice in _vertices)
    //    {
    //        Gizmos.color = Color.white;
    //        Gizmos.DrawSphere(vertice, 0.1f);
    //    }
    //}
}
