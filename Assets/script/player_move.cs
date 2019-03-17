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
    private int jump_count = 1;//最大跳跃次数
    private bool isAddTime = false;
    private float m_time = 0;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rigi = this.GetComponent<Rigidbody2D>();
        //设置所有子物体都隐藏，即隐藏分数显示
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);//color里面的取值范围为0-1，对应实际RGB的0-255
            Debug.LogWarning(transform.GetChild(i).gameObject.name);
        }
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
        /*
        if (h > 0.05f)
        {
            transform.localScale = new Vector3(0.1415232f, 0.1381166f, 1);
        }
        else if (h < -0.05f)
        {
            transform.localScale = new Vector3(-0.1415232f, 0.1381166f, 1);
        }
        */
        //跳跃
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0) ) && jump_count > 0 )
        {
           
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_force);
            jump_count--;
            //播放音效
            //AudioManager.Instance.PlaySound("eat");
        }
        //判断是否死亡
        if (HP <= 0)
        {
            anim.SetBool("isDie", true);
            Destroy(rigi);
            this.enabled = false;
        }
        if (isAddTime)
        {
            //有三个子物体，0是最下面的
            m_time += Time.deltaTime;
            if (m_time > 0f && m_time < 0.3f)
            {
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (50 / 255f));//color里面的取值范围为0-1，对应实际RGB的0-255}
            }
            else if (m_time > 0.3f && m_time < 0.6f)
            {
                transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (150 / 255f));
            }
            else if (m_time > 0.6f && m_time < 0.9f)
            {
                transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (255 / 255f));

            }
            else if (m_time > 1f)
            {
                //消失第一个
                float color1 = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color.a;
                color1 -=0.5f * Time.deltaTime;
                if(color1 < 0)
                {
                    color1 = 0;
                }
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, color1);
                //
                //消失第二个
                float color2 = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color.a;
                color2 -= 0.5f * Time.deltaTime;
                if (color2 < 0)
                {
                    color2 = 0;
                }
                transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, color2);
                //
                //消失第三个
                float color3 = transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color.a;
                color3 -= 0.5f * Time.deltaTime;
                if (color3 < 0)
                {
                    color3 = 0;
                }
                transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, color3);
                //
                if (color1 <= 0 && color2 <= 0 && color3 <= 0)
                {
                    m_time = 0;
                    isAddTime = false;
                }
            }   
        }
       
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //碰到地面
        if (col.collider.tag == "ground"|| col.collider.tag == "barrier")
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
        }
        if (col.tag == "reward_add_time")//吃到加时道具，显示加时UI
        {
            isAddTime = true;
        }
    }
}
