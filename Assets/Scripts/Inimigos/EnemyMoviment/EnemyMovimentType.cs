using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovimentType : MonoBehaviour
{
    public enum enemiesMovimentType
    {
        Waiting,
        Player,
        RandomMove,
        BackToBase,
        movimentIntoArea
    };
}
