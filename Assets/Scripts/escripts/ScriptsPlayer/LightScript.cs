using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightScript : MonoBehaviour
{
    [SerializeField] private Vector2 lightBox;
    public LayerMask enemyLayer;
    void Start()
    {
        UseLight();
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void UseLight()
    {
        RaycastHit2D[] area = Physics2D.BoxCastAll(transform.position, lightBox, 0, Vector2.zero, 0, enemyLayer);

        StartCoroutine(LightShow());
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
