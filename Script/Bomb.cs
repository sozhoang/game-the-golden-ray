using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float cdTime;
    public int points;
    public int damage;
    public int numfire;
    public float radius;

    public GameObject Exploition;
    public GameObject Fire;
    public Database data;

    private void Start()
    {
        cdTime = data.bomb.cdTime;
        points = data.bomb.points;
        damage = data.bomb.damage;
        numfire = data.bomb.numFire;
        radius = data.bomb.radius;
    }

    private void Update()
    {
        if (cdTime < 0)
        {
            AudioManager.Instance.PlaySFX("Bomb");
            Bang();
        }
        else
            cdTime -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LoveConnectLine")
        {
            data.score += points;
            AudioManager.Instance.PlaySFX("Bomb");
            Instantiate(Exploition, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.tag == "Man" || collision.tag == "Woman")
        {
            FindObjectOfType<ControlForMan>().GetComponent<ControlForMan>().helth -= damage;
            AudioManager.Instance.PlaySFX("Hurt");
            Bang();
        }
    }
    void Bang()
    {
        Instantiate(Exploition, transform.position, Quaternion.identity);
        while (numfire > 0)
        {
            Instantiate(Fire, transform.position + new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0), Quaternion.identity);
            numfire--;
            AudioManager.Instance.PlaySFX("Bomb");
            Destroy(this.gameObject);
        }
    }    
}
