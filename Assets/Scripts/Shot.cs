using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    
    protected Enemy currentTarget;
    public ParticleSystem explosion;


	// Use this for initialization
	void Start () {
       // GetComponent<Rigidbody>().velocity = speed * transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            currentTarget = other.GetComponent<Enemy>();
            Damage();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Environment")) Destroy(gameObject);
    }


    public virtual void Damage(){
    }
    
}
