using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin scoreSkin;

    private Transform ball;

    public static void Score(string wallName)
    {
        if (wallName == "LeftWall")
        {
            PlayerScore1 += 1;
        }
        else if (wallName == "RightWall")
        {
            PlayerScore2 += 1;
        }
    }

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    private void OnGUI()
    {
        GUI.skin = scoreSkin;
        int symbolWidth = 32;
        GUI.Label(new Rect(Screen.width / 2 - 150 - symbolWidth / 2, 25, symbolWidth, 100), PlayerScore1.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 - symbolWidth / 2, 25, symbolWidth, 100), PlayerScore2.ToString());

        int buttonWidth = 121;
        int buttonHeight = 53;
        if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth/2, 35, buttonWidth, buttonHeight), "RESET"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            ball.SendMessage(nameof(BallController.ResetBall)); // or GetComponent<BallController>() and call directly
        }
    }
}
