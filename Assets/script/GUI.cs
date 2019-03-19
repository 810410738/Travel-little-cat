using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    // Start is called before the first frame update
    public float alphaSpeed = 0.2f;
    private CanvasGroup introduct;
    private CanvasGroup begin;
    private CanvasGroup operate;
    private start_control start_c;
    private float m_time = 0;
    void Start()
    {
        //隐藏三个按钮
        introduct = GameObject.Find("introduct").transform.GetComponent<CanvasGroup>();
        begin = GameObject.Find("begin").transform.GetComponent<CanvasGroup>();
        operate = GameObject.Find("operate").transform.GetComponent<CanvasGroup>();
        introduct.alpha = 0;
        begin.alpha = 0;
        operate.alpha = 0;
        start_c = GameObject.Find("start1").GetComponent<start_control>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (start_c.isDone==true)
        {
            m_time += Time.deltaTime;
            introduct.alpha = Mathf.Lerp(introduct.alpha, 1, alphaSpeed * Time.deltaTime); 
            if (m_time > 0.3f)
            {
                operate.alpha = Mathf.Lerp(operate.alpha, 1, alphaSpeed * Time.deltaTime);
            }
           if (m_time > 0.6f)
           {
                begin.alpha = Mathf.Lerp(begin.alpha, 1, alphaSpeed * Time.deltaTime);
           }
           if(m_time>2f)
            {
                this.enabled = false;
            }
        }
     
    }
    
    private void abc()
    {
        
    }
}
