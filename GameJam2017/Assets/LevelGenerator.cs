using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public Transform OffScreenPositionLeft;

    public GameObject[] LevelPiecesPrefabs;
    public int poolSize = 4;

    List<LevelPiece> currentPieces;

    void Start()
    {
        currentPieces = new List<LevelPiece>();

        for (int i = 0; i < poolSize; i++)
        {
            SpawnPiece();
        }
    }

    void Update()
    {
        if (currentPieces[0].RightEdge.position.x < OffScreenPositionLeft.position.x)
        {
            Destroy(currentPieces[0].gameObject);
            currentPieces.RemoveAt(0);
            SpawnPiece();
        }
    }

    void SpawnPiece()
    {
        GameObject levelPiece = GetRandomPiece();
        if (currentPieces.Count == 0)
            levelPiece.transform.position = OffScreenPositionLeft.position;
        else
            levelPiece.transform.position = currentPieces[currentPieces.Count - 1].RightEdge.position;
        
        currentPieces.Add(levelPiece.GetComponent<LevelPiece>());

    }

    GameObject GetRandomPiece()
    {
        int randomIndex = Random.Range(0, LevelPiecesPrefabs.Length);

        return Instantiate(LevelPiecesPrefabs[randomIndex]) as GameObject;
    }
}
