using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int HealthPoints = 3; // Should be moved

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoints <= 0) 
        { 
            gameObject.SetActive(false);
        }
    }
}
