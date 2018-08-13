using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public GameObject floorTile;
    public Sprite sprite;
	
	private int chunkWidth = 18;
	private int chunkHeight = 10;	
	private int maxSeparation = 6;
	private int minPlatformLength = 3;
	private int maxPlatformLength = 10;
	private int minSeparation = 3;

	// given the current difficulty, and the chunk size
	// return a gameobject holding a new chunk
	public GameObject GenerateChunk(float currentDifficulty, int chunkID) {
		int[,] graph = new int[chunkWidth, chunkHeight];

		// pass 1: platform placement
		// idea: select rows to contain platforms at random, within distance parameters
		int sep = minSeparation - 1;
		for (int i = 0; i < chunkHeight; i++) {
			if ((sep >= minSeparation && Random.value < (1 / (currentDifficulty))) || sep > maxSeparation) {
				// place a platform in this row
				int platformPosition = (int) Random.Range(0, chunkWidth - 1);
				int platformWidth = (int) Random.Range(minPlatformLength, maxPlatformLength);
				int platformStart = platformPosition - platformWidth / 2;
				int platformEnd = platformPosition + platformWidth / 2;
				bool wrap = false;

				// wrap around
				/*if (platformStart < 0 || platformEnd > chunkWidth - 1) {
					platformStart = platformStart < 0 ? platformStart % chunkWidth : platformStart;
					platformEnd = platformEnd > chunkWidth - 1 ? platformEnd % chunkWidth : platformEnd;
					wrap = true;
				}*/

				// platformStart = platformStart < 0 ? 0 : platformStart;
				// platformEnd = platformEnd > chunkWidth - 1 ? chunkWidth - 1 : platformEnd;

				if (platformStart < 0) {
					platformStart = platformStart % chunkWidth;
					platformStart = platformStart < 0 ? platformStart + chunkWidth : platformStart;
					wrap = true;
				} else if (platformEnd >= chunkWidth) {
					platformEnd = platformEnd % chunkWidth;
					wrap = true;
				}

				for (int j = 0; j < chunkWidth; j++) {
					if ((wrap && (j <= platformEnd || j >= platformStart)) || (j >= platformStart && j <= platformEnd)) {
						graph[j,i] = 1;
					} else {
						graph[j,i] = 0;
					}
				} 
				sep = 0;
			} else {
				// empty space in this row
				for (int j = 0; j < chunkWidth; j++)
					graph[j,i] = 0;
			}
			sep++;
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
				//    SpriteRenderer renderer = obstacle.AddComponent<SpriteRenderer>();
               //     renderer.sprite = sprite;
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
