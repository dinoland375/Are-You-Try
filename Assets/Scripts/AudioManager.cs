using UnityEngine;
using UnityEngine.UI;

public class AudioManager: MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Sprite layerBlue, layerRed;
    
    void OnMouseUpAsButton()
    {
        audioSource.mute = !audioSource.mute;
        if (audioSource.mute == true)
            GetComponent<Image>().sprite = layerRed;
        else
            GetComponent<Image>().sprite = layerBlue;
        
        
    }
}  
