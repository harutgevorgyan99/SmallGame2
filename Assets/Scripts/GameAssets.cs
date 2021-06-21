using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class GameAssets
{
    public List<Assets> Items;
}
[Serializable]
public class Assets 
{
    public Sprite item;
    public string name;
}