using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static int enemyAlives = 0; // used for count the enemy in the scene
    private static bool levelCompleted;
    public WaveInfo[] waves;
    public Transform spawnPoint;
    public float timeBetweenWave = 2f;
    private float countDown = 5f;
    private int waveIndex = 0;
    public Text waveCountDownText; // it is used for display the time for the next wave

    private void Start()
    {
        //enemyAlives = 0;
        levelCompleted = false;
    }

    // Update is called once per frame
    private void Update ()
    {
        if (enemyAlives > 0) // if there are enemy from the last wave, do nothing
            return;
        if(enemyAlives <= 0 && waveIndex >= waves.Length)
        {
            Debug.Log("Level Completed");
            levelCompleted = true;
            this.enabled = false;
            return;
        }
        if (countDown <= 0f && !levelCompleted)
        {
            StartCoroutine(WaveStart());    //start a new coroutine that can be paused by a yield return
            countDown = timeBetweenWave;
            return;
        }
        string timeToNextWave = Mathf.Floor(countDown).ToString(); //update the value inside the text
        if (timeToNextWave.Equals("0"))
            waveCountDownText.text = "Wave " + (waveIndex + 1) + " incoming!";
        else
            waveCountDownText.text = timeToNextWave;
        countDown = countDown - Time.deltaTime;
	}

    // coroutine is necessary because the enemy will be created every WaitForSeconds() time;
    // using waves, every wave's behavior is driven by WaveInfo class, so every waves can be different each other
    IEnumerator WaveStart ()// it is used when a new wave starts
    {
        PlayerStatistic.rounds = waveIndex + 1;
        WaveInfo wave = waves[waveIndex];
        Debug.Log("Wave " + (waveIndex + 1) + " incoming!");
        Debug.Log(enemyAlives);
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);   //create new enemy clone
            yield return new WaitForSeconds(1f / wave.rate);  //pause a coroutine, enemy will be spawned every WaitForSeconds argument
        }
        waveIndex++;
    }

    private void SpawnEnemy (GameObject enemy) // it clones the enemy
    {
        enemyAlives++;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
