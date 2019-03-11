using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float jump_force = 50;
    public int HP = 1;
    public int speed_up = 1000;
    private Animator anim;
    private Rigidbody2D rigi;
    private int jump_count = 2;//可以二段跳
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右移动
        float h = Input.GetAxis("Horizontal");
        
       
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        /*
        if (h > 0.05f)
        {
            velocity.x += move_v;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else if (h < -0.05f)
        {
            velocity.x -= move_v;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        */
        //修改朝向
        if (h > 0.05f)
        {
            transform.localScale = new Vector3(0.1415232f, 0.1381166f, 1);
        }
        else if (h < -0.05f)
        {
            transform.localScale = new Vector3(-0.1415232f, 0.1381166f, 1);
        }

        //跳跃
        if (Input.GetKeyDown(KeyCode.Space) && jump_count > 0)
        {
           GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_force);
            velocity.x += 0.1f;
            GetComponent<Rigidbody2D>().velocity = velocity;
            jump_count--;
            //播放音效
            AudioManager.Instance.PlaySound("eat");
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //碰到地面
        if (col.collider.tag == "ground")
        {
            jump_count = 2;
        }
        else if (col.collider.tag == "barrier")
        {
            jump_count = 1;
        }
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        //离开地面
        if (col.collider.tag == "ground")
        {
            
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        //碰到敌人就会死
        if (col.tag == "enemy"&& HP>0)
        {
            HP--;
            if (HP <= 0)
            {
                anim.SetBool("isDie", true);
                Destroy(rigi);
            }
        }
        else if (col.tag == "reward_speedup" && HP > 0)
        {
            //GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed_up);

        }
    }
}
