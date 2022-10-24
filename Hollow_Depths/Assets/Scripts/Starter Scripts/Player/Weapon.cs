using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Alignment
    {
        Player,
        Enemy,
        Environment
    }

    public enum WeaponType
    {
        Melee,
        Ranged
    }

    public Alignment alignmnent = Alignment.Player;
    public WeaponType weaponType = WeaponType.Melee;

    public int damageValue;

    [Header("IF MELEE WEAPON")]
    public Collider2D collider;

    [Header("IF RANGED WEAPON")]
    public GameObject projectile;
    public Vector2 direction;
    public float force = 100f;
    public float duration = 10f;
    public Transform shootPosition;



    public bool flipWeapon = false;

    public void WeaponStart()
    {
        collider.enabled = true;
    }

    public void WeaponFinished()
    {
        collider.enabled = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnValidate()
    {
        direction = direction.normalized;
    }










}
