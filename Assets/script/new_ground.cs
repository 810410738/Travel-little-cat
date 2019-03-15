using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_ground : MonoBehaviour
{
    public GameObject[] grounds;
    public int flag = 0;//flag为标志位，0代表随机，1代表奖励地形，2代表惩罚地形,默认为随机
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
        if (this.flag == 0)//随机生成
        {
            int x = Random.Range(0, x_random.Length-2);
            Instantiate(grounds[x_random[x]], transform).transform.localPosition = new Vector3(21.28f, 0.04f, 1);
        }
        else if (this.flag == 1)//奖励地形
        {
            //grouns数组倒数第二个为奖励地形
            Instantiate(grounds[x_random[x_random.Length-2]], transform).transform.localPosition = new Vector3(21.28f, 0.04f, 1);
            flag = 0;//恢复为随机生成
        }
        else if (this.flag == 2)//惩罚地形
        {
            //grouns数组倒数第一个为奖励地形
            Instantiate(grounds[x_random[x_random.Length - 1]], transform).transform.localPosition = new Vector3(21.28f, 0.04f, 1);
            flag = 0;//恢复为随机生成
        }
    }
}
