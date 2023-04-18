using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private Scoring _scoring;

    [SerializeField] private Gun _gun;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CameraMove _cameraMove;
    [SerializeField] private Image _aimImage;
    [SerializeField] private Animator _animator;

    public void GameWin()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        _menuPanel.gameObject.SetActive(true);
        _gun.GetComponent<Gun>().enabled = false;
        _playerController.GetComponent<PlayerController>().enabled = false;
        _cameraMove.GetComponent<CameraMove>().enabled = false;
        _aimImage.GetComponent<Image>().enabled = false;
        _animator.GetComponent<Animator>().enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
