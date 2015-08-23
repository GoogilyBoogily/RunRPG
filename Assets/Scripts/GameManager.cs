using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private GameObject playerCharacter;
	private GameObject background;
	private GameObject middleground;

	private float playerVelocity = 1.0f;

	private Vector3 frontVector = new Vector3(4.5f, 0, 0);

	private float backOfScreen = -4.5f;


	// Use this for initialization
	void Start() {
		if (playerCharacter == null) {
			playerCharacter = GameObject.FindWithTag("Player");
		}	// end if

		if (middleground == null) {
			middleground = GameObject.FindWithTag("Middleground");
        } // end if

	}  // end Start()

	// Update is called once per frame
	void Update() {
		foreach (Transform middlegroundCol in middleground.transform) {
			if (middlegroundCol.position.x <= backOfScreen) {
				middlegroundCol.position = frontVector;
			} else {
				middlegroundCol.position += Vector3.left * playerVelocity * Time.deltaTime;
			} // end if/else
		} // end foreach

	}  // end Update()
}  // end class
