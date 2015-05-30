using UnityEngine;
using System.Collections;

public class VFXManager : MonoBehaviour 
{

	public static VFXManager instance;
	// Use this for initialization
	public GameObject[] effects;

	void Awake () 
	{
		instance = this;
	}

	public void Spawn(string _name, Vector3 position, Quaternion rotation)
	{
		foreach(GameObject fx in effects)
		{
			if(fx.name == _name)
			{
				Instantiate(fx, position,rotation);
				return;
			}
		}
		Debug.Log ("Cannot find effect: " + _name + " in manager");
	}
}
