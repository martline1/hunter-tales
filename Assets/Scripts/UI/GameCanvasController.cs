using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private HeartController[] hearts;

    public void DrawHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {

            hearts[i].SetIsAlive(i < gameController.Hearts);
        }
    }
}
