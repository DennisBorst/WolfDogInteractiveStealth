using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ghostTimeText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject gameOverPanel;
    public void GhostTime(float _ghostTime)
    {
        ghostTimeText.text = "Ghost Time: " + _ghostTime;
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.SetActive(true);
    }

    public void FinishGame()
    {
        Cursor.lockState = CursorLockMode.None;
        gameOverText.text = "GAME COMPLETED";
        gameOverPanel.SetActive(true);
    }

    #region Singleton
    private static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    #endregion
}
