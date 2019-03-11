using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_move : MonoBehaviour
{
    public float speed = 0.2f;
    public float move = 23.55f;
    private player_move player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").GetComponent<player_move>();
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
            v.x += move * 2;
        }
        transform.localPosition = v;
    }

}
