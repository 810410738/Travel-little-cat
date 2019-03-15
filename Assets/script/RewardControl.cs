using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardControl : MonoBehaviour
{
    private MainController Main;
    public int reward = 10;//分数
    public float add_time = 5;//加时
    private new_ground ground;
    private ground_move g_move;
    private float speedup = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
        ground = GameObject.Find("Ground").GetComponent<new_ground>();
        g_move = GameObject.FindWithTag("ground_move").GetComponent<ground_move>();
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
            else if (transform.tag == "reward_speedup")//吃到加速道具
            {
                Debug.LogWarning("speedup");
                float temp = g_move.speed;
                g_move.speed+=speedup;
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);//删除自己   
                for (float m_time = 0; m_time < 1; m_time += Time.deltaTime) ;//加速持续一段时间
                g_move.speed = temp;
                return;
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
