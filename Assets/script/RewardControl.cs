﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardControl : MonoBehaviour
{
    private MainController Main;
    public int reward = 10;//分数
    public float add_time = 5;//加时
    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
       {
            if (transform.tag == "reward")//吃到普通道具
            {
                Main.Goal(reward);//加分或减分
                AudioManager.Instance.PlaySound("eat");//播放声效
                Destroy(gameObject);//删除自己
            }
            else if(transform.tag == "reward_add_time")//吃到加时道具
            {

                Main.AddTime(add_time);
                Main.Goal(reward);
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);//删除自己
            }
            
       }
    }
}
