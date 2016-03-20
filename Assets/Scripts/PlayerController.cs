using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject endGameText;
    public ParticleSystem explosion;
    public Slider healthSlider;
    //Player Stats
    public float Health = 100f;
    public int score;


    public Text scoreText; 
    Rigidbody playerRb;
    int floorMask;
    

    void Start()
    {
        endGameText.SetActive(false);
        playerRb = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }


    void Update()
    {
        Shooting();
        UpdateUI();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        Turning();

    }

    

    Vector3 movement;
    public float speed = 5.0f;

    void UpdateUI()
    {
        scoreText.text = score.ToString();
        healthSlider.value = Health;
    }
    void Move(float h, float v)
    {
        movement.Set(h, 0.0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRb.MovePosition(transform.position + movement);
        //transform.Translate(movement.x, y, movement.z);

    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRb.MoveRotation(newRotation);
        }
    }
    
    public float holdToFire = 1.5f;
    private float size = 0.1f;
    private float timeHold;
    public GameObject smallShot;
    public GameObject bigShot;
    private GameObject _bigShot;
    public GameObject rocket;
    public Transform smallShotSpawn1;
    public Transform smallShotSpawn2;
    public Transform bigShotSpawn;
    public Transform rocketSpawn;

    bool changeArm = false;
    void ShootSmall()
    {
        if (changeArm)
        {
            Instantiate(smallShot, smallShotSpawn1.position, smallShotSpawn1.rotation);
            changeArm = false;
        }
        else
        {
            Instantiate(smallShot, smallShotSpawn2.position, smallShotSpawn2.rotation);
            changeArm = true;
        }
    }
    void ShootBig(GameObject _bigShot)
    {
        if(_bigShot != null)
        _bigShot.GetComponent<Rigidbody>().velocity = 40 * bigShotSpawn.transform.forward;
    }

    private float distance = 50f;
    void ShootRocket() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 1000f, floorMask))
        {
            Vector3 SpawnToMouse = hit.point - rocketSpawn.position;
            Quaternion newRotation = Quaternion.LookRotation(SpawnToMouse);
            rocketSpawn.GetComponent<Rigidbody>().MoveRotation(newRotation);
            var rocketObject = (GameObject)Instantiate(rocket, rocketSpawn.position, rocketSpawn.rotation);
            Destroy(rocketObject, .5f);
        }
        //Debug.DrawRay(grenadeSpawn.position, grenadeSpawn.forward * 1000, Color.black);
    }


    float timeHolding = 1.0f;

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootSmall();
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            if (timeHolding <= 0)
            {
                ShootRocket();
                timeHolding = 1.0f;
            }
            
        }
        else if (Input.GetButton("Fire2"))
        {
            if ((timeHold == 0 || !_bigShot.activeSelf))
            {
                _bigShot = (GameObject)Instantiate(bigShot, bigShotSpawn.position, bigShotSpawn.rotation);

                
            }
            timeHold += Time.deltaTime;
            if (timeHold < holdToFire && _bigShot.activeSelf)
            {

                _bigShot.transform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
                if (_bigShot.GetComponent<BigShot>().damage < _bigShot.GetComponent<BigShot>().maxDamage)
                {
                    Debug.Log(timeHold.ToString() + " Damage: " + _bigShot.GetComponent<BigShot>().damage.ToString());

                    _bigShot.GetComponent<BigShot>().damage += 0.75f;
                }
            }
            _bigShot.GetComponent<Rigidbody>().MovePosition(bigShotSpawn.position);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            ShootBig(_bigShot);
            timeHold = 0;
            size = 0;
        }
        timeHolding -= Time.deltaTime;
    }


    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
            Die();
    }

    public void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        endGameText.SetActive(true);
        
    }

   
}
