using UnityEngine;
using System.Collections;

public class Pistol : Weapon 
{
	public Transform muzzleTransform; 
	Transform weaponTransform ;


	void Start()
	{
		weaponTransform = GetComponent<Transform>();
	}

	public override void Fire()
	{

		Transform cameraTransform = Camera.main.transform;
		Ray ray = new Ray(cameraTransform.position + cameraTransform.forward, cameraTransform.forward);
		RaycastHit hitInfo = new RaycastHit();

		if (Physics.Raycast(ray, out hitInfo, range))
		{
			// It's a hit!
			Health health = hitInfo.collider.GetComponent<Health>();
			if (health)
			{
				hitInfo.rigidbody.AddExplosionForce(100f, hitInfo.point, 1f);
				health.TakeDamage(damage);
				VFXManager.instance.Spawn ("BloodSplatter", hitInfo.point, Quaternion.identity);
			}
			else
			{
				VFXManager.instance.Spawn ("Splatter",hitInfo.point, Quaternion.identity);
			}
		}

		VFXManager.instance.Spawn ("MuzzleFlare", muzzleTransform.position, muzzleTransform.rotation);
	}

    public override void Ironsight(bool active)
    {
		Transform cameraTransform = Camera.main.transform;
		if(active)
		{
			this.transform.position = cameraTransform.position + weaponTransform.position;
		}
		else
		{
			this.transform.position = weaponTransform.position ;
		}
    }
}















