using UnityEngine;
using System.Collections;

public class MuteSound : MonoBehaviour {
	

	void Start ()
	{
	
	}

	void Awake() {
		//DontDestroyOnLoad(this.gameObject);
	}

	public void onClick()
	{
		if (AudioListener.pause == true) {
			AudioListener.pause = false;
			Debug.Log ("OUT");
		} 
		else if(AudioListener.pause == false)
		{
			AudioListener.pause = true;	
			Debug.Log ("ONN");
		}
	}
}
