using UnityEngine;

public class GunRaycastSimple : MonoBehaviour
{
	public float fireRate = 0.3f;
	public float maxDistance = 50f;

	private float nextFireTime = 0f;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
		{
			nextFireTime = Time.time + fireRate;
			Fire();
		}
	}

	void Fire()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, maxDistance))
		{
			EnemyHealthSimple3D enemy =
				hit.collider.GetComponentInParent<EnemyHealthSimple3D>();

			if (enemy != null)
				enemy.TakeDamage(1);

			Debug.DrawLine(ray.origin, hit.point, Color.red, 0.2f);
		}
	}
}