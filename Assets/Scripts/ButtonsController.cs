using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    [SerializeField] private GameObject figure = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private GameObject[] buttons = null;
    
    void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Play":
                Application.LoadLevel ("Game");
                break;
            case "Exit":
                Application.Quit();
                break;
            case "Easy":
                gameManager.StartGame(figure);
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                break;
            case "Medium":
                gameManager.StartGame(figure);  
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                break;
            case "Hard":
                gameManager.StartGame(figure);                
                buttons[0].SetActive(false);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                break;
            case "RestartButton":
                Time.timeScale = 1f;
                Application.LoadLevel("Game");
                break;
            case "MainMenuButton":
                Time.timeScale = 1f;
                Application.LoadLevel("Menu");
                break;
            case "PauseButton":
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                buttons[3].SetActive(true);
                Time.timeScale = 0f;
                break;
            case "BackButton":
                Time.timeScale = 1f;
                buttons[0].SetActive(true);
                buttons[1].SetActive(false);
                buttons[2].SetActive(false);
                buttons[3].SetActive(false);
                break;
        }
    }
}
