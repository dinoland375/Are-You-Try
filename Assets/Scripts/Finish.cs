using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject panelButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Figure"))
        {
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            panelButton.SetActive(true);
        }
    }
}
