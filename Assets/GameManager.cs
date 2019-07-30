using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin scoreSkin;

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
        Debug.Log("Score: Player1 - " + PlayerScore1 + " Player2 - " + PlayerScore2);
    }

    private void OnGUI()
    {
        GUI.skin = scoreSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150, 10, 100, 100), PlayerScore1.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150, 10, 100, 100), PlayerScore2.ToString());
    }
}
