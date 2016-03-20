using UnityEngine;
using System.Collections;

public class SmallShot : Shot {

    private float damage = 10f;
    private float speed = 40f;


    void Start()
    {
        GetComponent<Rigidbody>().velocity = speed * transform.forward;
    }

    public override void Damage()
    {
        base.Damage();

        currentTarget.TakeDamage(damage);
    }


}
