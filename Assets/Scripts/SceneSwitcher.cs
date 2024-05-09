using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    /// Switch  Script
    /// Kozeng Yang
    // 4/30/24
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SwitchScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    /// robert - make a point script and make it so after 10 kills, it will switch the scene

}
