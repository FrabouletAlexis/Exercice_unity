using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode left, right, up, contre, garde;
    public Player player;

    //private bool protecte = false;
    
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(left) && player.GetComponent<Player>().dead == false)
        {
            player.Move(Vector2.left);

        }
        if (Input.GetKey(right) && player.GetComponent<Player>().dead == false)
        {
            player.Move(Vector2.right);

        }
        

       /* if (Input.GetKeyDown(contre))
        {
            
            player.LanceContre();

        }

        if (Input.GetKey(garde))
        {

            //player.LeveGarde();
            protecte = true;


        }*/

       // Debug.Log(protecte);
        /*if (Input.GetKeyUp(garde))
        {

            player.BaisseGarde();

        }*/

    }
}
