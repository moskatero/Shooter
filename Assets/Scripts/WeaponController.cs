using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{
	Weapon currentWeapon;
	
	void Start()
	{
		currentWeapon = GetComponentInChildren<Weapon>();
		Screen.lockCursor = true;
	}

	void Update()
	{
		if (currentWeapon)
		{
			if (Input.GetMouseButtonDown(0))
			{
				currentWeapon.Fire();
			}

			if(Input.GetMouseButtonDown(1))
			{
				currentWeapon.Ironsight(true);
			}

			if(Input.GetMouseButtonUp(1))
			{
				currentWeapon.Ironsight(false);
			}
		}
	}
}










