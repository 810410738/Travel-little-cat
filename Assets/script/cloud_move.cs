using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_move : MonoBehaviour
{
    public float speed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.localPosition;
        v.x -= speed * Time.deltaTime;
        if (v.x < -23.55f)
        {
            v.x += 23.55f * 2;
        }
        transform.localPosition = v;
    }
}
