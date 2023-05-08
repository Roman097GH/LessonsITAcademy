using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _cardsWithNumber;
    [SerializeField] private GameObject _pauseCanvas;

    [SerializeField] private TMP_InputField _password;

    [SerializeField] private Animator _doorAnimator;
    private static readonly int OpenDoorTrigger = Animator.StringToHash("OpenDoorTrigger");
    
    private bool _isCanvas;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void Update()
    {
        if (_password.text == "5836")
        {
            _doorAnimator.SetTrigger(OpenDoorTrigger);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _isCanvas == false)
        {
            OpenMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isCanvas)
        {
            CloseMenu();
        }
    }

    public void AddClick(int index)
    {
        _cardsWithNumber[index].gameObject.SetActive(true);
    }

    private void OpenMenu()
    {
        _pauseCanvas.gameObject.SetActive(true);
        _isCanvas = true;
    }

    private void CloseMenu()
    {
        _pauseCanvas.gameObject.SetActive(false);
        _isCanvas = false;
    }
}


