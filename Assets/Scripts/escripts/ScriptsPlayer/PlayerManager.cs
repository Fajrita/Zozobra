using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool hasJump;
    public bool hasLight;
    public bool hasWait;
    public bool hasDash;
    public bool hasSword;

    public int manchas;

    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else Destroy(this);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
