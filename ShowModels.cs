using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowModels : MonoBehaviour
{
    public GameObject model;
    private Button button;
    private Color originalColor;
    private bool isColorChanged = false;
    public static int countOfModels = 0;
    // Start is called before the first frame update
    void Start()
    {
        countOfModels = 0;

        model.SetActive(false);

        button = GetComponent<Button>();

        // Store the original color
        originalColor = button.colors.normalColor;

        // Attach the OnButtonClick method to the button's click event
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        if (!ShowSpleteCanvas.spleted)
        {
            if (model.activeSelf)
            {
                countOfModels -= 1;
                model.SetActive(false);
            }
            else
            {
                countOfModels += 1;
                model.SetActive(true);
            }

            if (!model.activeSelf)
            {
                // Change the color to a different one
                ColorBlock colorBlock = button.colors;
                colorBlock.normalColor = Color.gray;  // Change this to your desired color
                button.colors = colorBlock;
            }
            else
            {
                // Revert to the original color
                ColorBlock colorBlock = button.colors;
                colorBlock.normalColor = originalColor;
                button.colors = colorBlock;
            }
        }
    }
}