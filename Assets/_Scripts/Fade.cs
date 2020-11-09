using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public void GameOverUI()
    {
        UIManager.Instance.GameOver();
    }

    public void CompleteGameUI()
    {
        UIManager.Instance.FinishGame();
    }
}
