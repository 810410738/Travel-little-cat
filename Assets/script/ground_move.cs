using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_move : MonoBehaviour
{
    public float speed = 4f;
    public float move = 21.32f;
    private GameObject ground;
    private MainController main;
    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.FindWithTag("Ground");
        main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果角色死亡，地面停止运动
        if (main.isGameOver==true)
        {
            this.enabled = false;
        }
        Vector2 v = transform.localPosition;
        v.x -= speed * Time.deltaTime;
        if (v.x < -move)
        {
            ground.GetComponent<new_ground>().NewGround();
            // v.x += move * 2;
            //切换地形
            //删除旧地形
            Destroy(gameObject);
        }
        transform.localPosition = v;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public float GetSpeed()
    {
        return this.speed;
    }
    public void SpeedUp(float speedup)
    {
        for (float m_time = 0; m_time < 1; m_time += Time.deltaTime) //加速持续一段时间
        {
            Debug.LogWarning("m_time is:" + m_time);
        }
    }
}
