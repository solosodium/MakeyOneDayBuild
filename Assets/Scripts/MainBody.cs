using UnityEngine;
using System.Collections;

public class MainBody : MonoBehaviour {

	public bool isActive;
	public GameObject rim;
	public GameObject core;
	public GameObject particle;
	public float rimMinSize;		// min size
	public float rimMaxSize;		// max size
	public float retainTime;		// retain time
	public float enlargeSpeed;		// enlarge speed
	public float yVelocity;			// vertical velocity
	public float rotateSpeed;		// rotate speed

	private Coroutine _enlargeRoutine;
	private float _currentSize;

	// Use this for initialization
	void Start () {
		MakeyGoInput.onClicks += OnClickHandler;
		_currentSize = rimMinSize;
		Block.onTerminate += TerminateHandler;
	}
	
	// Update is called once per frame
	void Update () {
		float size = Mathf.Lerp (rim.transform.localScale.x, _currentSize, Time.deltaTime * enlargeSpeed);
		rim.transform.localScale = new Vector3 (size, size, size);
		core.transform.Rotate (0f, 0f, Time.deltaTime * rotateSpeed);
	}

	public void Initialize () {
		isActive = true;
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, 0f);
		this.transform.localPosition = new Vector3(0f, 0f, 0f);
		core.SetActive (true);
		rim.SetActive (true);
		particle.SetActive (false);
	}

	private void OnClickHandler (int clicks) {
		if (_enlargeRoutine == null) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0f, yVelocity);
			_enlargeRoutine = StartCoroutine(EnlargeRoutine ());
		}
	}	

	private IEnumerator EnlargeRoutine () {
		_currentSize = rimMaxSize;
		yield return new WaitForSeconds(retainTime);
		_currentSize = rimMinSize;
		_enlargeRoutine = null;
	}

	private void TerminateHandler () {
		if (isActive) {
			isActive = false;
			core.SetActive (false);
			rim.SetActive (false);
			particle.SetActive (true);
		}
	}

}
