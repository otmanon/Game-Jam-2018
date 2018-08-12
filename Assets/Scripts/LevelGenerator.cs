using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public int chunkWidth;
	public int chunkHeight;
	public GameObject floorTile;
	public GameObject enemy;
	public float maxDrop;
	public float minPlatformLength;
	public float maxPlatformLength;
	public float minSeparation;

	// given the current difficulty, and the chunk size
	// return a gameobject holding a new chunk
	public GameObject GenerateChunk(float currentDifficulty, int chunkID) {
		int[,] graph = new int[chunkWidth, chunkHeight];

		// pass 1: platform placement
		for (int i = 0; i < chunkWidth; i++) {
			int platformLength = 0;
			for (int j = 0; j < chunkHeight; j++) {
				// determine whether we have blank space or a platform
				// TODO
				if (j == chunkHeight - 1 || j == 0)
					graph[i,j] = 0;
				else
					graph[i,j] = 1;
			}
		}

		// pass 2: enemy and trap placement
		for (int i = 0; i < chunkWidth; i++) {
			for (int j = 0; j < chunkHeight; j++) {
				// place an enemy, or a trap
				// TODO
				if (graph[i,j] == 0 && Random.value > 1.0f / currentDifficulty) {
					// place enemy
					graph[i,j] = 2;
				}
			}
		}

		// generate gameobject representation of the chunk

		string goName = "chunk" + chunkID;
		GameObject result = new GameObject(goName);
		result.SetActive(false);

		for (int i = 0; i < chunkWidth; i++) {
			for (int j = 0; j < chunkHeight; j++) {
				if (graph[i,j] == 1) {
					GameObject obstacle = GameObject.Instantiate(floorTile, result.transform);
					obstacle.transform.localPosition = new Vector3(i - chunkWidth / 2, chunkHeight / 2 - j, 0);
				} else if (graph[i,j] == 2) {
					// GameObject enemy = GameObject.Instantiate();
				}
			}
		}

		return result;
	}

	// return the chunk size
	public Vector2 GetDimensions() {
		return new Vector2(chunkWidth, chunkHeight);
	}
}
