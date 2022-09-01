using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoints : MonoBehaviour
{
    [SerializeField] private GameObject sphere;

    void Start()
    {


        for (float x = -13.5f; x < 16.5;)
        {
            for (float y = 0.5f; y < 30.5;)
            {
                for (float z = -13.5f; z < 16.5;)
                {
                    Instantiate(sphere, new Vector3(x, y, z), Quaternion.identity);
                    z += 3;
                }

                y += 3;
            }

            x += 3;
        }
    }

}
