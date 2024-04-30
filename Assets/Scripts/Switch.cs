using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
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
}
