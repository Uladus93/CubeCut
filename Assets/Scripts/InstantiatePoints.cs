using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoints : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

    void Start()
    {


        for (int x = -15; x < 15;)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int z = -15; z < 15; z++)
                {
                    Instantiate(sphere, new Vector3(x, y, z), Quaternion.identity);
                    z += 2;
                }

                y += 2;
            }

            x += 2;
        }
    }

}
