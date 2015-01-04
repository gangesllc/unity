using UnityEngine;
using System.Collections;

public class spawnBox : MonoBehaviour {

	public float leftEdge;
	public float rightEdge;
	float random;

	// Use this for initialization
	void Start () {
		Debug.Log ( "Spawn Box Started" );
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey ("left")) 
		{
			gameObject.transform.Translate ( -.2f, 0, 0);
		}

		if (Input.GetKey ("right")) 
		{
			gameObject.transform.Translate ( .2f, 0, 0);
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject go;
		//GameObject goD;
		go = coll.gameObject;
		random = Random.Range ( leftEdge , rightEdge);
		//goD = Instantiate (go, new Vector3(random,7f,0f), Quaternion.identity) as GameObject;
		Instantiate (go, new Vector3 (random, 7f, 0f), Quaternion.identity);
		Destroy (go);

		//Move the object to the side

		//goD.transform.Translate ( 5f,0f,0f);
	
	}
}
