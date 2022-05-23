using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="EnemyObj",menuName = "Enemy")]
public class EnemyGameObj : ScriptableObject
{
  public float maxHealth;
  public float st;
  public float minDmg;
  public float maxDmg;
}
