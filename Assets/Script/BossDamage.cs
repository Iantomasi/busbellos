using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    public float healthDamage;
    public AudioClip hitSound;
    public AudioSource audioSource1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource1.clip = hitSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            var healthBar = GameObject.Find("HealthBar").GetComponent<FamilyHealthBar>();
            StartCoroutine(InflictDamageOverTime(healthBar));
            audioSource1.Play();
        }
    }

    IEnumerator InflictDamageOverTime(FamilyHealthBar healthBar)
    {
        float elapsedTime = 0f;
        float damagedAmount = 0f;
        float damageAmountPerSecond = healthDamage / healthBar.reductionDuration;

        while (elapsedTime < healthBar.reductionDuration)
        {
            damagedAmount += damageAmountPerSecond * Time.deltaTime;
            healthBar.health -= damageAmountPerSecond * Time.deltaTime;
            healthBar.health = Mathf.Clamp(healthBar.health, 0f, healthBar.maxHealth);
            healthBar.healthBar.fillAmount = healthBar.health / healthBar.maxHealth;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}
