using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawner : MonoBehaviour
{
    public EnemyTankView heavyAssaultPrefab;
    public EnemyTankView scoutPrefab;
    public EnemyTankView artilleryPrefab;

    public Material heavyMaterial;
    public Material scoutMaterial;
    public Material artilleryMaterial;
    public Transform player;

    void Start()
    {
        SpawnEnemy(heavyAssaultPrefab, heavyMaterial, new Vector3(-15, 0, 0));
        SpawnEnemy(scoutPrefab, scoutMaterial, new Vector3(0, 0, 20));
        SpawnEnemy(artilleryPrefab, artilleryMaterial, new Vector3(15, 0, -11));
    }

    void SpawnEnemy(EnemyTankView prefab, Material material, Vector3 spawnPosition)
    {
        EnemyTankView enemyTankView = Instantiate(prefab, spawnPosition, Quaternion.identity);
        
        EnemyTankModel model = new EnemyTankModel(
            enemyTankView.movementSpeed,
            enemyTankView.rotationSpeed,
            enemyTankView.health,
            GetTankType(prefab),
            material
        );

        EnemyTankController enemyTankController = new EnemyTankController(model, enemyTankView , player);
        enemyTankView.SetTankController(enemyTankController ,player);
        Debug.Log("Spawning enemy: " + prefab.name);
    }

    EnemyTankTypes GetTankType(EnemyTankView prefab)
    {
        if (prefab == heavyAssaultPrefab) return EnemyTankTypes.HeavyAssault;
        if (prefab == scoutPrefab) return EnemyTankTypes.Scout;
        if (prefab == artilleryPrefab) return EnemyTankTypes.Artillery;
        return EnemyTankTypes.HeavyAssault;
    }
}
