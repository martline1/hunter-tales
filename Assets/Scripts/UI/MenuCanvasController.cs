using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuCanvasController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private TextMeshProUGUI title;

    public void UpdateTexts()
    {
        bool alive = gameController.Hearts > 0;

        title.text = alive
            ? "Hunter Tales"
            : "Game Over!";
    }
}
