using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovimentType : MonoBehaviour
{
    public enum enemiesMovimentType
    {
        Waiting,
        Player,
        StandyBy,
        BackToBase,
        movimentIntoArea
    };
}
