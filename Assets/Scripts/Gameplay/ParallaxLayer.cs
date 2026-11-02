using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float followFactor = 0.5f;

    private Transform cameraTransform;
    private Transform[] tiles;
    private float tileWidth;
    private float baseY;
    private float baseZ;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        baseY = transform.position.y;
        baseZ = transform.position.z;

        tiles = new Transform[transform.childCount];
        for (int i = 0; i < tiles.Length; i++)
            tiles[i] = transform.GetChild(i);

        tileWidth = tiles[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        float cameraX = cameraTransform.position.x;
        float layerX = cameraX * followFactor;
        transform.position = new Vector3(layerX, baseY, baseZ);

        float relativeX = cameraX - layerX;
        float shift = Mathf.Round(relativeX / tileWidth) * tileWidth;
        float center = (tiles.Length - 1) * 0.5f;

        for (int i = 0; i < tiles.Length; i++)
        {
            Vector3 localPosition = tiles[i].localPosition;
            localPosition.x = shift + (i - center) * tileWidth;
            tiles[i].localPosition = localPosition;
        }
    }
}
