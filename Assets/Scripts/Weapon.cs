using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour 
{
	public int damage;
	public float range;
		
	public abstract void Fire();
    public abstract void Ironsight(bool active);
}
