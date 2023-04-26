using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private Animator _treeAnimator;
    [SerializeField] private Animator _platformAnimator;
    [SerializeField] private GameObject _canvasPrefab;
    [SerializeField] private GameObject _newCanvasPrefab;
    
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(1);
        }
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (_newCanvasPrefab)
        {
            ResumeGame();
            return;
        }
        
        ShowMenu();
        PauseGame();
    }

    private void ShowMenu()
    {
        _newCanvasPrefab = Instantiate(_canvasPrefab, _canvasPrefab.transform.position, Quaternion.identity);
        
        GameObject pausePanel = _newCanvasPrefab.transform.GetChild(0).gameObject;
        GameObject buttonBar = pausePanel.transform.GetChild(0).gameObject;
        GameObject resumeButton = buttonBar.transform.GetChild(0).gameObject;
        GameObject exitButton = buttonBar.transform.GetChild(1).gameObject;

        _resumeButton = resumeButton.GetComponent<Button>();
        _exitButton = exitButton.GetComponent<Button>();
        
        _resumeButton.onClick.AddListener(ResumeGame);
        _exitButton.onClick.AddListener((ExitGame));
    }

    private void PauseGame()
    {
        _camera.GetComponent<CinemachineBrain>().enabled = false;
        _character.GetComponent<Character>().enabled = false;
        _characterAnimator.GetComponent<Animator>().enabled = false;
        _platformAnimator.GetComponent<Animator>().enabled = false;
        _treeAnimator.GetComponent<Animator>().enabled = false;
    }
    
    private void ResumeGame()
    {
        _camera.GetComponent<CinemachineBrain>().enabled = true;
        _character.GetComponent<Character>().enabled = true;
        _characterAnimator.GetComponent<Animator>().enabled = true;
        _platformAnimator.GetComponent<Animator>().enabled = true;
        _treeAnimator.GetComponent<Animator>().enabled = true;
        Destroy(_newCanvasPrefab);
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log(nameof(ExitGame));
    }
}