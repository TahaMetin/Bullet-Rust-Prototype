using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void PauseTheGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueTheGame()
    {
        Time.timeScale = 1;
    }
}
