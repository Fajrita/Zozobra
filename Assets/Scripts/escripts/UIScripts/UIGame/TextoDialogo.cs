using System.Collections;
using UnityEngine;
using TMPro;

public class TextoDialogo : MonoBehaviour
{
    [SerializeField] private bool playerEnRango;
    [SerializeField] public bool DialogoEmpezo;
    [SerializeField] private int lineIndex;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private GameObject iconExclam;
    [SerializeField] private TMP_Text textDialogo;
    [SerializeField, TextArea(4,5)] private string[] dialogoLineas;



    // Update is called once per frame
    void Update()
    {

       

        if(playerEnRango && !DialogoEmpezo)
        {
            iconExclam.SetActive(true);
        } else iconExclam.SetActive(false);

        if (playerEnRango && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Oprimiste espacio y el player es true");
            if(!DialogoEmpezo)
            {
                iconExclam.SetActive(false);
                EmpezarDialogo();
                Debug.Log("Comienza a escribir");
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

        Debug.Log("Comienza a escribir empezar dialogo");
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
            DialogoEmpezo= false;
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
            Debug.Log("Iniciar Dialogo");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerEnRango = false;
            Debug.Log("No se puedeIniciar Dialogo");
        }
    }
}
