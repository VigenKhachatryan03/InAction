using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class AiRequest : MonoBehaviour
{
    public TextMeshProUGUI textRequest;
    public TextMeshProUGUI textResponse;

    public List<HumanBodyPart> listOfAllPartsHuman;
    HumanBodyPart instance;
    void Start()
    {
        textRequest.text = "";
        textResponse.text = "Enter a part name";
        GetAllData();
        instance = new()
        {
            id = 0,
            isDeleted = false,
            name = "head",
            partId = 0,
            partSexId = 0,
        };
        textRequest.text = "head";

    }

    // Update is called once per frame
    void Update()
    {

    }
    public async void AiButtonClicked()
    {
        bool enable = false;
        int indexOfPart = 0;

        foreach (var part in listOfAllPartsHuman)
        {
            if (textRequest != null && part.name == textRequest.text)
            {
                enable = true;
                indexOfPart = part.id;
                break;
            }
        }

        if (enable)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"https://localhost:7043/api/GPT/GenerateResponse?type={listOfAllPartsHuman[indexOfPart]}");

                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        textResponse.text = responseContent;
                    }
                    else
                    {
                        textResponse.text = "Something went wrong with the API request!";
                    }
                }
                catch (HttpRequestException e)
                {
                    textResponse.text = $"HttpRequestException: {e.Message}";
                }
            }
        }
        else
        {
            textResponse.text = "Something wrong with the input!";
        }
    }

    // Replace YourPartType with the actual type of your parts
    public class YourPartType
    {
        public int id;
        public string name;
    }

    //public void AiButtonClicked()
    //{
    //    bool enable = false;
    //    int indexOfPart = 0;
    //    foreach (var part in listOfAllPartsHuman)
    //    {
    //        if (textResponse != null && part.name == textRequest.text)
    //        {
    //            enable = true;
    //            indexOfPart = part.id;
    //            break;
    //        }
    //    }

    //    if (enable)
    //    {
    //        HttpClient client = new HttpClient(); // refactor
    //        var response = client.GetAsync($"https://localhost:7043/api/GPT/GenerateResponse?type={instance}").Result;
    //        var responseContent = "";
    //        if (response != null && response.IsSuccessStatusCode)
    //        {
    //            responseContent = response.Content.ReadAsStringAsync().Result;
    //        }
    //        else
    //        {
    //            responseContent = "something wrong!!!!!";
    //        }
    //        //string responseConent = $"Here will be response of API Request for question about {listOfAllPartsHuman[indexOfPart].name}";
    //        textResponse.text = responseContent;

    //    }
    //    else
    //    {
    //        textResponse.text = "something wrong!!!!!";
    //    }
    //}



    public void GetAllData()
    {
        HttpClient client = new HttpClient(); // refactor
        var response = client.GetAsync($"https://localhost:7043/api/Part/GetAll").Result;

        if (response != null)
        {
            var responseContentJson = response.Content.ReadAsStringAsync().Result;
            listOfAllPartsHuman = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HumanBodyPart>>(responseContentJson);
        }
        else
        {
            textRequest.text = "something wrong!!!!!";
        }
    }
}

