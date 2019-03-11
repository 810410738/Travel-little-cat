using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_move : MonoBehaviour
{
    public float speed = 0.2f;
    public float move = 23.55f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.localPosition;
        v.x -= speed * Time.deltaTime;
        if (v.x < -move)
        {
            v.x += move * 2;
        }
        transform.localPosition = v;
    }

}
