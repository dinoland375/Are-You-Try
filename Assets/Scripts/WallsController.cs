using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    public List<GameObject> walls = null;
    public List<GameObject> backupWalls = null;
    public List<Vector3> spawnPoints;

    public void CreatedWall()
    {
        var wall = Instantiate(walls[Random.Range(0, walls.Count)], spawnPoints[0], Quaternion.identity);
        backupWalls.Add(wall);
        var wall1 = Instantiate(walls[Random.Range(0, walls.Count)], spawnPoints[1], Quaternion.identity);
        backupWalls.Add(wall1);
        var wall2 = Instantiate(walls[Random.Range(0, walls.Count)], spawnPoints[2], Quaternion.identity);
        backupWalls.Add(wall2);
        var wall3 =Instantiate(walls[Random.Range(0, walls.Count)], spawnPoints[3], Quaternion.identity);
        backupWalls.Add(wall3);
    }
}