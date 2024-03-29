using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sponeobject : MonoBehaviour
{
    public GameObject PrefabCube;

    private float x=-8.0f;
    private float y = 1.0f;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

        for(i=0;i<3;i++)
        {
            Vector2 v = new Vector2(x, y);
            Instantiate(PrefabCube, v, Quaternion.identity);
            x += 4.5f;
            
        }
        x = -6.0f;
        y = -2.0f;
        i = 0;
        for (i = 0; i < 2; i++)
        {
            Vector2 v = new Vector2(x, y);
            Instantiate(PrefabCube, v, Quaternion.identity);
            x += 4.5f;

        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
