using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    
    public void RestartGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
        Debug.Log(nameof(QuitGame));
        
        #endif
    }
}
