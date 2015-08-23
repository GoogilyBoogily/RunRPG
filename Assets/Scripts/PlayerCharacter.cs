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

	// Use this for initialization
	void Start () {
		if(playerCharacter == null) {
			playerCharacter = GameObject.FindWithTag("Player");
		}	// end if

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
				}   // end if/else block

				journeyLength = Vector3.Distance(playerCharacter.transform.position, targetTrack);

				playerMoving = true;
			} else {
				Debug.Log("Player is on the bottom most track");
			}  // end if/else
		}   // end if

		if (playerMoving) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;

			if (fracJourney != 1) {
				playerCharacter.transform.position = Vector3.Lerp(playerCharacter.transform.position, targetTrack, fracJourney);
			} else {
				playerMoving = false;
			} // end if/else
			
		} // end if

	} // end Update()


}
