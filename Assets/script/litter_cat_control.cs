using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class litter_cat_control : MonoBehaviour
{
    private MainController main;
    public float time = 60;
    private float remain_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        main = GameObject.FindWithTag("MainCamera").GetComponent<MainController>();
        remain_time = main.time;
        float scale = (time - remain_time) / time;
        float distance = 8.86f;
        Vector2 v = transform.localPosition;
        v.x = distance * scale-4.39f;
        transform.localPosition = v;
    }
}
