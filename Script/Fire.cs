using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float lifeTime;
    public int damage;

    public Database data;

    public void Start()
    {
        lifeTime = data.fire.lifeTime;
        damage = data.fire.damage;
    }
    void Update()
    {
        if(lifeTime < 0)
            Destroy(this.gameObject);
        else
            lifeTime -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Man" || collision.tag == "Woman")
        {
            if (collision.tag == "Man" || collision.tag == "Woman")
            {
                FindObjectOfType<ControlForMan>().GetComponent<ControlForMan>().helth -= damage;
                AudioManager.Instance.PlaySFX("Hurt");
            }
        }
    }
}
