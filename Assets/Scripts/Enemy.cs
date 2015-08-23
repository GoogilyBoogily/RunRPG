using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float speed = 2.0f;

	private float backOfScreen = -4.5f;


	// Use this for initialization
	void Start () {
	
	} // end Start()
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += Vector3.left * speed * Time.deltaTime;

		if (gameObject.transform.position.x <= backOfScreen) {
			Destroy(gameObject);
		} // end if
	} // end Update()


	// Called when the enemy collider touches another collider
	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.gameObject.tag == "Player") {
			Destroy(this.gameObject);
        }  // end if
	}   // end OnTriggerEnter2D()
} // end class
