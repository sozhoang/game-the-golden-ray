using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public float speed;
    ControlForMan man;
    ControlForWoman woman;
    public int points;
    public float deltaTimeInsBomb;
    public int damage;
    public bool isInsBomb;
    
    public GameObject bomb;
    public GameObject deathMan;
    public GameObject deathLine;
    public Database data;
    void Start()
    {
        speed = data.enemies.speed;
        points = data.enemies.points;
        deltaTimeInsBomb = data.enemies.deltaTimeInsBomb;
        damage = data.enemies.damage;


        isInsBomb = true;
        man = FindObjectOfType<ControlForMan>();
        woman = FindObjectOfType<ControlForWoman>();
    }

    void Update()
    {
        if (deltaTimeInsBomb <= 0 && isInsBomb)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            isInsBomb=false;
        }
        else if (isInsBomb)
            deltaTimeInsBomb -= Time.deltaTime;

        Vector2 dis1 = new Vector2(man.transform.position.x - transform.position.x, man.transform.position.y - transform.position.y);
        Vector2 dis2 = new Vector2(woman.transform.position.x - transform.position.x, woman.transform.position.y - transform.position.y);
        if(dis1.magnitude < dis2.magnitude)
        {
            if (dis1.x < 0)
                transform.localScale = new Vector3(-0.15f,0.15f,1);
            else
                transform.localScale = new Vector3(0.15f, 0.15f, 1);
            transform.position = Vector2.MoveTowards(transform.position, man.transform.position, speed * Time.deltaTime);
        }    
        else
        {
            if (dis2.x < 0)
                transform.localScale = new Vector3(-0.15f, 0.15f, 1);
            else
                transform.localScale = new Vector3(0.15f, 0.15f, 1);
            transform.position = Vector2.MoveTowards(transform.position, woman.transform.position, speed* Time.deltaTime);
        }
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LoveConnectLine")
        {
            data.score += points;
            AudioManager.Instance.PlaySFX("Blood");
            Instantiate(deathLine, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.tag == "Man" || collision.tag == "Woman")
        {
            man.GetComponent<ControlForMan>().helth -= damage;
            AudioManager.Instance.PlaySFX("Hurt");
            Instantiate(deathMan,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }         
    }
}

