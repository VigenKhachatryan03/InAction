using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelShow : MonoBehaviour
{
    public GameObject panel;
    bool show = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickShow()
    {
        if (show == true)
            show = false;
        else
            show = true;
        panel.SetActive(show);
    }
}
