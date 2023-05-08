using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FamilyHealthBar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float damagePerSecond = 8f;
    public float replenishHealth = 10f;
    public float replenishDuration = 1f;
    public float reductionDuration = 1f;
    private float replenishAmountPerSecond; 

    private Coroutine replenishCoroutine; 


    public Image healthBar;

    private Coroutine damagePerSecondCoroutine;
    private Coroutine damage;

    // Start is called before the first frame update
    void Start()
    {

        healthBar.fillAmount = 1f;
        damagePerSecondCoroutine = StartCoroutine(DamagePerSecond());
        damage= StartCoroutine(Damage());
    }

    // Update is called once per frame
    void Update()
    {
       /*
        if (health <= 0f)
        {
           Die();
        }
       */

        if (health <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


    void Die()
    {
        Debug.Log("Your family is dead.");
    }

    IEnumerator DamagePerSecond()
    {

        float elapsedTime = 0f;
        float damagedAmount = 0f;

        while (elapsedTime < reductionDuration)
        {
            damagedAmount +=
            health -= damagePerSecond * Time.deltaTime;
            healthBar.fillAmount = health / maxHealth;
            yield return null;

        }

    }

    IEnumerator Damage()
    {
        float elapsedTime = 0f;
        float damagedAmount = 0f;
        float damageAmountPerSecond = damagePerSecond / reductionDuration;

        while (elapsedTime < reductionDuration)
        {
            damagedAmount += damageAmountPerSecond * Time.deltaTime;
            health -= damageAmountPerSecond * Time.deltaTime;
            health = Mathf.Clamp(health, 0f, maxHealth);
            healthBar.fillAmount = health / maxHealth;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void Heal()
    {

        replenishAmountPerSecond = replenishHealth / replenishDuration;

        // Start the replenish coroutine if it's not running already
        if (replenishCoroutine == null)
        {
            replenishCoroutine = StartCoroutine(ReplenishHealthOverTime());
        }

    }

    IEnumerator ReplenishHealthOverTime()
    {
        float replenishedAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < replenishDuration)
        {
            replenishedAmount += replenishAmountPerSecond * Time.deltaTime;
            health += replenishAmountPerSecond * Time.deltaTime;
            health = Mathf.Clamp(health, 0f, maxHealth);
            healthBar.fillAmount = health / maxHealth;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the coroutine reference
        replenishCoroutine = null;
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("heal"))
        {
             Heal();
         }
     }*/
}
