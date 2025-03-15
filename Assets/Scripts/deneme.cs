using UnityEngine;

public class deneme : MonoBehaviour
{
    public GameObject Market;
    public GameObject pauseScreen;
    public bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseScreen.SetActive(false);
        Market.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pause();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key is pressed");
            open(pauseScreen);
            
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M key is pressed");
            open(Market);
            
        }
    }
    void open(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
    void pause()
    {
        if(Market.activeSelf || pauseScreen.activeSelf)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
