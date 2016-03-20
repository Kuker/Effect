using UnityEngine;
using System.Collections;

public class EnemyBig : Enemy
{


    // Use this for initialization
    public override void Start()
    {
        base.Start();
        Health = 200f;
        MaxHealth = 200f;
        Damage = 15f;
        Score = 100;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}
