using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AnxietyEffect : MonoBehaviour
{

    public float playerAnxiety;
    public float playerAnxietyTotal;
    public Image anxietyImg;

    public Vector2 screenSize;
    public LayerMask enemyLayer;
    public LayerMask calmLayer;

    private int enemyInScreen;
    private bool increasing;
    private bool decreasing;

    public static AnxietyEffect Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else { Destroy(this); }
    }

    void Start()
    {
        playerAnxiety = 100;
    }

    void Update()
    {
        Debug.Log(enemyLayer.ToString());
        RaycastHit2D[] screen = Physics2D.BoxCastAll(transform.position, screenSize, 0, Vector2.zero, 0, enemyLayer);
        RaycastHit2D inEnemy = Physics2D.CircleCast(transform.position, 2, Vector2.zero, 0, enemyLayer);
        RaycastHit2D inStatua = Physics2D.CircleCast(transform.position, 2, Vector2.zero, 0, calmLayer);

        if (inEnemy && !increasing)
        {
            increasing = true;
            StartCoroutine(PlayerIncreasingAnxiety(1f));
        }
        if (inStatua && !decreasing)
        {
            decreasing = true;
            StartCoroutine(PlayerDecreasingAnxiety(0.5f));
        }

        enemyInScreen = screen.Length;

        enemyInScreen *= 7;

        HealthDamageImpact();

        if (playerAnxiety <= 0)
        {
            Destroy(gameObject);
        }
    }



    void HealthDamageImpact()
    {
        
        playerAnxietyTotal = playerAnxiety - enemyInScreen;
        float transparency = 1f - (playerAnxietyTotal / 100f);
        Color imageColor = Color.white;
        imageColor.a = transparency;
        anxietyImg.color = imageColor;
    }

    IEnumerator PlayerIncreasingAnxiety(float increase)
    {
        if (playerAnxiety > 0)
        {
            playerAnxiety -= increase;
            Debug.Log("Anxiety increasiiing...");
        }
        yield return new WaitForSeconds(0.05f);
        increasing = false;
    }

    IEnumerator PlayerDecreasingAnxiety(float decrease)
    {
        if (playerAnxiety < 100)
        {
            playerAnxiety += decrease;
            Debug.Log("Calm");
        }

        yield return new WaitForSeconds(0.1f);
        decreasing = false;
    }

 
    

}