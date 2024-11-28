using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowSpleteCanvas : MonoBehaviour
{
    public GameObject bonesModel;
    public GameObject bonesSpletedModel;
    public GameObject organsModel;
    public GameObject organsSpletedModel;
    public GameObject musclesModel;
    public GameObject musclesSpletedModel;
    public GameObject CanvasSplete;

    public static bool spleted = false;
    // Start is called before the first frame update
    void Start()
    {
        CanvasSplete.SetActive(true);
        spleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShowModels.countOfModels == 1) CanvasSplete.SetActive(true);
        else CanvasSplete.SetActive(false);
    }

    public void onSpletedButtonClicked()
    {
        if (!spleted)
        {
            if (bonesModel.activeSelf)
            {
                bonesSpletedModel.SetActive(true);
                bonesModel.SetActive(false);
            }
            else if (organsModel.activeSelf)
            {
                organsSpletedModel.SetActive(true);
                organsModel.SetActive(false);
            }
            else if (musclesModel.activeSelf)
            {
                musclesSpletedModel.SetActive(true);
                musclesModel.SetActive(false);
            }
            spleted = true;
        }

    }
    public void onGroupButtonClicked()
    {
        if (spleted)
        {
            if (bonesSpletedModel.activeSelf)
            {
                bonesSpletedModel.SetActive(false);
                bonesModel.SetActive(true);
            }
            else if (organsSpletedModel.activeSelf)
            {
                organsSpletedModel.SetActive(false);
                organsModel.SetActive(true);
            }
            else if (musclesSpletedModel.activeSelf)
            {
                musclesSpletedModel.SetActive(false);
                musclesModel.SetActive(true);
            }
            spleted = false;
        }
    }
}
