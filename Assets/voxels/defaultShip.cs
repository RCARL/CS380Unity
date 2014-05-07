using System.Collections;
using UnityEngine;
using Noise;
using System.Collections.Generic;

public class defaultShip : MonoBehaviour
{

    public int X = 5;
    public int Y = 5;
    public int Z = 5;
    int cSize = 5;
    public float thresh = 0.2f;
    NoiseGen NoiseGenerator;
    public byte flavor = 0x01;

    private System.Random rand = new System.Random();

    Container s;
    void Awake()
    {
        //4 x 12x12
        byte f =flavor;
        byte[,,] map={{
                      {0,0,0,0,0,0,0,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,0,0,0,0,0,0,0,0},
                      {0,0,0,0,0,0,0,0,0,0,0,0,0},
                      {0,0,0,0,0,0,0,0,0,0,0,0,0},
                      {0,0,0,0,0,0,0,0,0,0,0,0,0}},
                      {
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,0,0,f,0,0,0,0,0}},
                      {
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,f,f,f,f,f,f,f,f,f,f,0,0},
                      {f,f,f,f,f,f,f,f,f,f,f,f,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,0,0,0,0,0,0,0,0,0}},
                      {
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,0,f,f,0,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,f,f,f,0,0,0,0,0},
                      {0,0,0,0,f,0,0,f,0,0,0,0,0}}

                     
                     };




        s = gameObject.AddComponent<Container>();
        s.rigidbody.useGravity = false;
        for (int x = 0; x < map.GetLength(0); x++)
            for (int y = 0; y < map.GetLength(1); y++)
                for (int z = 0; z < map.GetLength(2); z++)
                    s.createChunk(x, y, z, map[ x, y,z]);
    
        //asteroidGroup.checkIntegrity();
    }


}
