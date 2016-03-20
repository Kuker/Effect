using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public ParticleSystem explosion;

    public Image healthImage;

    public float Health;
    public float MaxHealth;
    public float Damage;
    public float Speed;
    public int Score;

    public Animation anim;
    public PlayerController player;
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;

    // Use this for initialization
    public virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null) Debug.Log("target null");
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        agent.SetDestination(target.position);
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        healthImage.fillAmount = Health / MaxHealth;
        if (Health <= 0)
        {
            Die();
        }
    }
    public void Attack()
    {


        player.TakeDamage(Damage);
    }

    public virtual void Die()
    {
        player.score += Score;
        Instantiate(explosion, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }

    float timeElapsed = 1.1f;

    void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player")
        {
            anim.Play("robot_fallus|attack");
            anim.Play("Armature|attack");
            if (timeElapsed > 1.0f)
            {
                Attack();
                timeElapsed = 0;
            }

        }
        timeElapsed += Time.deltaTime;
    }

    void OnTriggerExit(Collider other)
    {

        anim.Play("robot_fallus|walk.001");
        anim.Play("Armature|walk.001");
        timeElapsed = 1.1f;
    }

}
