using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_control : MonoBehaviour
{
    private float alphaSpeed = 1f;
    private CanvasGroup canvas;
    private float m_time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.GetComponent<CanvasGroup>();
        canvas.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        if (m_time >= 1.5f)
        {
            canvas.alpha = Mathf.Lerp(canvas.alpha, 0, alphaSpeed * Time.deltaTime);
        }
        if (canvas.alpha <= 0.001f)
        {
            this.enabled = false;
        }
    }
}
