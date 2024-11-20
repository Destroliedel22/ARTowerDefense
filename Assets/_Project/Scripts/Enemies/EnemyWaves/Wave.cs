using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Waves")]
public class Wave : ScriptableObject
{
    public List<GameObject> enemies;
}