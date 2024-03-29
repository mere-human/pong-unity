﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public Camera mainCamera;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public Transform player1;
    public Transform player2;

    // Start is called before the first frame update
    void Start()
    {
        var wallThickness = 1f;

        topWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2.0f, 0f, 0f)).x, wallThickness);
        topWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2.0f, 0f, 0f)).x, wallThickness);
        bottomWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(wallThickness, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2.0f, 0f)).y);
        leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(wallThickness, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height*2, 0f)).y);
        rightWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);


        player1.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(75f, 0)).x, 0, 0);
        player2.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0)).x, 0, 0);
    }
}
