using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemyFactory;
    public Transform spawnPoint;
    public float timeBetweenWave = 2f;
    private float countDown = 0f;
    private int waveIndex = 0;
    public Text waveCountDownText; // it is used for display the time for the next wave
	
	// Update is called once per frame
	void Update ()
    {
        if (countDown <= 0)
        {
            StartCoroutine(WaveStart());    //start a new coroutine that can be paused by a yield
            countDown = timeBetweenWave;
        }
        string timeToNextWave = Mathf.Floor(countDown).ToString(); //update the value inside the text
        if (timeToNextWave.Equals("0"))
            waveCountDownText.text = "Wave " + (waveIndex + 1) + " incoming!";
        else
            waveCountDownText.text = timeToNextWave;
        countDown = countDown - Time.deltaTime;
	}

    IEnumerator WaveStart ()// it is used when a new wave starts
    {
        waveIndex++;
        Debug.Log("Wave " + waveIndex + " incoming!");
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();   //create new enemy clone
            yield return new WaitForSeconds(0.5f);  //pause a coroutine
        }
    }

    void SpawnEnemy () // it clones the enemy
    {
        Instantiate(enemyFactory, spawnPoint.position, spawnPoint.rotation);
    }

}
