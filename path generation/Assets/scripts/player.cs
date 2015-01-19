using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit rhit = new RaycastHit();
		Physics.Raycast (gameObject.transform.position,Vector3.down * 20, out rhit);
		Debug.DrawRay ( gameObject.transform.position, Vector3.down * 20 );
		if ( rhit.collider !=null )
		{
			print ("objects hit are " + rhit.collider.name);
			rhit.collider.transform.parent.tag = "current";
			print ("object's parent is " + rhit.collider.transform.parent.name);
		}
	}
}
