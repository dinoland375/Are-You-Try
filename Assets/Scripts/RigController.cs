using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RigController : MonoBehaviour
{
    [SerializeField] private Transform finish;
    [SerializeField] private Transform rig;
    [SerializeField] private float additionalAngle = 5f;
    [SerializeField] private float boostedSpeed; 
    [SerializeField] private float time;
    [SerializeField] private GameObject timerText;
    [SerializeField] private WallsController wallsController = null;

    public float AdditionalAngle => additionalAngle;
    public bool checkFirstWall;
    public GameObject trueText;
    public GameObject falseText;    
    public float defaultSpeed; 
    
    private GameObject _createdFigure;
    private float CurrentAngle => _createdFigure.transform.eulerAngles.y;
    private float _timeLeft = 0f;
    private bool _currentSpeed;
    private bool _checkSecondWall;
    private bool _checkThirdWall;
    private bool _checkFourthWall;
    private bool _timerOn;

    private void Awake()
    {
        _timeLeft = time;
    }

    private void FixedUpdate()
    {
        if (_timeLeft == 0)
            _timerOn = true;
        else
            _timerOn = false;

        if (_timerOn)
        {
            timerText.SetActive(false);
            transform.position = Vector3.MoveTowards(rig.position, finish.position, defaultSpeed);
        }
        
        WallCheck();
        
        if (_currentSpeed)
        {
            trueText.SetActive(true);
            falseText.SetActive(false);
            defaultSpeed =+ boostedSpeed;
        }
        else
        {
            trueText.SetActive(false);
            falseText.SetActive(true);
            defaultSpeed = 0.3f;
        }
    }
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }
    public void StartCountdownTimer()
    {
        timerText.SetActive(true);
        StartCoroutine(StartTimer());
    }
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.GetComponent<Text>().text = string.Format("{00:00}", seconds);
    }
    public void Initialize(GameObject figure)
    {
        _createdFigure = Instantiate(figure, rig);
    }
    
    private void WallCheck()
    {
        if (checkFirstWall)
        {
            var wall = wallsController.backupWalls[0];

            if (wall.GetComponent<Wall>().NeededAngle >= CurrentAngle - additionalAngle &&
                wall.GetComponent<Wall>().NeededAngle <= CurrentAngle + additionalAngle)
            {
                _currentSpeed = true;
            }
            else
                _currentSpeed = false;

            if (wallsController.spawnPoints[0].x + 20 <= rig.position.x)
            {
                _checkSecondWall = true;
                checkFirstWall = false;
            }
        }

        if (_checkSecondWall)
        {
            var wall1 = wallsController.backupWalls[1];
            
            if (wall1.GetComponent<Wall>().NeededAngle >= CurrentAngle - additionalAngle &&
                wall1.GetComponent<Wall>().NeededAngle <= CurrentAngle + additionalAngle)
            {
                _currentSpeed = true;
            }
            else
                _currentSpeed = false;
            
            if (wallsController.spawnPoints[1].x + 20 <= rig.position.x)
            {
                _checkThirdWall = true;
                _checkSecondWall = false;
            }
        }

        if (_checkThirdWall)
        {
            var wall2 = wallsController.backupWalls[2];
            
            if (wall2.GetComponent<Wall>().NeededAngle >= CurrentAngle - additionalAngle &&
                wall2.GetComponent<Wall>().NeededAngle <= CurrentAngle + additionalAngle)
            {
                _currentSpeed = true;
            }
            else
                _currentSpeed = false;
            
            if (wallsController.spawnPoints[2].x + 20 <= rig.position.x)
            {
                _checkFourthWall = true;
                _checkThirdWall = false;
            }
        }
        
        if (_checkFourthWall)
        {
            var wall3 = wallsController.backupWalls[3];
            
            if (wall3.GetComponent<Wall>().NeededAngle >= CurrentAngle - additionalAngle &&
                wall3.GetComponent<Wall>().NeededAngle <= CurrentAngle + additionalAngle)
            {
                _currentSpeed = true;
            }
            else
                _currentSpeed = false;
        }
    }
}