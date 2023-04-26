using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FamilyHealthBar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damagePerSecond = 8f;
    public float replenishHealth = 10f;

    public Image healthBar;

    private Coroutine damagePerSecondCoroutine;

    // Start is called before the first frame update
    void Start()
    {

        healthBar.fillAmount = 1f;
        damagePerSecondCoroutine = StartCoroutine(DamagePerSecond());
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
           Die();
        }
    }


    void Die()
    {
        Debug.Log("Your family is dead.");
    }

    IEnumerator DamagePerSecond()
    {
        while (true)
        {
            health -= damagePerSecond * Time.deltaTime;
            healthBar.fillAmount = health / maxHealth;
            yield return null;

        }

    }

    public void Heal()
    {

        health += replenishHealth;
        health = Mathf.Clamp(health, 0f, maxHealth);
        healthBar.fillAmount = health / maxHealth;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("heal"))
       {
            Heal();
        }
    }
}
