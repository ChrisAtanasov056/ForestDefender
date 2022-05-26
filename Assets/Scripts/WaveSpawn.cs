using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour {

	public GameObject EnemyPrefab;

	public Transform spawnPoint;
	public Text waveCountdownText;
	private int waveNumber = 0;
	public float timeBetweenWaves = 5f;
	private float countdown = 2f;


	void Update()
	{
		if (countdown <= 0f )
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;
		waveCountdownText.text = Mathf.Round(countdown).ToString();
	}

	IEnumerator SpawnWave()
    {
        waveNumber++;
		for (int i = 0; i < waveNumber; i++)
        {
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f);
		}
		

		
    }
	void SpawnEnemy()
	{
		Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);
      
    }
}
