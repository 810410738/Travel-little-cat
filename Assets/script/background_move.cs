using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class background_move : MonoBehaviour
{
    public float speed = 0.2f;
    public float move = 23.55f;
    private player_move player;
    private MainController main;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player").GetComponent<player_move>();
        main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果游戏失败，地面停止运动
        if (main.isGameOver==true)
        {
            this.enabled = false;
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
