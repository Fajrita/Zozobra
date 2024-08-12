using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class LightScript : MonoBehaviour
{
    [SerializeField] private Vector2 lightBox;
    public LayerMask enemyLayer;
    public float timer;
    public float timerCounter;
    public GameObject lightBackground;
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                UseLight();
                timer = timerCounter;
            }
        }
        if (timer > 0) timer -= Time.deltaTime;

        
    }

    public void UseLight()
    {
        RaycastHit2D[] area = Physics2D.BoxCastAll(transform.position, lightBox, 0, Vector2.zero, 0, enemyLayer);

        //StartCoroutine(LightShow());
        lightBackground.SetActive(true);
        AnxietyEffect.Instance.playerAnxiety += 50;

        foreach (var item in area)
        {
            item.collider.gameObject.GetComponent<EnemyStateManager>().LightReract();
        }
    }

    IEnumerator LightShow()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
