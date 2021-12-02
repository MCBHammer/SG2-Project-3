using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject _mainPanel = null;
    [SerializeField] GameObject _rulesPanel = null;
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenRules()
    {
        _mainPanel.SetActive(false);
        _rulesPanel.SetActive(true);
    }

    public void CloseRules()
    {
        _mainPanel.SetActive(true);
        _rulesPanel.SetActive(false);
    }
}
