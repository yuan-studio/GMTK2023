using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public void TriggerGameOver(Transform enemyPosition)
    {
        Debug.LogError("game over haha");
    }

    private void Start()
    {
        instance = this;
    }
}
