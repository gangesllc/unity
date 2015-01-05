using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Destroyer : MonoBehaviour {


	public Text lifesText;
	private int lifes;
	public float leftEdge;
	public float rightEdge;
	float random;

	// Use this for initialization
	void Start () {
		Debug.Log ( "Destroyer Started" );
		lifesText.text = "AAAAA";
		lifes = lifesText.text.Length;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject go;
		go = coll.gameObject;
		random = Random.Range ( leftEdge , rightEdge);
		//goD = Instantiate (go, new Vector3(random,7f,0f), Quaternion.identity) as GameObject;
		Instantiate (go, new Vector3 (random, 7f, 0f), Quaternion.identity);
		if (lifes == 0) {
			Application.LoadLevel ("GameOver");
		} else {
			lifes -= 1;
			print ("lifes = " + lifes);
			lifesText.text = lifesText.text.Remove(lifes);
		}
		Destroy (go);


		// Get the lifes
		lifes = lifesText.text.Length;


	}
}
