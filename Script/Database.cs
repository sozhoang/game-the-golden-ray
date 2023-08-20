using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[CreateAssetMenu]
public class Database : ScriptableObject
{
    public Record[] RecordsList;

    public In4Man man;
    public In4Woman woman;
    public In4Enemies enemies;
    public In4Spawner spawner;
    public In4Bomb bomb;
    public In4Fire fire;

    public int score = 0;
    public float MusicVolume = 1;
    public float SFXVolume = 1;

       
    
    public void AddRecord(string name, int record)
    {
        Record tmp = new Record(name, record);
        for (int i = 0; i < RecordsList.Length; i++)
        {
            if (tmp.score > RecordsList[i].score)
            {
                for (int j = RecordsList.Length - 1; j > i; j--)
                {
                    RecordsList[j] = RecordsList[j - 1];
                }
                RecordsList[i] = tmp;
                return;
            } 
        }    
    }    
}

[System.Serializable]
public class Record
{
    public string name;
    public int score;
    public Record(string name, int score)
    {
        this.name = name;
        this.score = score;
    }

    public override string ToString()
    {
        return (name + " : " + score);
    }
}

[System.Serializable]
public class In4Man
{
    public int helth = 5;
    public float maxSpeed = 100;
    public float normalSpeed = 50;
}
[System.Serializable]
public class In4Woman
{
    public int helth = 4;
    public float maxSpeed = 100;
    public float normalSpeed = 50;
}
[System.Serializable]
public class In4Enemies
{
    public float speed = 1;
    public int points = 1;
    public float deltaTimeInsBomb = 4.5f;
    public int damage = 1;
}
[System.Serializable]
public class In4Spawner
{
    public float TimebtwSpawns= 1.5f;
    public int numEnemiesPerSpawns = 1;
    public float radius= 1f;
}

[System.Serializable]
public class In4Bomb
{
    public float cdTime = 2;
    public int points = 1;
    public int damage = 1;
    public int numFire = 3;
    public float radius = 2f;
}
[System.Serializable]
public class In4Fire
{
    public float lifeTime = 5f;
    public int damage = 1;
}

