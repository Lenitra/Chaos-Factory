using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject convoyeur;
    public GameObject convoyeurad;
    public GameObject convoyeurag;
    public GameObject pathParent;
    private int nbConvoyeur = 50;
    private int previousDirection;
    private int x = 0;
    private int y = 0;
    private string coords = "0,0;";
    private int antiLoop = 10;

    public GameObject marteau;
    public GameObject turret;

    


    void Awake()
    {
        setPath();
        // while (antiLoop >= 10)
        // {
        // }
        placeConvoyeurs();
    }


    void setPath(){
        // génération du chemin
        antiLoop = 0;
        for (int i = 0; i < nbConvoyeur; i++)
        {
            
            // choisir une direction aléatoire avec une préférence pour la direction précédente
            int direction = Random.Range(0, 100);
            if (direction < 25)
            {
                direction = previousDirection;
            }
            else
            {
                direction = Random.Range(0, 4);
            }

            if (direction == 0  && !alreadyExists(x, y + 1))
            {
                y++;
                coords += x + "," + y + ";";
                previousDirection = 0;
            }
            else if (direction == 1 && !alreadyExists(x, y - 1))
            {
                y--;
                coords += x + "," + y + ";";
                previousDirection = 1;
            }
            else if (direction == 2  && !alreadyExists(x + 1, y))
            {
                x++;
                coords += x + "," + y + ";";
                previousDirection = 2;
            }
            else if (direction == 3 && !alreadyExists(x - 1, y))
            {
                x--;
                coords += x + "," + y + ";";
                previousDirection = 3;
            }
            else
            {
                i--;
                antiLoop++;
            }

            if (antiLoop > nbConvoyeur)
            {
                break;
            }
            
        }
        // delete the last ";" in coords
        coords = coords.Remove(coords.Length - 1);
    }

    void placeConvoyeurs()
    {
        GameObject newConvoyeur;
        int coordx;
        int coordy;
        int precoordx;
        int precoordy;
        int nextcoordx;
        int nextcoordy;
        // loop through all coords.split(";")
        Debug.Log(coords);
        Debug.Log("coords.split.length = " + coords.Split(';').Length);
        for (int i = 0; i < coords.Split(';').Length; i++)
        {

            coordx = int.Parse(coords.Split(';')[i].Split(',')[0]);
            coordy = int.Parse(coords.Split(';')[i].Split(',')[1]);
            
            Debug.Log("i = " + i);
            Debug.Log("coordx = " + coordx);
            Debug.Log("coordy = " + coordy);

            // Premier convoyeur
            if (coordx == 0 && coordy == 0){
                nextcoordy = int.Parse(coords.Split(';')[i + 1].Split(',')[1]);
                newConvoyeur = Instantiate(convoyeur, new Vector3(0, 0, 0), Quaternion.identity);
                newConvoyeur.transform.parent = pathParent.transform;
                if (nextcoordy == 0)
                {
                    newConvoyeur.transform.Rotate(0, 90, 0);
                }
            }

            // Dernier convoyeur (placer une tourelle)
            else if ( i == coords.Split(';').Length - 1){
                newConvoyeur = Instantiate(turret, new Vector3(coordx, 1, coordy), Quaternion.identity);
            }


            else {

                precoordx = int.Parse(coords.Split(';')[i - 1].Split(',')[0]);
                precoordy = int.Parse(coords.Split(';')[i - 1].Split(',')[1]);
                nextcoordx = int.Parse(coords.Split(';')[i + 1].Split(',')[0]);
                nextcoordy = int.Parse(coords.Split(';')[i + 1].Split(',')[1]);

                // Si ligne droite horizontale
                if (precoordx == coordx && nextcoordx == coordx){
                    newConvoyeur = Instantiate(convoyeur, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                }
                // Si ligne droite verticale
                else if(nextcoordy == coordy && coordy == precoordy){
                    newConvoyeur = Instantiate(convoyeur, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.Rotate(0, 90, 0);    
                    newConvoyeur.transform.parent = pathParent.transform;
                }

                // TODO: rotation
                else if (precoordy > coordy && precoordx == coordx && nextcoordy == coordy && nextcoordx > coordx){
                    newConvoyeur = Instantiate(convoyeurag, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                } 
                else if (precoordy == coordy && precoordx > coordx && nextcoordy > coordy && nextcoordx == coordx){
                    newConvoyeur = Instantiate(convoyeurad, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                    newConvoyeur.transform.Rotate(0, 180, 0);
                } 
                else if (precoordx == coordx && precoordy < coordy && nextcoordx > coordx && nextcoordy == coordy){
                    newConvoyeur = Instantiate(convoyeurad, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                    newConvoyeur.transform.Rotate(0, -90, 0);
                }
                // TODO: rotation
                else if(precoordx > coordx && precoordy == coordy && nextcoordx == coordx && nextcoordy < coordy){
                    newConvoyeur = Instantiate(convoyeurag, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                }
                else if (precoordy > coordy && precoordx == coordx && nextcoordy == coordy && nextcoordx < coordx){
                    newConvoyeur = Instantiate(convoyeurad, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                    newConvoyeur.transform.Rotate(0, 90, 0);
                } 
                // TODO: rotation
                else if (precoordy == coordy && precoordx < coordx && nextcoordy > coordy && nextcoordx == coordx){
                    newConvoyeur = Instantiate(convoyeurag, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                } 
                // TODO: rotation
                else if (precoordx == coordx && precoordy < coordy && nextcoordx < coordx && nextcoordy == coordy){
                    newConvoyeur = Instantiate(convoyeurag, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                }

                else if (precoordx < coordx && precoordy == coordy && nextcoordx == coordx && nextcoordy < coordy){
                    newConvoyeur = Instantiate(convoyeurad, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                    // newConvoyeur.name = "AAAAAAAAAAAA";
                }




                else {
                    newConvoyeur = Instantiate(convoyeurag, new Vector3(coordx, 0, coordy), Quaternion.identity);
                    newConvoyeur.transform.parent = pathParent.transform;
                }

            

            }
        }
    }
    

    void placeMachines(){
        // get a random point in coords
        int random = Random.Range(0, coords.Split(';').Length);
        int coordx = int.Parse(coords.Split(';')[random].Split(',')[0]);
        int coordy = int.Parse(coords.Split(';')[random].Split(',')[1]);
        if (!alreadyExists(coordx+1, coordy)){
            Instantiate(turret, new Vector3(coordx+1, 0, coordy), Quaternion.identity);
        }
        else if (!alreadyExists(coordx-1, coordy)){
            Instantiate(turret, new Vector3(coordx-1, 0, coordy), Quaternion.identity);
        }
        else if (!alreadyExists(coordx, coordy+1)){
            Instantiate(turret, new Vector3(coordx, 0, coordy+1), Quaternion.identity);
        }
        else if (!alreadyExists(coordx, coordy-1)){
            Instantiate(turret, new Vector3(coordx, 0, coordy-1), Quaternion.identity);
        }

    }


    bool alreadyExists(int x, int y)
    {
        if (coords.Contains(x + "," + y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}


