using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private SwitchState switchState;

    public void GameOver()
    {
        playerController.enabled = false;
        switchState.enabled = false;
        fadeAnim.SetTrigger("GameOver");
    }

    public void CompleteGame()
    {
        playerController.enabled = false;
        switchState.enabled = false;
        fadeAnim.SetTrigger("CompleteGame");
    }

    public void Retry()
    {
        ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    #region Singleton
    private static GameManager instance;

    private void Awake()
    {
        instance = this;
        ResetGame();
    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    #endregion
}
