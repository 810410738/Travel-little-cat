using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_ground : MonoBehaviour
{
    public GameObject[] grounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGround()
    {
        //按照一定概率创建新地形
        int[] x_random = new int[]{//用一个数组来模拟概率
          0,0,1,2,3,4  
        };
                  
        int x = Random.Range(0, x_random.Length);
        GameObject temp = Instantiate(grounds[ x_random[x] ], transform);
        temp.transform.localPosition = new Vector3(21.28f, 0.04f, 1);

        
    }
}
