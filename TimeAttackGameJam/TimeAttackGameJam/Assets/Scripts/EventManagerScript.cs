using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    private void Awake()
    {
        current = this;
    }
    public event Action GameStart;
    public void onGameStart()
    {
        if (GameStart != null)
        {
            GameStart();
        }
    }
}
