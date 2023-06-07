using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector3 spawnPoint = new Vector3(0, 2.3f, 0);
    // public GameObject[] monsterPrefabs;

    // public UIManager UIManager;

    private GameObject monsterList;
    private GameObject turretList;

    public GameObject[] spawnOrder;

    private float rythm = 0.5f;
    private float tmpRythm;


    void spawnMonster(){
        
        // instantiate the first element of spawnOrder
        GameObject materiau = spawnOrder[0];

        materiau = Instantiate(materiau, spawnPoint, Quaternion.identity);
        materiau.transform.parent = monsterList.transform;

    

        // remove the first element of spawnOrder
        GameObject[] tmp = spawnOrder.Clone() as GameObject[];
        spawnOrder = new GameObject[spawnOrder.Length - 1];
        for (int i = 0; i < spawnOrder.Length; i++)
        {
            spawnOrder[i] = tmp[i + 1];
        }
    }


    // appelée lors d'un appui sur un bouton
    public void orderMonster(GameObject materiau){
        // add materiau to the end of spawnOrder
        GameObject[] tmp = spawnOrder.Clone() as GameObject[];
        spawnOrder = new GameObject[spawnOrder.Length + 1];
        for (int i = 0; i < spawnOrder.Length - 1; i++)
        {
            spawnOrder[i] = tmp[i];
        }
        spawnOrder[spawnOrder.Length - 1] = materiau;
    }


    void Update(){
        tmpRythm += Time.deltaTime;
        if (tmpRythm >= rythm)
        {
            tmpRythm = 0;
            if (spawnOrder.Length > 0){
                spawnMonster();
            }
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     // remove one pv to all monsters
        //     foreach (Transform monster in monsterList.transform)
        //     {
        //         monster.GetComponent<Monster>().takeDamage(10);
        //     }
        // }
    }


    void Awake()
    {
        monsterList = GameObject.Find("Monsters");
        turretList = GameObject.Find("Turrets");
        // UIManager = GameObject.Find("UI").GetComponent<UIManager>();
    }




}
