using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class HumanBodyPart 
{
        public string name { get; set; }
        public int partId { get; set; }
        public int partSexId { get; set; }
        public int id { get; set; }
        public bool isDeleted { get; set; }
}