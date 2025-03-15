using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public Button Quitbutton;


    void Start()
    {
        Quitbutton.onClick.AddListener(Quit);
        
    }
    public void Quit()
    {
        Debug.Log("Game is quitting...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Editor
        #else
            Application.Quit();
        #endif
    }

    
}
