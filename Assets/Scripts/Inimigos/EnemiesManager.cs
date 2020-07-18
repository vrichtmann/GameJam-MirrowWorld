using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour {
    public GameObject[] allEnemies;
    public ArrayList allEnemiesTarget;
    private ArrayList sortedEnemies;
    private ArrayList followingPlayerArray;
    private bool isSorted = false;

   // private void Awake(){
   //     sortedEnemies = new ArrayList();
   //     allEnemiesTarget = new ArrayList();
   //     setEnemyTargetArray();
   // }

   // private void setEnemyTargetArray(){//Deve ter algum jeito melhor... mas não achei o methodo
   //     for(int i =0; i< allEnemies.Length; i++){
   //         allEnemiesTarget.Add(allEnemies[i]);
   //     }
   // }

   //void Update(){
   //     if (Input.GetKeyDown(KeyCode.Alpha1)){//Velocidade
   //         getElemiesCountArray(3);
   //         incrementPowerUP("velocity");
   //     }else if (Input.GetKeyDown(KeyCode.Alpha2)){//Scale
   //         getElemiesCountArray(3);
   //         incrementPowerUP("scale");
   //     }else if (Input.GetKeyDown(KeyCode.Alpha3)){//Fire Shield
   //         getElemiesCountArray(3);
   //         incrementPowerUP("fireShield");
   //     }else if (Input.GetKeyDown(KeyCode.Alpha4)){//SummonClones
   //         getElemiesCountArray(3);
   //         incrementPowerUP("summonClones");
   //     }
   // }

   // public void getMinionsPower(string _power, int _numberEnemies, float _timer){//(velocity,scale,fireShield,summonClones), 3(numero de inimigos), 5(segundos)
   //     getElemiesCountArray(_numberEnemies);
   //     incrementPowerUP(_power, _timer);
   // }

   // public void getElemiesCountArray(int _sortedNumber){

   //     filterEnemiesFollow();

   //     if (_sortedNumber > followingPlayerArray.Count) _sortedNumber = (followingPlayerArray.Count);

   //     sortedEnemies = new ArrayList();

   //     int contRepeatSorted = 0;

   //     for (int i = 0; i < _sortedNumber; i++){
   //         int randomIndex = Random.Range(0, followingPlayerArray.Count);

   //         while(sortedEnemies.IndexOf(randomIndex) != -1 && contRepeatSorted < 100){
   //             randomIndex = Random.Range(0, followingPlayerArray.Count);
   //             contRepeatSorted++;
   //         }

   //         sortedEnemies.Add(randomIndex);           
   //     }
   // }

   // public void filterEnemiesFollow()
   // {
   //     int enemiesFollow = 0;
   //     followingPlayerArray = new ArrayList();

   //     for (int i = 0; i < allEnemiesTarget.Count; i++){
   //         GameObject enemyTarget = allEnemiesTarget[i] as GameObject;
   //         EnemyController enemyController = enemyTarget.GetComponent<EnemyController>();

   //         if (enemyController.enemyMovimentType.ToString() == "Player"){
   //             followingPlayerArray.Add(enemyTarget);
   //         }
   //     }
   // }

   // public void incrementPowerUP(string _powerUP, float _timer = 0){
   //     isSorted = true;
        
   //     for (int i = 0; i < sortedEnemies.Count; i++){

   //         int sortedEnemy = System.Convert.ToInt32(sortedEnemies[i]);

   //         GameObject FollowingEnemy = followingPlayerArray[sortedEnemy] as GameObject;

   //         EnemyPowerUP enemyPowerUP = FollowingEnemy.GetComponent<EnemyPowerUP>();
   //         enemyPowerUP.Aurea();

   //         if (_powerUP == "velocity"){
   //             enemyPowerUP.incrementEnemySpeed(_timer);
   //         }else if(_powerUP == "scale"){
   //             enemyPowerUP.incrementEnemyScale(_timer);
   //         }else if (_powerUP == "fireShield"){
   //             enemyPowerUP.incrementEnemyFireShield(_timer);
   //         }else if (_powerUP == "summonClones"){
   //             enemyPowerUP.incrementEnemySummonClones();
   //         }
   //     }
   // }

   // public void removeAllEnemiesList(GameObject _enemyDie){//Remove Inimigo de todas as listas
   //     for (int i = 0; i < allEnemiesTarget.Count; i++){
   //         GameObject enemyArray = allEnemiesTarget[i] as GameObject;
   //         if (enemyArray.name == _enemyDie.name){
   //             allEnemiesTarget.RemoveAt(i);
   //             break;
   //         }

   //         EnemyGuard isEnemyGuard = _enemyDie.GetComponent<EnemyGuard>();
   //         if (isEnemyGuard != null){
   //             EnemyArea enemyArea = isEnemyGuard.initArea.GetComponent<EnemyArea>();
   //             for(int j =0; j < enemyArea.enemiesAlertArray.Count; j++){
   //                 GameObject currentEnemyAlert = enemyArea.enemiesAlertArray[j] as GameObject;
   //                 if(currentEnemyAlert.name == _enemyDie.name){
   //                     enemyArea.enemiesAlertArray.RemoveAt(j);
   //                     break;
   //                 }
   //             }
   //         }
   //     }
   // }

}
