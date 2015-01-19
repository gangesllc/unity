using UnityEngine;
using System.Collections;

public class pathDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		print ("destroyer started on " + gameObject.name);

		/* Don't check for the object's tag every update. Instead check every second
		 * through a repeating routine
		 * Start after 3 seconds and repeat every second. 
		 */
//		InvokeRepeating ("destroy", 5,5);
	}
	
	// Update is called once per frame
	void Update () {
		print ("destroyer update called");
		if ( gameObject.tag == "current" )
		{
			print ("became current - game object is " + gameObject.name);
			gameObject.tag = "ground";
			objectPooler.current.put (gameObject);
		}
		
	}

//	void destroy ()
//	{
//		print ("destroy called on " + gameObject.name);
//		// Put the object back to the pool after 3 seconds of being current
//		if ( gameObject.tag == "current" )
//		{
//			print ("tag for the current object is " + gameObject.tag);
//			Invoke("recycle", 3f); 
//		}
//
//	}

//	void recycle ()
//	{
//		print ("recycle called on " + gameObject.name);
//		print ("parent of current is " + gameObject.transform.parent.name);
//		objectPooler.current.put ( gameObject.transform.parent.gameObject );
//	}


}
