using UnityEngine;
using System.Collections;

public class Shotgun : Weapon 
{
	public Transform muzzleTransform; 
	Transform weaponTransform;

	void Start()
	{
		weaponTransform = GetComponent<Transform>();
	}

	public override void Fire()
	{
		Transform cameraTransform = Camera.main.transform;
		Ray ray = new Ray(cameraTransform.position + cameraTransform.forward,
		                  cameraTransform.forward);
		RaycastHit hitInfo = new RaycastHit();
		if (Physics.Raycast(ray, out hitInfo, range))
		{
			// It's a hit!
			Health health = hitInfo.collider.GetComponent<Health>();
			if (health)
			{
				hitInfo.rigidbody.AddExplosionForce(100f, hitInfo.point, 1f);
				health.TakeDamage(damage);
			}
		}
	}

	public override void Ironsight(bool active)
	{
		Transform cameraTransform = Camera.main.transform;
		if(active)
		{
			this.transform.position = cameraTransform.position;
		}
		else
		{
			this.transform.position = weaponTransform.position;
		}
	}
}















