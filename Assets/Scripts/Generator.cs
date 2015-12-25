using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public bool isEnable;
	public float interval;
	public GameObject[] generators;
	public GameObject[] prefabs;
	public float speed;
	public int minScale;
	public int maxScale;

	private float _time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnable) {
			_time += Time.deltaTime;
			if (_time > interval) {
				int pos = Random.Range (0, generators.Length);
				GameObject block = Instantiate (prefabs [pos], generators [pos].transform.position, Quaternion.identity) as GameObject;
				block.GetComponent<Block> ().Initialize(speed, Random.Range(minScale, maxScale+1));
				_time = 0f;
			}
		}
	}


}
