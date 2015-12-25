using UnityEngine;
using System.Collections;

/// <summary>
/// A simple script to handle input from Makey Makey Go.
/// Supports detecting multiple delayed clicks (eg. detect N clicks).
/// 
/// Author: Hao Fu
/// Created: 12/23/2015
/// 
/// How to Use This?
/// 
/// Set up the parameters for this script.
/// Regesiter for the MakeyGoInput.onClicks event in your behavior.
/// 
/// Example:
/// 
/// void MyHandler (int clicks) {
/// 	// clicks is the number of clicks detected
/// }
/// 
/// MakeyGoInput.onClicks += MyHandler;		// in Start() or Awake()
/// 
/// </summary>
public class MakeyGoInput : MonoBehaviour {

	//
	// enum
	//

	/// <summary>
	/// Input mode based on Makey Makey Go.
	/// </summary>
	public enum MODE {
		NONE,				// detect noting
		SPACE,				// keyboard space bar
		CLICK,				// mouse left click
		EITHER				// either one will do the trick!
	}

	//
	// public variables
	//

	/// <summary>
	/// Master watchdog for clicks detetion.
	/// </summary>
	public bool isEnable = true;
	/// <summary>
	/// Debug mode flag.
	/// </summary>
	public bool isDebug = false;
	/// <summary>
	/// Mode for input.
	/// </summary>
	public MODE mode = MODE.EITHER;
	/// <summary>
	/// If only detect single click.
	/// </summary>
	public bool isSingleClick = false;
	/// <summary>
	/// Time coroutine will wait for next click input.
	/// </summary>
	public float inputDelayTime = 0.2f;

	//
	// private variables
	//

	/// <summary>
	/// Current delay time updated by coroutine.
	/// </summary>
	private float _currentDelayTime = 0f;
	/// <summary>
	/// Count of clicks accumulated.
	/// </summary>
	private int _clickCount = 0;
	/// <summary>
	/// Handle for delay coroutine.
	/// </summary>
	private Coroutine _clickDelayedRoutine = null;

	//
	// delegates and event
	//

	/// <summary>
	/// On click delegate with number of clicks injected.
	/// </summary>
	public delegate void OnClicks (int clicks);

	/// <summary>
	/// Occurs when clicks detection finished.
	/// </summary>
	public static event OnClicks onClicks;

	//
	// Unity functions
	//

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () {
		// check click event routine
		if (isEnable) {
			ClickRoutine ();
		}
	}

	//
	// private routines
	//

	/// <summary>
	/// Click detection loop in Update().
	/// Fire click detection coroutine.
	/// </summary>
	private void ClickRoutine () {
		bool is_click = false;
		// switch mode
		switch (mode) {
		case MODE.NONE:
			break;
		case MODE.SPACE:
			if (Input.GetKeyDown(KeyCode.Space)) {
				is_click = true;
			}
			break;
		case MODE.CLICK:
			if (Input.GetKeyDown(KeyCode.Mouse0)) {
				is_click = true;
			}
			break;
		case MODE.EITHER:
			if (Input.GetKeyDown(KeyCode.Space) ||
				Input.GetKeyDown(KeyCode.Mouse0)) {
				is_click = true;
			}
			break;
		default:
			break;
		}
		// check click detection
		if (is_click) {
			if (isSingleClick) {
				// only detect single click, just fire
				if (onClicks != null) {
					_clickCount = 1;
					onClicks(_clickCount);
					_clickCount = 0;
				}
				// debug
				if (isDebug) {
					Debug.Log ("Single click: 1");
				}
			} else {
				if (_clickDelayedRoutine == null) {
					// if delay routine is null, start a new one
					_currentDelayTime = inputDelayTime;
					_clickCount = 1;
					_clickDelayedRoutine = StartCoroutine(ClickDelayedRoutine());
				} else {
					// reset delay time and click count
					_currentDelayTime = inputDelayTime;
					_clickCount += 1;
				}
			}
		}
	}

	/// <summary>
	/// Click detection routine.
	/// Wait for delayed click input.
	/// </summary>
	/// <returns>The delayed routine.</returns>
	private IEnumerator ClickDelayedRoutine () {
		// wait for delay tiem to run out
		while (_currentDelayTime > 0f) {
			_currentDelayTime -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		// debug
		if (isDebug) {
			Debug.Log ("Multiple clicks: " + _clickCount);
		}
		// call event
		if (onClicks != null) {
			onClicks(_clickCount);
			_clickCount = 0;
		}
		// recycle
		_clickDelayedRoutine = null;
	}

}
