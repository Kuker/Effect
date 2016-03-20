using UnityEngine;
using System.Collections;

public class EnemyNormal : Enemy {
    
    // Use this for initialization
	public override void Start () {
        base.Start();
        Health = 100f;
        MaxHealth = 100f;
        Damage = 8f;
        Score = 50;
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}
}
