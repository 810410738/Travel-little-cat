using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_move : MonoBehaviour
{
    public float speed = 4f;
    public float move = 18.1f;
    private player_move player;
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").GetComponent<player_move>();
        ground = GameObject.FindWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        //如果角色死亡，地面停止运动
        if (player.HP <= 0)
        {
            return;
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
}
