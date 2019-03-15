using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardControl : MonoBehaviour
{
    private MainController Main;
    public int reward = 10;//分数
    public float add_time = 5;//加时
    public new_ground ground;
    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
        ground = GameObject.Find("Ground").GetComponent<new_ground>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
       {
            Main.Goal(reward);//加分或减分
            if (transform.tag == "reward")//吃到普通道具
            {
                AudioManager.Instance.PlaySound("eat");//播放声效
            }
            else if(transform.tag == "reward_add_time")//吃到加时道具
            {
                Main.AddTime(add_time);
                AudioManager.Instance.PlaySound("eat");
            }
            else if(transform.tag == "super_reward")//超级奖励
            {
                ground.flag = 1;
                AudioManager.Instance.PlaySound("eat");
            }
            else if(transform.tag == "punish")//惩罚模式
            {
                ground.flag = 2;
                AudioManager.Instance.PlaySound("eat");
            }
            Destroy(gameObject);//删除自己        
        }
    }
}
