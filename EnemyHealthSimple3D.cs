using UnityEngine;

public class EnemyHealthSimple3D : MonoBehaviour
{
	public int startingHealth = 2;
	private int currentHealth;

	void Start()
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);

		Invoke(nameof(CheckWin), 0.1f);
	}

	void CheckWin()
	{
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
		{
			if (GameManager3D.Instance != null)
				GameManager3D.Instance.Win();
		}
	}
}