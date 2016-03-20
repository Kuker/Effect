using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Effect : MonoBehaviour {

    public Image[] effectImages;
    public Image currentImage;
    public Text effectText;

    public List<Enemy> enemies;
    private GameObject[] enemiesGO;
    public PlayerController player;

    private List<string> effects;
    private int choosenEffectIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        effects = new List<string>(new string[] { "Happy Hunting", "Sudden Death", "Surprise" });
    }

    void Update()
    {
        enemies = GameObject.Find("Map").GetComponent<MapController>().enemies;
        if(Input.GetKeyDown(KeyCode.Space))
        switch (choosenEffectIndex)
        {
            case 0:
                SetHealthToOne();
                break;
            case 1:
                KillAllEnemies();
                break;
            case 2:
                Suicide();
                break;
        }
    }


	public void RandomEffect()
    {
        choosenEffectIndex = Random.Range(0, effects.Count - 1);
        currentImage.sprite = effectImages[choosenEffectIndex].sprite;
        effectText.text = effects[choosenEffectIndex];
        Debug.Log("Chosen effect: " + effects[choosenEffectIndex]);
    }

    void SetHealthToOne()
    {
        foreach(var enemy in enemies)
        {
            enemy.Health = 1;
        }
        player.Health = 1;
    }
    void Suicide()
    {
        player.Die();
    }

    void KillAllEnemies()
    {
        foreach(var enemy in enemies)
        {
            enemy.Die();
        }
        enemies.Clear();
    }
}
