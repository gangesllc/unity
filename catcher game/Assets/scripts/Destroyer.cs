using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Debug.Log ( "Destroyer Started" );
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject go;
		go = coll.gameObject;
		Destroy (go);
		Application.LoadLevel ("GameOver");

	}
}
