using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materiau : MonoBehaviour
{
    public int health = 100;
    public int healthMax = 100;

    // private bool isDead = false;
    private GameObject path;
    private int currentWaypoint = 0;
    private float speed = 2f;

    private float y = 2.3f;
    // private Coeur coeur;


    // public void updateHealth(){
    //     if (health < 0){
    //         health = 0;
    //     }
    //     // max size of health bar is the x size of the 2nd child of healthBar (this is the background)
    //     float maxsizex = healthBar.GetChild(1).localScale.x;
    //     // set the size of the health bar to the health/maxhealth * maxsizex
    //     float tmp = health * maxsizex / healthMax;
    //     healthBar.GetChild(0).localScale = new Vector3(tmp , healthBar.GetChild(0).localScale.y, healthBar.GetChild(0).localScale.z);
    //     // place the first child of healthBar (the red part) at the right place
    //     tmp = -maxsizex/2 + healthBar.GetChild(0).localScale.x/2;
    //     healthBar.GetChild(0).localPosition = new Vector3(tmp, healthBar.GetChild(0).localPosition.y, healthBar.GetChild(0).localPosition.z);
    // }

    IEnumerator death(){
        // change the parent of the gameobject 
        // transform.parent = GameObject.Find("dead").transform;
        // Animation de mort, le scale diminue jusqu'à 0
        while (transform.localScale.x > 0){
            transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            yield return new WaitForSeconds(0.25f);
        }
        Destroy(gameObject);
    }

    private void Awake()
    {
        path = GameObject.Find("Path");
        // coeur is the last child of the gameobject path
        // coeur = path.transform.GetChild(path.transform.childCount - 1).gameObject.GetComponent<Coeur>();

        // get Health in children
        // for (int i = 0; i < transform.childCount; i++){
        //     if (transform.GetChild(i).name == "Health"){
        //         healthBar = transform.GetChild(i);
        //     }
        // } 

    }


    public void takeDamage(int damage){
        health -= damage;
        // updateHealth();
    }



    void Update()
    {
        // Mouvement du minerai
        if (currentWaypoint < path.transform.childCount){
                Vector3 target = path.transform.GetChild(currentWaypoint).position;
                target.y = y;
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                
                if (transform.position == target){
                    currentWaypoint++;
                    
                }
            }

        // Arrivée à la fin du chemin
        else{
            StartCoroutine(death());
            if (health > 0){
                health = 0;
                // coeur.takeDamage(damage);
            }
        }

        if (health <= 0){
            StartCoroutine(death());
        }
        
    }

}
