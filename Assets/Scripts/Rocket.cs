using UnityEngine;
using System.Collections;

public class Rocket : Shot {

    float blastRadius = 10f;
    float damage = 5f;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = 20f * transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Damage()
    {
        base.Damage();

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            if (blastRadius >= Vector3.Distance(transform.position, enemy.transform.position))
            {
                enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

}
