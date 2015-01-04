using UnityEngine;
using System.Collections;

public class changeLevel : MonoBehaviour {

	public void change( string scene)
	{
		if (scene == "quit") 
		{
			print ("quit ");
			Application.Quit ();
		}
		else
			Application.LoadLevel (scene);
	}
}
