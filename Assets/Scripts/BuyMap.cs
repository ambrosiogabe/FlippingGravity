using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMap : MonoBehaviour {

    ToggleMaps mapScript;

    public void Start()
    {
        mapScript = GameObject.Find("ToggleMaps").GetComponent<ToggleMaps>();
    }

    private void OnMouseDown()
    {
        mapScript.BuyMap();
    }
}
