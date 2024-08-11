using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesImagen : MonoBehaviour
{
        public float amplitud = 0.5f; // Altura máxima del flotado
        public float velocidad = 1f; // Velocidad del flotado

        private Vector3 posicionInicial;

        void Start()
        {
            
            posicionInicial = transform.position;
        }

        void Update()
        {
            // Calculamos la nueva posición Y basada en la función seno
            float y = Mathf.Sin(Time.time * velocidad) * amplitud;
            transform.position = posicionInicial + new Vector3(0, y, 0);
        }      
}


