using UnityEngine;
using System.Collections;

public class terrainObject : MonoBehaviour {


	public terrainObject self;
	public terrainObject front;
	public terrainObject back;
	public terrainObject left;
	public terrainObject right;

	public void setSelf(GameObject go ) 
	{
		self = go ;
	}

	/* Gets the front game object associated with the current game object
	 * 
	 */	
	public getFront()
	{
		
	}
	
	/* Gets the back game object associated with the current game object
	 * 
	 */
	public getBack()
	{
	}
	
	/* Gets the right game object associated with the current game object
	 * 
	 */
	public getRight()
	{
	}
	
	/* Gets the left game object 
	 * 
	 */
	public getLeft()
	{
	}

}
