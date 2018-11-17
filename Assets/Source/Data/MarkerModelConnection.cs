using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MarkersModelsConnectionsData", menuName = "MarkersAndModels/Connections", order = 1)]
public class MarkerModelDict : ScriptableObject
{
    public List<MarkerModelConnection> Connections;
}

[Serializable]
public class MarkerModelConnection
{
    public string objectName = "New MarkerModelConnection";
    public long ModelId;
    public GameObject Prefab;
}

