using System.Collections;
using UnityEngine;
using TMPro;

public class TextoDialogo : MonoBehaviour
{
    [SerializeField] private bool playerEnRango;
    [SerializeField] public bool DialogoEmpezo;
    [SerializeField] private bool dialogoCompletado = false; // Nuevo booleano
    [SerializeField] private int lineIndex;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private GameObject iconExclam;
    [SerializeField] private TMP_Text textDialogo;
    [SerializeField, TextArea(4, 5)] private string[] dialogoLineas;
    
    void Update()
    {
        if(playerEnRango && !DialogoEmpezo && !dialogoCompletado)
        {
            iconExclam.SetActive(true);
        }
        else
        {
            iconExclam.SetActive(false);
        }

        if (playerEnRango && Input.GetKeyDown(KeyCode.Return) && !dialogoCompletado)
        {
            if(!DialogoEmpezo)
            {
                iconExclam.SetActive(false);
                EmpezarDialogo();
            }
            else if (textDialogo.text == dialogoLineas[lineIndex])
            {
                NextDialogo();
            }
        }
    }

    private void EmpezarDialogo()
    {
        DialogoEmpezo = true;
        panelDialogo.SetActive(true);
        StartCoroutine(MostrarLinea());
    }

    private void NextDialogo()
    {
        lineIndex++;
        if(lineIndex < dialogoLineas.Length)
        {
            StartCoroutine(MostrarLinea());
        }
        else
        {
            DialogoEmpezo = false;
            dialogoCompletado = true; 
            panelDialogo.SetActive(false);
        }
    }

    IEnumerator MostrarLinea()
    {
        textDialogo.text = string.Empty;
        foreach (char ch  in dialogoLineas[lineIndex])
        {
            textDialogo.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerEnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerEnRango = false;
        }
    }
}
