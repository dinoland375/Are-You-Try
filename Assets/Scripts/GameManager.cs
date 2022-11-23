using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WallsController wallsController;
    [SerializeField] private RigController rigController;
    
    private static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    } 
    
    public void StartGame(GameObject figure)
    {
        rigController.Initialize(figure);
        wallsController.CreatedWall();
        rigController.checkFirstWall = true;
        rigController.StartCountdownTimer();
    }
}