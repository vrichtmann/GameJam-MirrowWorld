using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesManager : MonoBehaviour {
  
    [SerializeField]private GameObject normalWorldTXT;
    [SerializeField] private GameObject deadWorldTXT;
    [SerializeField] private correctManager correctManager;

    [SerializeField] private GameObject[] allEnemies;

    [SerializeField] private Vector2 lastSorted = new Vector2(5, 5);
    [SerializeField] private Vector2 enemiesWorld = new Vector2(0, 0);


    private void Awake(){
        sortNumbersWorld();
        contEnemiesWorld();
   }

   public void sortNumbersWorld(){
        int sorted1 = Random.RandomRange(0, allEnemies.Length);
        int sorted2 = allEnemies.Length - sorted1;
        int maxCont = 100;
        int contRepeat = 0;

        while(contRepeat < maxCont && (sorted1 == lastSorted.x && sorted2 == lastSorted.y)){
            contRepeat++;
            sorted1 = Random.RandomRange(0, allEnemies.Length);
            sorted2 = allEnemies.Length - sorted1;
        }

        normalWorldTXT.GetComponent<TextMeshProUGUI>().text = sorted1.ToString();
        deadWorldTXT.GetComponent<TextMeshProUGUI>().text = sorted2.ToString();

        lastSorted = new Vector2(sorted1, sorted2);
    }

    public void contEnemiesWorld(){
        int deadEnemies = 0;
        int normalEnemies = 0;
        for (var i=0;i< allEnemies.Length; i++){
            bool enemyIsDead = allEnemies[i].GetComponent<EnemyControl>().isDead;
            if (enemyIsDead){
                deadEnemies++;
            }else{
                normalEnemies++;
            }
        }

        enemiesWorld = new Vector2(normalEnemies, deadEnemies);
    }

    public void checkEnemieCount(){
        contEnemiesWorld();

        Debug.Log("lastSorted : " + lastSorted);
        Debug.Log("enemiesWorld : " + enemiesWorld);

        if (lastSorted.x == enemiesWorld.x && lastSorted.y == enemiesWorld.y){
            Debug.Log("ACERTOU MISERAVI");
            sortNumbersWorld();
            correctManager.showCorrectResponse();
        }
    }

}
