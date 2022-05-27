using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.1f;
    public Transform body;
    
    public Transform attache;

    public GameObject panel;
    public GameObject textEnemy;
    public GameObject bouclier;
    public GameObject impact;

    public GameObject enemy;

    public GameObject textDefait;

    public bool contre = true;
    public bool invicible = false;
    public bool dead = false;

    public bool protection = false;
    public float playerPv = 10;



    public KeyCode left, right, up, down, space, garde;
    void Start()
    {
        // StartCoroutine(Protection());
    }

    void Update()
    {
        /*if (Input.GetKey(garde))
        {

          LeveGarde();

        }
        if (Input.GetKeyUp(garde))
        {

            BaisseGarde();

        }*/

        if (Input.GetKey(garde) && dead == false)
        {

            protection = true;
            bouclier.SetActive(true);

        }

        else
        {
            protection = false;
            bouclier.SetActive(false);
        }

        LifeCheck();
        Debug.Log(playerPv);

    }

    public void Move(Vector2 direction)
    {
        body.transform.Translate(direction * speed);
    }

    public void LanceContre()
    {
        contre = true;
        //StartCoroutine(Contre());

       // Debug.Log("Contre");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && dead == false)
        {
            if (!Input.GetKey(space))
            {
                contre = false;
            }
            
            StartCoroutine (QTE());

            if (protection == false && invicible == false)
            {
                playerPv = playerPv - 5;
                StartCoroutine(Hit());
            }


        }
    }

    public IEnumerator QTE()
    {
        float time = 0.0f;
       
        while (time < 1.0f)
        {
           // panel.SetActive(true);
            if (protection == true && Input.GetKey(space) && contre == false )
            {
                contre = true;
                textEnemy.SetActive(true);
                impact.SetActive(true);

                enemy.GetComponent<Ennemi>().enemyPv = enemy.GetComponent<Ennemi>().enemyPv - 5;
                enemy.GetComponent<SpriteRenderer>().color = Color.red;

            }

            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        if (time>= 0.2f)
        {
            impact.SetActive(false);
            enemy.GetComponent<SpriteRenderer>().color = new Color(108, 127, 146);
        }

       if (time>= 1.0f)
        {
            textEnemy.SetActive(false);

        }

    }

    public IEnumerator Hit()
    {
        float time = 0.0f;

        while (time < 1.0f)
        {
            
            invicible = true;

            GetComponent<SpriteRenderer>().color = Color.red;

            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        
        if (time >= 1.0f)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
            invicible = false;

        }
    }

    public void LifeCheck()
    {
        if (playerPv <= 0)
        {
            textDefait.SetActive(true);
            dead = true;
        }
    }

}
