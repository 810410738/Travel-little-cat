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
        //创建新地形
        int x = Random.Range(0, grounds.Length);
        GameObject temp =  Instantiate(grounds[x], transform);
        temp.transform.localPosition = new Vector3(21.28f, 0.04f, 1);

        
    }
}
