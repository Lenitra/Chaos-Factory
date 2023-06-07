using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendBtn : MonoBehaviour
{
    public GameObject matPrefab;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(BoutonClique);
    }

    void BoutonClique()
    {
        gameManager.GetComponent<GameManager>().orderMonster(matPrefab);
        Debug.Log("SendBtn clicked");
    }


}
