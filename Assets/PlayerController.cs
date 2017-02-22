using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb;
	private uint score;
	public Text scoreText;
	public Text winText;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		score = 0;
		UpdateScore ();
	}
		

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		rb.AddForce (new Vector2 (moveHorizontal, moveVertical) * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject otherGameObject = other.gameObject;
		if (otherGameObject.CompareTag("PickUp")) {
			otherGameObject.SetActive (false);
			score++;
			UpdateScore ();
		}
	}

	private void UpdateScore () {
		scoreText.text = "Score: " + score.ToString ();
		if (score >= 11) {
			winText.gameObject.SetActive (true);
		}
	}
}
