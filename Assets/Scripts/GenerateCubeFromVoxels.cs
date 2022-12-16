using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class GenerateCubeFromVoxels : MonoBehaviour
{
    [SerializeField] private int _sizeX;
    [SerializeField] private int _sizeY;
    [SerializeField] private int _sizeZ;
    private VoxelsType[,,] _voxels;
    private Vector3[] _vertices;
    private List<int> _triangles = new List<int>();
    private Mesh _mesh;
    void Start()
    {
        _mesh = new Mesh();
        _mesh.name = "Cube";
        _vertices = new Vector3[(_sizeX + 1) * (_sizeY + 1) * (_sizeZ + 1)];
        _voxels = new VoxelsType [_sizeX, _sizeY, _sizeZ];
        GenerateVertices();
        _mesh.vertices = _vertices;
        GenerateVoxels();
        GenerateMesh();
    }

    private void GenerateMesh()
    {
        _triangles.Clear();
        GenerateSides();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles.ToArray();
        _mesh.Optimize();
        _mesh.RecalculateBounds();
        _mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = _mesh;
        GetComponent<MeshCollider>().sharedMesh = _mesh;
    }
    private void GenerateVertices()
    {
        int count = 0;
        for (int x = 0; x <= _sizeX; x++)
        {
            for (int y = 0; y <= _sizeY; y++)
            {
                for (int z = 0; z <= _sizeZ; z++)
                {
                    _vertices[count++] = new Vector3(x, y, z);
                }
            }
        }
    }

    private void GenerateSides()
    {
        for (int x = 0; x <= _sizeX; x++)
        {
            for (int y = 0; y <= _sizeY; y++)
            {
                for (int z = 0; z <= _sizeZ; z++)
                {
                    if (x < _sizeX && y < _sizeY && z < _sizeZ && _voxels[x, y, z] == VoxelsType.Voxel)
                    {
                        GenerateCube(x, y, z);
                    }
                }
            }
        }
    } 
    private void GenerateVoxels()
    {
        for (int x = 0; x <= _sizeX; x++)
        {
            for (int y = 0; y <= _sizeY; y++)
            {
                for (int z = 0; z <= _sizeZ; z++)
                {
                    if (x < _sizeX && y < _sizeY && z < _sizeZ)
                    {
                        _voxels[x, y, z] = VoxelsType.Voxel;
                    }
                }
            }
        }
    }

    private void GenerateCube(int x, int y, int z)
    {
        Vector3Int voxelPosition = new Vector3Int(x, y, z);
        int a = x * ((_sizeY + 1) * (_sizeZ + 1)) + y * (_sizeZ + 1) + z;
        int b = a + 1;
        int c = x * ((_sizeY + 1) * (_sizeZ + 1)) + (y + 1) * (_sizeZ + 1) + z;
        int d = c + 1;
        int e = (x + 1) * ((_sizeY + 1) * (_sizeZ + 1)) + y * (_sizeZ + 1) + z;
        int f = e + 1;
        int g = (x + 1) * ((_sizeY + 1) * (_sizeZ + 1)) + (y + 1) * (_sizeZ + 1) + z;
        int h = g + 1;

        if (GetVoxelPosition(voxelPosition + Vector3Int.forward) == VoxelsType.Nothing)
        {
            SetQuadFront(b, d, f, h);
        }
        if (GetVoxelPosition(voxelPosition + Vector3Int.back) == VoxelsType.Nothing)
        {
            SetQuadBack(a, c, e, g);
        }
        if (GetVoxelPosition(voxelPosition + Vector3Int.up) == VoxelsType.Nothing)
        {
            SetQuadTop(c, d, g, h);
        }
        if (GetVoxelPosition(voxelPosition + Vector3Int.down) == VoxelsType.Nothing)
        {
            SetQuadBottom(a, b, e, f);
        }
        if (GetVoxelPosition(voxelPosition + Vector3Int.left) == VoxelsType.Nothing)
        {
            SetQuadLeft(a, b, c, d);
        }
        if (GetVoxelPosition(voxelPosition + Vector3Int.right) == VoxelsType.Nothing)
        {
            SetQuadRight(e, f, g, h);
        }
    }

    private VoxelsType GetVoxelPosition(Vector3Int position)
    {
        if (position.x < _sizeX && position.y < _sizeY &&
            position.z < _sizeZ && position.x >= 0 && position.y >= 0 &&
            position.z >= 0)
        {
            return _voxels[position.x, position.y, position.z];
        }
        else
        {
            return VoxelsType.Nothing;
        }
    }

    private void SetQuadFront(int b, int d, int f, int h)
    {
        _triangles.Add(b);
        _triangles.Add(f);
        _triangles.Add(d);
        _triangles.Add(d);
        _triangles.Add(f);
        _triangles.Add(h);
    }
    private void SetQuadBack(int a, int c, int e, int g)
    {
        _triangles.Add(a);
        _triangles.Add(c);
        _triangles.Add(e);
        _triangles.Add(e);
        _triangles.Add(c);
        _triangles.Add(g);
    }
    private void SetQuadTop(int c, int d, int g, int h)
    {
        _triangles.Add(c);
        _triangles.Add(d);
        _triangles.Add(g);
        _triangles.Add(g);
        _triangles.Add(d);
        _triangles.Add(h);
    }
    private void SetQuadBottom(int a, int b, int e, int f)
    {
        _triangles.Add(a);
        _triangles.Add(e);
        _triangles.Add(b);
        _triangles.Add(b);
        _triangles.Add(e);
        _triangles.Add(f);
    }
    private void SetQuadLeft(int a, int b, int c, int d)
    {
        _triangles.Add(a);
        _triangles.Add(b);
        _triangles.Add(c);
        _triangles.Add(c);
        _triangles.Add(b);
        _triangles.Add(d);
    }
    private void SetQuadRight(int e, int f, int g, int h)
    {
        _triangles.Add(f);
        _triangles.Add(e);
        _triangles.Add(h);
        _triangles.Add(h);
        _triangles.Add(e);
        _triangles.Add(g);
    }

    public void DeleteVoxel(int x, int y, int z)
    {
        _voxels[x, y, z] = VoxelsType.Nothing;
        GenerateMesh();
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = player.transform.position.z;
            if (x < _sizeX && y < _sizeY &&
                z < _sizeZ && x >= 0 && y >= 0 &&
                z >= 0 && _voxels[(int)x, (int)y, (int)z] == VoxelsType.Voxel)
            {
                DeleteVoxel((int)x, (int)y, (int)z);
                TimeLess._timeDown += 0.2f;
            }
        }
    }
    //private void OnDrawGizmos()
    //{
    //    if (_vertices == null) return;
    //    if (_voxels == null) return;
    //    foreach (var vertice in _vertices)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawSphere(vertice, 0.1f);
    //    }
    //    for (int x = 0; x < _sizeX; x++)
    //    {
    //        for (int y = 0; y < _sizeY; y++)
    //        {
    //            for (int z = 0; z < _sizeZ; z++)
    //            {
    //                if (x < _sizeX && y < _sizeY && z < _sizeZ)
    //                {
    //                    Gizmos.color = Color.black;
    //                    Gizmos.DrawSphere(new Vector3(x, y, z), 0.15f);
    //                }
    //            }
    //        }
    //    }

    //}
}
