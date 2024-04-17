using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapControl : MonoBehaviour
{
    public GameObject minimap;
    public bool isActive = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isActive = !isActive;
            minimap.SetActive(isActive);
        }
    }
}
