using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class applicationControl : MonoBehaviour {


	public Text pauseResumeText;
	

	public void pauseResumeGame()
	{

		if (pauseResumeText.text == "Pause") 
		{
			pauseResumeText.text = "Resume";
			Time.timeScale = 0;

		}
		else if (pauseResumeText.text == "Resume") 
		{
			pauseResumeText.text = "Pause";
			Time.timeScale = 1;

		}
	}

}
