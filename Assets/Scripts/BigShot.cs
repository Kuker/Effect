using UnityEngine;
using System.Collections;

public class BigShot : Shot {

    public float damage;
    public float maxDamage = 60f;


    void Start()
    {
        damage = 0f;
    }

    public override void Damage()
    {
        base.Damage();
        currentTarget.TakeDamage(damage);
    }
}
