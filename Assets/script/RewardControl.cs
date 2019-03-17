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
    private float speedup = 20f;
    private bool isSpeed = false;
    private float m_time = 0;
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
        if (isSpeed)
        {
            Time.timeScale = 2.5f;//加速
            m_time += Time.deltaTime;
            if (m_time > 2.5f)
            {
                Time.timeScale = 1;//恢复原来的速度
                Destroy(gameObject);//删除自己  
            }  
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
       {
            Main.Goal(reward);//加分或减分
            if (transform.tag == "reward")//吃到普通道具
            {
                AudioManager.Instance.PlaySound("reward");//播放声效
                Destroy(gameObject);//删除自己   
            }
            else if(transform.tag == "reward_punish")//吃到扣分道具
            {
                AudioManager.Instance.PlaySound("reward");//播放声效
                Destroy(gameObject);//删除自己   
            }
            else if(transform.tag == "reward_add_time")//吃到加时道具
            {
                Main.AddTime(add_time);
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);//删除自己   
            }
            else if (transform.tag == "reward_speedup")//吃到加速道具
            {
                Debug.LogWarning("speedup");
                AudioManager.Instance.PlaySound("speedup");
                isSpeed = true;
                this.transform.localScale = Vector3.zero;
            }
            else if(transform.tag == "super_reward")//超级奖励
            {
                ground.flag = 1;
                AudioManager.Instance.PlaySound("super_reward");
                Destroy(gameObject);//删除自己   
            }
            else if(transform.tag == "punish")//惩罚模式
            {
                ground.flag = 2;
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);//删除自己   
            }
        }
    }
   
}
