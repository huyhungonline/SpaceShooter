//design by nguyen huy hung
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject EnemyGO; // this is  our's enemy prefab
	float maxSpawnRateInSeconds=5f;
	// Use this for initialization
	void Start () {
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
		//increase spwan rate very 30 second
		InvokeRepeating ("IncreaseSpawnRate",0f,30f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// Funtion to spawn an enemy
	void SpawnEnemy(){

		// this is bottom - left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		//  this is the top-rigt the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		// instante an enemy
		GameObject anEnemy = (GameObject)Instantiate (EnemyGO);
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
		ScheduleNextEnemySpawn ();
			 
	}
	void ScheduleNextEnemySpawn(){
		float spawnInNSeconds;

		if (maxSpawnRateInSeconds > 1f) {

			// pixk a numbef
			spawnInNSeconds  = Random.Range(1f,maxSpawnRateInSeconds);

		}else
		{
			spawnInNSeconds =1f;
			Invoke("SpawnEnemy",spawnInNSeconds);
		}
	}
	// the funtion iincrease difficut of game 
	  void IncreaseSpanwRate(){
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

}
