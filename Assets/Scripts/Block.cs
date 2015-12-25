using UnityEngine;
using System.Collections;
public class Block : MonoBehaviour {

	public delegate void OnTerminate ();
	public static event OnTerminate onTerminate;

	public delegate void OnScore (int score);
	public static event OnScore onScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Collision
	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Recycle") {
			Destroy (this.gameObject);
		}
		if (other.name == "Rim") {
			if (onTerminate != null) {
				onTerminate();
			}
		}
		if (other.name == "Detector") {
			if (onScore != null) {
				onScore(1);
			}
		}
	}

	public void Initialize (float speed, float scale) {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0f);
		this.transform.localScale = new Vector2 (1f, scale);
	}
}
