using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reward_title_control : MonoBehaviour
{
	public float alphaSpeed = 1f;
	public bool isShow = false;
	private CanvasGroup canvas;
	// Start is called before the first frame update
	void Start()
    {
		canvas = transform.GetComponent<CanvasGroup>();
		canvas.alpha = 0;
	}

    // Update is called once per frame
    void Update()
    {
		if (isShow)
		{
			canvas.alpha = Mathf.Lerp(canvas.alpha, 0, alphaSpeed * Time.deltaTime);
            if (canvas.alpha <= 0f)
            {
                isShow = false;
            }
        }
	}
	public void show()
	{
		canvas.alpha = 1;
		isShow = true;
	}
}
