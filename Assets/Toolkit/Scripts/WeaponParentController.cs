using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParentController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Defines the ToolGenerator as non-destructible to perserve data
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
