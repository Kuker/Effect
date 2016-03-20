using UnityEngine;
using System.Collections;

public class EnemySmall : Enemy {

	// Use this for initialization
	public override void Start () {
        base.Start();
        Health = 25f;
        MaxHealth = 25f;
        Damage = 5f;
        Score = 20;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}
}
