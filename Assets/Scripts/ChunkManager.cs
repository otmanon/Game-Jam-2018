using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {
	[Range(1.0f, 2.0f)]
	public float initialDifficulty = 1.0f;
	[Range(1.0f, 2.0f)]
	public float difficultyModifier = 1.15f;
	[Range(2, 10)]
	public int chunkBufferSize = 5;
	public float maxY = 10.0f;
	public float moveSpeed = 0.02f;
	
	private GameObject go;
	private LevelGenerator lg;
	private List<GameObject> chunkList;
	private float currentDifficulty;
	private Vector2 chunkDimensions;
	private int nextChunkID = 1;

	void Start () {
		// instantiate references and attributes
		go = this.gameObject;
		lg = GameObject.FindGameObjectWithTag("LevelGenerator").GetComponent<LevelGenerator>();
		chunkList = new List<GameObject>();
		chunkDimensions = lg.GetDimensions();
		currentDifficulty = initialDifficulty;

		// initial buffered chunk creation
		for (int i = 0; i < chunkBufferSize; i++) {
			chunkList.Add(lg.GenerateChunk(currentDifficulty, nextChunkID++));
			currentDifficulty *= difficultyModifier;
		}

		// initial buffered chunk placement
		for (int i = 0; i < chunkBufferSize; i++) {
			// TODO
			GameObject chunk = chunkList[i];
			chunk.SetActive(true);
			chunk.transform.position = new Vector3(0, i * -chunkDimensions.y, 0);
		}
	}

	void FixedUpdate () {
		// move the chunks up at a constant rate
		foreach (GameObject chunk in chunkList) {
			Vector3 chunkPosition = chunk.transform.position;
			chunkPosition.y = chunkPosition.y + moveSpeed;
			chunk.transform.position = chunkPosition;
		}

		// if they end up outside of the camera, unload and load a new chunk
		GameObject firstItem = chunkList[0];
		if (firstItem.transform.position.y > maxY) {
			chunkList.RemoveAt(0);
			GameObject.Destroy(firstItem);
			GameObject newChunk = lg.GenerateChunk(currentDifficulty, nextChunkID++);
			chunkList.Add(newChunk);
			newChunk.transform.position = new Vector3(0, chunkDimensions.y * (chunkBufferSize - 1), 0);
			newChunk.SetActive(true);
			currentDifficulty *= difficultyModifier;
		}
	}
}
