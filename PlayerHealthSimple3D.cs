using UnityEngine;

public class PlayerHealthSimple3D : MonoBehaviour
{
	public int startingHealth = 5;
	private int currentHealth;

	void Start()
	{
		currentHealth = startingHealth;
		UpdateUI();
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;

		if (currentHealth <= 0)
		{
			if (GameManager3D.Instance != null)
				GameManager3D.Instance.Lose();

			GetComponent<PlayerMovementFPS>().enabled = false;

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		UpdateUI();
	}

	void UpdateUI()
	{
		if (GameManager3D.Instance != null)
			GameManager3D.Instance.UpdateHealthUI(currentHealth, startingHealth);
	}
}