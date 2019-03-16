using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_control : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 15;
    public bool isDone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //小猫从左飞到右
        Vector3 v = transform.position;
        v.x += speed * Time.deltaTime;
        if (v.x <=0)
        {   
            transform.position = v;
        }
        else
        {
            isDone = true;
        }
    }
}
