using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {
	public GameObject enemyPrefab;

	private Vector3 topSpawnVector = new Vector3(4, 2, 0);
	private Vector3 middleSpawnVector = new Vector3(4, 0, 0);
	private Vector3 bottomSpawnVector = new Vector3(4, -2, 0);

	private float spawnTimer = 0;

	private bool spawning = true;

	// Use this for initialization
	void Start () {
		spawnTimer = Random.Range(0.0f, 4.0F);
    } // end Start()
	
	// Update is called once per frame
	void Update () {
		if (spawning) {
			spawnTimer -= Time.deltaTime;

			if (spawnTimer <= 0) {
				SpawnEnemy();

				spawnTimer = Random.Range(0.5f, 4.0F);
			} // end if
		} // end if
	} // end Update()


	// Spawns an enemy on a random track
	private void SpawnEnemy() {
		int trackToSpawnOn = (int)Mathf.Round(Random.Range(1.0f, 3.0f));

		Vector3 spawnVector = new Vector3();
		if (trackToSpawnOn == 1) {
			spawnVector = topSpawnVector;
		} else if (trackToSpawnOn == 2) {
			spawnVector = middleSpawnVector;
		} else if (trackToSpawnOn == 3) {
			spawnVector = bottomSpawnVector;
		} // end if/else block

		Instantiate(enemyPrefab, spawnVector, Quaternion.identity);
	} // end SpawnEnemy()
} // end class
