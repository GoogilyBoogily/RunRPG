using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private float speed = 2.0f;

	private float backOfScreen = -4.5f;

	//-----------------
	// Enemy stats
	//-----------------
	public int level = 0;
	public int healthPoints = 0;
	public int magicPoints = 0;
	public int damage = 0;
	public int critChance = 0;

	//---------------------
	// Enemy intentory
	//---------------------
	public int experiencePointsToGive = 0;
	public int goldToGive = 0;


	// Use this for initialization
	void Start () {
		// Set the experience and gold dropped to a random number in a range
		experiencePointsToGive = (int)Mathf.Round(Random.Range(1.0f, 10.0f));
		goldToGive = (int)Mathf.Round(Random.Range(0.0f, 20.0f));
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

		/*
		if (coll.gameObject.tag == "Player") {
			Destroy(this.gameObject);
        }  // end if
		*/

	}   // end OnTriggerEnter2D()
} // end class
