using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameCanvasController gameCanvasController;

    [SerializeField]
    private MenuCanvasController menuCanvasController;

    public int Hearts { get; private set; }

    public bool MenuOpen { get; private set; }

    private void Awake()
    {
        SetHearts(3);
        SetMenuOpen(true);
    }

    public void PlayGame()
    {
        SetMenuOpen(false);

        // Value is 2 to demostrate change in sprites
        SetHearts(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetMenuOpen(bool value)
    {
        MenuOpen = value;

        menuCanvasController.UpdateTexts();

        menuCanvasController.gameObject.SetActive(MenuOpen);
        gameCanvasController.gameObject.SetActive(!MenuOpen);
    }

    public void SetHearts(int value)
    {
        if (value < 0)
        {
            Hearts = value;
            SetMenuOpen(true);
        }
        else if (value < 4)
        {
            Hearts = value;
            gameCanvasController.DrawHearts();
        }
    }
}
