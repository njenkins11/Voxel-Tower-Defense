using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isFastForward = false;

    public void FastAndUnfastforwad()
    {
        if(isFastForward)
        {
            isFastForward = false;
            Time.timeScale = 1;
        }
        else
        {
            isFastForward = true;
            Time.timeScale = 2;
        }
    }
    public void SwitchToGameScene()
    {
        Time.timeScale = 1;
        StartCoroutine("SwitchToGameSceneIE");
    }

    IEnumerator SwitchToGameSceneIE()
    {
          SceneManager.LoadScene("Game");
          yield return 0;
          SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game"));
    }

    public void SwitchToMenuScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
