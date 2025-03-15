using UnityEngine;

public class MenuAudioManagement : MonoBehaviour
{

    public AudioSource src;
    public AudioClip sfx1, sfx2;

    public void hoverSound(){
        src.clip = sfx1;
        src.Play();
    }

    
    public void clickSound(){
        src.clip = sfx2;
        src.Play();
    }
}
