using UnityEngine;
using TMPro; // Add this line to access TextMesh Pro components
using System.Collections;
// lib for scene
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    private int totalWaves = 10;
    private float waveDuration = 20f; // Duration of each wave in seconds

    private int currentWave = 0;
    private float waveTimer = 0f;
    private GameState currentState = GameState.Wave;

    public TextMeshProUGUI timeRemainingText; // Use TextMeshProUGUI instead of Text
    public TextMeshProUGUI waveNumberText; // Use TextMeshProUGUI instead of Text
    public TextMeshProUGUI healthText;

    public GameObject marketUI; // Reference to the market UI game object   
    public GameObject pauseUI;

    public GameObject player;

    Player playerCode; 
    EnemySpawner enemySpawner;
    public GameObject DeathScene;
    public GameObject HappyEnd;



    private enum GameState
    {
        Wave,
        Market,
        GameOver
    }

    void Start()
    {
        
        playerCode = player.GetComponent<Player>();
        enemySpawner = GetComponentInChildren<EnemySpawner>();

        
        StartWave();
        if (timeRemainingText == null)
        {
            Debug.LogError("timeRemainingText is not assigned in the Inspector!");
        }
        if (waveNumberText == null)
        {
            Debug.LogError("waveNumberText is not assigned in the Inspector!");
        }
        if (healthText == null)
        {
            Debug.LogError("healthText is not assigned in the Inspector!");
        }

        
    }

    IEnumerator WaitForDeath(){
        Time.timeScale = 1;
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
        DeathScene.SetActive(false);
        StartWave();
        
        
    }

    void Update()
    {

        //death logic
        if(playerCode.currentHealth <= 0){
            currentState = GameState.GameOver;
            currentWave = 0;
            Debug.Log("Game Over! You died.");
            Time.timeScale = 0;
            DeathScene.SetActive(true);
            // wait 5 sec
            StartCoroutine(WaitForDeath());
            // return tp the main menu
            


        }

        switch (currentState)
        {
            case GameState.Wave:
                HandleWave();
                break;
            case GameState.Market:
                HandleMarket();
                break;
            case GameState.GameOver:
                OpenGameOverScreen();
                break;
        }

        // Update UI text elements
        if (timeRemainingText != null)
        {
            timeRemainingText.text = waveTimer.ToString("F1") + " s";
        }
        if (waveNumberText != null)
        {
            waveNumberText.text = "Wave: " + currentWave;
        }
        if (healthText != null)
        {
            healthText.text = "Health: " + playerCode.currentHealth;
        }
    }

    void StartWave()
    {
        if (currentWave < totalWaves)
        {
            DestroyAllEnemies(); // Destroy all enemies at the start of the wave
            if(currentWave > 10){
                
                
            }

            currentWave++;
            waveTimer = waveDuration + (currentWave % 3) * 5;
            currentState = GameState.Wave;

            if(currentWave == 5){
                miniBossLevel();
                
            }
            else if(currentWave == 10){
                bossLevel();
                
            }
            

            enemySpawner.spawnInterval = 0.15f - (currentWave * 0.01f); // Increase enemy spawn rate each wave

            Debug.Log("Wave " + currentWave + " started!");

            

            

            // Initialize enemies for the wave here
        }
        else
        {
            HappyEnd.SetActive(true);
                StartCoroutine(WaitForDeath());
                currentWave = 0;
            currentState = GameState.GameOver;
            Debug.Log("Game Over! You survived all waves.");
        }
    }

    void miniBossLevel(){
        // spawn mini boss here
        enemySpawner.minibossSpawn();
        enemySpawner.minibossEnemiesSpawn();

    }

    void bossLevel(){
        // Initialize boss level here
        enemySpawner.bossSpawn();
    }

    void HandleWave()
    {
        waveTimer -= Time.deltaTime;
        if (waveTimer <= 0)
        {
            StartMarket();
        }
        else
        {
            enemySpawner.enemySpawn();
        }
    }

    void HandleMarket()
    {
        if (marketUI.activeSelf == false && pauseUI.activeSelf == false)
        {
            StartWave();
            Time.timeScale = 1;
        }
    }

    void StartMarket()
    {
        currentState = GameState.Market;
        Time.timeScale = 0;
        marketUI.SetActive(true);
        Debug.Log("Market phase started!");
    }

    void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    void OpenGameOverScreen()
    {
       
    }
    public float getCurrentWave(){
        return currentWave;
    }
}