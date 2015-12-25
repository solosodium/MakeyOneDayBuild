using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	public Text score;
	public MainBody mainBody;
	public Generator generator;

	// Use this for initialization
	void Start () {
		Block.onScore += ScoreHandler;
		Block.onTerminate += TerminateHandler;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			mainBody.Initialize ();
			generator.isEnable = true;
			score.text = 0.ToString();
		}
	}

	private void ScoreHandler (int score) {
		if (mainBody.isActive) {
			this.score.text = (int.Parse (this.score.text) + 1).ToString ();
		}
	}

	private void TerminateHandler () {
		generator.isEnable = false;
	}
}
