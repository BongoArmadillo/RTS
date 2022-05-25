using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="EnemyObj",menuName = "Enemy")]
public class EnemyGameObj : ScriptableObject
{
  public float maxHealth;
  public float st;
  public int minUnitDmg;
  public int maxUnitDmg;
}
