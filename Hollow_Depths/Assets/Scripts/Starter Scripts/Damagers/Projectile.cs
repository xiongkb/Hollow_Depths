using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float duration;
    Weapon.Alignment alignment;
    int damageValue;

    private void Start()
    {
        StartCoroutine(Duration());
    }

    public Projectile(float duration, Weapon.Alignment alignment, int damageValue)
    {
        this.duration = duration;
        this.alignment = alignment;
        this.damageValue = damageValue;
    }

    public void SetValues(float duration, Weapon.Alignment alignment, int damageValue)
    {
        this.duration = duration;
        this.alignment = alignment;
        this.damageValue = damageValue;
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

}
