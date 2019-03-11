using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public float time = 30f;//second per game
    private int goal = 0;
    public Text scoreTextObject;
    public Text distanceObject;
    private float speedUpSubstractTime = 0;
    private float speedUpDuration = 0;
    private int level = 0;
    private float[] levelData;

    private void Start()
    {
        //level = GameObject.Find("LevelController").GetComponent<LevelController>().GetChosenLevel();
        //levelData = LevelData.GetData(level);
    }

    private void Update()
    {
        //Goal(1);
        TimePast();
    }

    private void TimePast()//time always past
    {
        float dt = Time.deltaTime;
        float speedUpPastTime = speedUpDuration == 0 ? 0 : speedUpSubstractTime / speedUpDuration * dt;
        float temPastTime = dt + speedUpPastTime;
        speedUpSubstractTime = speedUpSubstractTime - (temPastTime - dt) < 0 ? 0 : speedUpSubstractTime - (temPastTime - dt);
        speedUpDuration = speedUpDuration - dt < 0 ? 0 : speedUpDuration - dt;
        time = time - temPastTime < 0 ? 0 : time - temPastTime;
        float formatTime = (int)((30 - time) / 30 * 10000) / 100.0f;
        distanceObject.GetComponent<Text>().text = formatTime + "%";
    }

    public void Goal(int goalNumber)//when you get a prize, goal()
    {
        this.goal += goalNumber;
        scoreTextObject.GetComponent<Text>().text = "score:" + goal;
    }

    public void SpeedUp(float substractTime, float lastTime)//when you speed up, speedUP(),第一个参数是加速效果，第二个参数是加速持续时间
    {
        speedUpSubstractTime = substractTime;
        speedUpDuration = lastTime;
    }
}

class LevelData
{
    private static float[][] data = new float[][]
    {
        new float[]{
            1f,
            2f,
            6f
        },
        new float[]{
            3f,
            4f,
            8f
        },
        new float[]{
            4f,
            5f,
            9f
        }
    };

    public static float[] GetData(int levelNum)
    {
        if (levelNum >= data.Length)
        {
            return data[data.Length - 1];
        }
        else
            return data[levelNum];
    }
}
