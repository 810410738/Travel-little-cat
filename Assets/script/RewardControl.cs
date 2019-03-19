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
	private reward_title_control reward_title;
	private punish_title_control punish_title;
    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
        ground = GameObject.Find("Ground").GetComponent<new_ground>();
        g_move = GameObject.FindWithTag("ground_move").GetComponent<ground_move>();
		reward_title = GameObject.Find("reward_title").GetComponent<reward_title_control>();
		punish_title = GameObject.Find("punish_title").GetComponent<punish_title_control>();
    }

    // Update is called once per frame
    void Update()
    {
		Debug.LogWarning("isspeed:  " + isSpeed);
		if (isSpeed)
        {
            Time.timeScale = 2.5f;//加速
            m_time += Time.deltaTime;
			Debug.LogWarning("time is " + m_time);
            if (m_time > 1f)
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
            else if(transform.tag == "super_reward")//超级奖励，加速
            {
				//显示奖励模式UI
				reward_title.show();
                ground.flag = 1;
                AudioManager.Instance.PlaySound("super_reward");
				isSpeed = true;
				Debug.LogWarning("isspeed:  " + isSpeed);
				this.transform.localScale = Vector3.zero;
			}
            else if(transform.tag == "punish")//惩罚模式
            {
				//显示惩罚模式UI
				punish_title.show();
                ground.flag = 2;
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);//删除自己   
            }
        }
    }
   
}
