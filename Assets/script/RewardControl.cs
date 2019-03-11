using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardControl : MonoBehaviour
{
    private MainController Main;
    public int reward = 10;
    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
       {
            if (transform.tag == "reward")
            {
                Main.Goal(reward);
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);
            }
            else if(transform.tag == "reward_speedup")
            {
                Main.SpeedUp(1,1);
                Main.Goal(reward);
                AudioManager.Instance.PlaySound("eat");
                Destroy(gameObject);
            }
            
       }
    }
}
