using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform main;
    public TextEditor  text_score;
    public int m_score = 0;
    // Start is called before the first frame update
    void Start()
    {
        text_score = main.transform.Find("text_socre").GetComponent<TextEditor>();
        text_score.text = string.Format("得分 ", m_score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
