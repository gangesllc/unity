using UnityEngine;
using System.Collections;

public class pathCreator : MonoBehaviour {

	// How far around the player do we need to create the path
	public GameObject prefab;
	private GameObject ground; 

	// Use this for initialization
	void Start () {
		// Get prefab
		ground = Instantiate (prefab, Vector3.up, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		ground.transform.Translate (Vector3.forward * Time.deltaTime);
	

	}
}
