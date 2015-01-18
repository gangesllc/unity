using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	//The size of the pyramid maze. Assume its a cube.
	public int pyramidSize;

	//This is the maximum sizes the path can go for any given section randomly.
	public int x;
	public int y;
	public int z;

	private int[,,] cube;

	// Use this for initialization
	void Start () {

		cube = new int[pyramidSize, pyramidSize, pyramidSize];
		for (int i = 0; i < cube.GetLength(0); i++) // represents x
			for (int j = 0; j < cube.GetLength(1); j++) // represents y
				for (int k = 0; k < cube.GetLength(2); k++)
					{
						cube[i,j,k] = Random.Range (0,2);
					}

		for (int i = 0; i < cube.GetLength(0); i++)
			for (int j = 0; j < cube.GetLength(1); j++)
				for (int k = 0; k < cube.GetLength(2); k++)
					{
						print ( "cube["+i+","+j + "," + k + "]" + cube[i,j,k]);
						if ( cube[i,j,k] == 1 )
						{
							GameObject cu = GameObject.CreatePrimitive(PrimitiveType.Cube);
							cu.transform.Translate (new Vector3(i,j,k));
						}
					}



	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
