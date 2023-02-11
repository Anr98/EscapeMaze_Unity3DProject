using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //= GetComponent<>();
        Invoke("PanelTimer", 1.0f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void PanelTimer()
    {
        this.gameObject.SetActive(false);
    }
}
