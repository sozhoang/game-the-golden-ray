using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConnectDatabase : MonoBehaviour
{
    public Database data;

    public TMP_InputField man_ns;
    public TMP_InputField man_ms;
    public TMP_InputField man_h;

    public TMP_InputField woman_ns;
    public TMP_InputField woman_ms;
    public TMP_InputField woman_h;

    public TMP_InputField enemies_s;
    public TMP_InputField enemies_dtib;
    public TMP_InputField enemy_p;
    public TMP_InputField enemy_d;

    public TMP_InputField spawner_tbs;
    public TMP_InputField spawner_neps;
    public TMP_InputField spawner_r;

    public TMP_InputField bomb_cdt;
    public TMP_InputField bomb_r;
    public TMP_InputField bomb_p;
    public TMP_InputField bomb_d;
    public TMP_InputField bomb_nf;

    public TMP_InputField fire_lf;
    public TMP_InputField fire_d;
    void Start()
    {
        man_ns.text = data.man.normalSpeed.ToString();
        man_ms.text = data.man.maxSpeed.ToString();
        man_h.text = data.man.helth.ToString();

        woman_h.text = data.woman.helth.ToString();
        woman_ns.text = data.woman.normalSpeed.ToString();
        woman_ms.text = data.woman.maxSpeed.ToString();

        enemies_s.text = data.enemies.speed.ToString();
        enemy_d.text = data.enemies.damage.ToString();
        enemy_p.text = data.enemies.points.ToString();
        enemies_dtib.text = data.enemies.deltaTimeInsBomb.ToString();

        spawner_neps.text = data.spawner.numEnemiesPerSpawns.ToString();
        spawner_r.text = data.spawner.radius.ToString();
        spawner_tbs.text = data.spawner.TimebtwSpawns.ToString();

        bomb_cdt.text = data.bomb.cdTime.ToString();
        bomb_d.text = data.bomb.damage.ToString();
        bomb_nf.text = data.bomb.numFire.ToString();
        bomb_p.text = data.bomb.points.ToString();
        bomb_r.text = data.bomb.radius.ToString();

        fire_d.text = data.fire.damage.ToString();
        fire_lf.text = data.fire.lifeTime.ToString();
    } 
    
    public void Save()
    {
        data.man.normalSpeed = float.Parse(man_ns.text);
        data.man.maxSpeed = float.Parse(man_ms.text);
        data.man.helth = int.Parse(man_h.text);

        data.woman.helth = int.Parse(woman_h.text);
        data.woman.normalSpeed = float.Parse(woman_ns.text);
        data.woman.maxSpeed = float.Parse(woman_ms.text);

        data.enemies.speed = float.Parse(enemies_s.text);
        data.enemies.damage = int.Parse(enemy_d.text);
        data.enemies.points = int.Parse(enemy_p.text);
        data.enemies.deltaTimeInsBomb = float.Parse(enemies_dtib.text);

        data.spawner.numEnemiesPerSpawns = int.Parse(spawner_neps.text);
        data.spawner.radius = float.Parse(spawner_r.text);
        data.spawner.TimebtwSpawns = float.Parse(spawner_tbs.text);

        data.bomb.cdTime = float.Parse(bomb_cdt.text);
        data.bomb.damage = int.Parse(bomb_d.text);
        data.bomb.numFire =  int.Parse(bomb_nf.text);
        data.bomb.points = int.Parse(bomb_p.text);
        data.bomb.radius = float.Parse(bomb_r.text);

        data.fire.damage = int.Parse(fire_d.text);
        data.fire.lifeTime = float.Parse(fire_lf.text);
    }    
}
