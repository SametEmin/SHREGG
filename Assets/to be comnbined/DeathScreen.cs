using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button restartButton;
    public Button MainMenuButton;
    public WaveManager waveManager;
    public string restartSceneName;
    public string mainMenuSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = ("You survived " + waveManager.getCurrentWave() + " waves!");
        //restartButton.onClick.AddListener(Restart);
        //MainMenuButton.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Restart()
    {
      SceneManager.LoadScene(restartSceneName);
    }
    void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
