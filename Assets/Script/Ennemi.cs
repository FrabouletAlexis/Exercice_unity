using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public Transform ennemi;

    public List<Transform> positionList = new List<Transform>();
    public Collider2D player;
    public GameObject eclaire;
    public GameObject joueur;

    public GameObject textVictoire;

    private float time;
    public float speed = 2f;
    private bool atk = false;
    private int index = 0;
    public float enemyPv = 10;
    public bool inLife = true;

    private bool atoucher = false;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        Debug.Log(enemyPv);
        LifeCheck();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            StartCoroutine(EnemyStop());
        }
        else
        {
            speed = speed * -1;
        }
       /* if (joueur.GetComponent<Player>().contre == true)
        {
            enemyPv = enemyPv - 5;
            
        }*/
        
    }

    public IEnumerator EnemyStop()
    {

        float time = 0.0f;
        while (time < 2.0f)
        {
            if (time < 1.0f)
            {
                speed = 0.0f;
                eclaire.SetActive(true);

            }

            else if (!ennemi.GetComponent<Collider2D>().IsTouching(player) && atoucher == false)
            {
                if (player.gameObject.transform.position.x > ennemi.position.x)
                {
                    speed = -3f;
                }
                else
                {
                    speed = 3f;
                }
                
                atoucher = true;
                eclaire.SetActive(false);
            }

            else if (ennemi.GetComponent<Collider2D>().IsTouching(player) )
            {
                speed = 0.1f;

               /* if (joueur.GetComponent<Player>().contre == true)
                {
                    joueur.GetComponent<Player>().playerPv = joueur.GetComponent<Player>().playerPv - 5;
                }*/
                
            }

            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (time >= 2.0f)
        {
            speed = -2f;
            atoucher = false;
        }

    } 

    private void LifeCheck()
    {
        if (enemyPv <= 0)
        {
            inLife = false;
            Destroy(this);
            textVictoire.SetActive(true);
        }
    }
    IEnumerator Avance(float duree)
    {
        time = 0f;
        speed = 1f;
        while (true)
        {
        
            if (index == 1)
            {
                speed = 3f;
                atk = true;

            }
            else
            {
                speed = 1f;
                atk = false;
                
            }
           
            ennemi.position = Vector2.Lerp(positionList[index].position, positionList[index + 1].position, time);
            time += Time.deltaTime* speed;
            yield return null;


            if (time >= duree && index !=3)
            {
                time = 0;
                index++;
                if (index == 2)
                {
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    yield return new WaitForSeconds(duree);
                }
                
            }

            if (index == 3)
            {
                index = 0;
            }

        }

    }
}
