using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Camera _camera;
    [SerializeField] private Animator _characterAnimator;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Animator _treeAnimator;
    [SerializeField] private Animator _platformAnimator;
    [SerializeField] private GameObject _canvasPrefab;
    [SerializeField] private GameObject _newCanvasPrefab;
    
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    public bool IsGameActive;
    public bool IsPause;

    private void Start()
    {
        IsGameActive = true;
        IsPause = false;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
        if (_newCanvasPrefab)
        {
            ResumeGame();
            return;
        }
        
        ShowMenuResumeAndExit();
        PauseGame();
    }

    public void ShowMenuRestartAndExit()
    {
        _newCanvasPrefab = Instantiate(_canvasPrefab, _canvasPrefab.transform.position, Quaternion.identity);
        
        GameObject pausePanel = _newCanvasPrefab.transform.GetChild(0).gameObject;
        GameObject buttonBar = pausePanel.transform.GetChild(0).gameObject;
        GameObject resumeButton = buttonBar.transform.GetChild(0).gameObject;
        GameObject restartButton = buttonBar.transform.GetChild(1).gameObject;
        GameObject exitButton = buttonBar.transform.GetChild(2).gameObject;

        _resumeButton = resumeButton.GetComponent<Button>();
        _resumeButton.gameObject.SetActive(false);
        _restartButton = restartButton.GetComponent<Button>();
        _exitButton = exitButton.GetComponent<Button>();
        
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);

        IsPause = true;
    }

    public void ShowMenuResumeAndExit()
    {
        _newCanvasPrefab = Instantiate(_canvasPrefab, _canvasPrefab.transform.position, Quaternion.identity);
        
        GameObject pausePanel = _newCanvasPrefab.transform.GetChild(0).gameObject;
        GameObject buttonBar = pausePanel.transform.GetChild(0).gameObject;
        GameObject resumeButton = buttonBar.transform.GetChild(0).gameObject;
        GameObject restartButton = buttonBar.transform.GetChild(1).gameObject;
        GameObject exitButton = buttonBar.transform.GetChild(2).gameObject;

        _resumeButton = resumeButton.GetComponent<Button>();
        _restartButton = restartButton.GetComponent<Button>();
        _exitButton = exitButton.GetComponent<Button>();
        
        _resumeButton.onClick.AddListener(ResumeGame);
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);

        IsPause = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void PauseGame()
    {
        _camera.GetComponent<CinemachineBrain>().enabled = false;
        _character.GetComponent<Character>().enabled = false;
        _enemy.GetComponent<Enemy>().enabled = false;
        _characterAnimator.GetComponent<Animator>().enabled = false;
        _enemyAnimator.GetComponent<Animator>().enabled = false;
        _platformAnimator.GetComponent<Animator>().enabled = false;
        _treeAnimator.GetComponent<Animator>().enabled = false;
    }
    
    public void ResumeGame()
    {
        _camera.GetComponent<CinemachineBrain>().enabled = true;
        _character.GetComponent<Character>().enabled = true;
        _enemy.GetComponent<Enemy>().enabled = true;
        _characterAnimator.GetComponent<Animator>().enabled = true;
        _enemyAnimator.GetComponent<Animator>().enabled = true;
        _platformAnimator.GetComponent<Animator>().enabled = true;
        _treeAnimator.GetComponent<Animator>().enabled = true;
        
        Destroy(_newCanvasPrefab);
        
        IsPause = false;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log(nameof(ExitGame));
    }
}