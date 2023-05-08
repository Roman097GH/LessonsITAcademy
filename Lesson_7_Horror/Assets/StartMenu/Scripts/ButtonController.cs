using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject _guidePanel;

    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void Guide()
    {
        _guidePanel.gameObject.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void MenuGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
