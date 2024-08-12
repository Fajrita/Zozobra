using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivarObjects : MonoBehaviour
{
   [SerializeField] private GameObject sprite;


    private void Update()
    {
        if(gameObject.GetComponent<TextoDialogo>().DialogoEmpezo)
        {
            sprite.SetActive(true);
        }else sprite.SetActive(false);
    }


    //public void ActivarSacerdotiza(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        sprite.SetActive(true);
    //    }
    //}
    //    void OnTriggerEnter2D(Collider2D collision)
    //{
    //        ActivarSacerdotiza(collision);
    //}
    // void OnTriggerExit2D(Collider2D collision)
    //{
    //        sprite.SetActive(false);
    //}

    
}
