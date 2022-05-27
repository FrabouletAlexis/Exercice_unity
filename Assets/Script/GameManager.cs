using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BattleManger battleManager;
    public GameObject enemy;
    public GameObject player;
    public GameObject textVictoire;
    public GameObject textDead;

    //private bool gameOver = false;
    //private bool contre = false;



    void Start()
    {

    }

    void Update()
    {
        //Defait();
       
    }

    private void Defait()
    {
        if  (player.GetComponent<Player>().playerPv < 0)
        {
            textDead.SetActive(true);
        }
        else if (enemy.GetComponent<Ennemi>().inLife == false)
        {
            textVictoire.SetActive(true);
        }
    }
}
