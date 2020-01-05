using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrain : MonoBehaviour
{
    public const float maxViewDistance = 450;
    public Transform viewer;
    public static Vector2 viewerPosition;
    int chunkSize;
    int chunksVisibleInViewDistance;

    Dictionary<Vector2, TerrainChunk> TerrainChunkDictionairy = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    void Start(){
        chunkSize = MapGenerator.mapChunkSize - 1;
        chunksVisibleInViewDistance = Mathf.RoundToInt(maxViewDistance / chunkSize);
    }

    void Update(){
        viewerPosition = new Vector2(viewer.position.x, viewer.position.z);
        UpdateVisibleChunks();
    }
    void UpdateVisibleChunks(){
        for(int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++){
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunkSize);

        for(int YOffset = - chunksVisibleInViewDistance; YOffset <= chunksVisibleInViewDistance; YOffset++){
            for(int XOffset = - chunksVisibleInViewDistance; XOffset <= chunksVisibleInViewDistance; XOffset++){
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + XOffset, currentChunkCoordY + YOffset);

                if(TerrainChunkDictionairy.ContainsKey(viewedChunkCoord)){
                    TerrainChunkDictionairy[viewedChunkCoord].UpdateTerrainChunk();
                    if(TerrainChunkDictionairy[viewedChunkCoord].IsVisible()){
                        terrainChunksVisibleLastUpdate.Add(TerrainChunkDictionairy[viewedChunkCoord]);
                    }
                } else {
                    TerrainChunkDictionairy.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord, chunkSize, transform));
                }
            }
        }
    }

    public class TerrainChunk {
        GameObject meshObject;
        Bounds bounds;
        Vector2 position;
        public TerrainChunk(Vector2 coord, int size, Transform parent){
            position = coord * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 positionVector = new Vector3(position.x, 0, position.y);

            meshObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
            meshObject.transform.position = positionVector;
            meshObject.transform.localScale = Vector3.one * size /10f;
            meshObject.transform.parent = parent;
            SetVisible(false);
        }

        public void UpdateTerrainChunk(){
            float viewDistanceFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
            bool visible = viewDistanceFromNearestEdge <= maxViewDistance;
            SetVisible(visible);
        }

        public void SetVisible(bool visible){
            meshObject.SetActive(visible);
        }

        public bool IsVisible(){
            return meshObject.activeSelf;
        }
    }
}
