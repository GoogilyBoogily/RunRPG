using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private GameObject playerCharacter;

	private int currentTrack = 1;

	private int topTrackLocation = 0;
	private int middleTrackLocation = 1;
	private int bottomTrackLocation = 2;
	
	private Vector3 topTrackVector = new Vector3(-3, 2, 0);
	private Vector3 middleTrackVector = new Vector3(-3, 0, 0);
	private Vector3 bottomTrackVector = new Vector3(-3, -2, 0);

	private bool playerMoving = false;

	public float speed = 1.5f;
	private float startTime;
	private float journeyLength;
	private Vector3 targetTrack;

	//-----------------
	// Character stats
	//-----------------
	private int level = 0;
	private int experiencePoints = 0;
	private int healthPoints = 0;
	private int magicPoints = 0;
	private int damage = 0;
	private int dodgeSpeed = 0;
	private int critChance = 0;

	//---------------------
	// Character intentory
	//---------------------
	private int gold = 0;



	// Use this for initialization
	void Start () {
		if(playerCharacter == null) {
			playerCharacter = GameObject.FindWithTag("Player");
		} // end if

	} // end Start()
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (currentTrack != topTrackLocation) {
				if (currentTrack == middleTrackLocation) {
					startTime = Time.time;

					targetTrack = topTrackVector;
					currentTrack = topTrackLocation;
				} else if (currentTrack == bottomTrackLocation) {
					startTime = Time.time;

					targetTrack = middleTrackVector;
					currentTrack = middleTrackLocation;
				}  // end if/else block

				journeyLength = Vector3.Distance(playerCharacter.transform.position, targetTrack);
				playerMoving = true;
			} else {
				Debug.Log("Player is on the top most track");
			} // end if/else
		} // end if

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			if(currentTrack != bottomTrackLocation) {
				if(currentTrack == middleTrackLocation) {
					startTime = Time.time;

					targetTrack = bottomTrackVector;
					currentTrack = bottomTrackLocation;
                } else if(currentTrack == topTrackLocation) {
					startTime = Time.time;

					targetTrack = middleTrackVector;
					currentTrack = middleTrackLocation;
				} // end if/else block

				journeyLength = Vector3.Distance(playerCharacter.transform.position, targetTrack);

				playerMoving = true;
			} else {
				Debug.Log("Player is on the bottom most track");
			}  // end if/else
		} // end if

		// If the player is moving
		if (playerMoving) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			if (fracJourney != 1) {
				playerCharacter.transform.position = Vector3.Lerp(playerCharacter.transform.position, targetTrack, fracJourney);
			} else {
				playerMoving = false;
			} // end if/else
			
		}  // end if

		if (experiencePoints >= 100) {
			experiencePoints %= 100;

			LevelUp();
		} // end if

	}  // end Update()


	// Fires when we collide with something
	void OnTriggerEnter2D(Collider2D coll) {

		// If we hit an enemy
		if(coll.gameObject.tag == "Enemy") {
			// Grab the enemy script
			Enemy enemyScript = coll.gameObject.GetComponent<Enemy>();

			// Add their dropped experience and gold to ours
			this.experiencePoints += enemyScript.experiencePointsToGive;
			this.gold += enemyScript.goldToGive;

			Debug.Log("Experience: " + experiencePoints);
			Debug.Log("Gold: " + gold);

			Destroy(coll.gameObject);
		} // end if

	} // end OnTriggerEnter2D()


	// When we level up!
	void LevelUp() {
		this.level++;

		Debug.Log("Level up! Now level: " + this.level);
	} // end LevelUp()


} // end class
