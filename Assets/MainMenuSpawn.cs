using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuSpawn : MonoBehaviour
{

	public GameObject EnemyPrefab;
    public float speed = 20f;
	public Transform spawnPoint;
    public Transform EndPoint;
    public GameObject player;
    public GameObject mainMenunUI;
    void Start()
    {
       player = SpawnEnemy();
	}
    void Update()
    {
        Vector3 direction = EndPoint.position - spawnPoint.transform.position;
        player.transform.Translate(speed * Time.deltaTime * direction.normalized, Space.World);
        transform.LookAt(EndPoint);
        if (player.transform.position.z <= EndPoint.position.z)
        {
            player.transform.position = EndPoint.position;
            player.GetComponent<Animator>().enabled = false;
            if (mainMenunUI.active == false)
            {
                mainMenunUI.SetActive(true);

            }
        }
        

    }

    GameObject SpawnEnemy()
	{
		GameObject lob = (GameObject)Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        return lob;

    }
}

