using System.Collections;
using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu]
public class MovableSpriteSettings : ScriptableObject
{
    public GameObject movableSpritePrefab;

    public int clicksDivider;

    public Color spriteColor;
}
