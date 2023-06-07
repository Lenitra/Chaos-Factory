using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGui : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject sendPanel;
    public GameObject shopPanel;
    

// region Gestion des panels
    public void hideAll(){
        upgradePanel.SetActive(false);
        sendPanel.SetActive(false);
        shopPanel.SetActive(false);
    }


    public void UpgradePanel(){
        if (upgradePanel.activeSelf == true){
            hideAll();
            return;
        }
        hideAll();
        upgradePanel.SetActive(true);
    }


    public void SendPanel(){
        if (sendPanel.activeSelf == true){
            hideAll();
            return;
        }
        hideAll();
        sendPanel.SetActive(true);
    }


    public void ShopPanel(){
        if (shopPanel.activeSelf == true){
            hideAll();
            return;
        }
        hideAll();
        shopPanel.SetActive(true);
    }
    
// 

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            hideAll();
        }
        // On click outside of the panel
        // if(Input.GetMouseButtonDown(0) && Input.mousePosition.y > 1000){
        //     hideAll();
        // }
    }

}
