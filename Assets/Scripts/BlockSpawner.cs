using UnityEngine;

enum RandomizedFloatVector { Horizontal, Vertical}

public class BlockSpawner : BlockCollisionHandler
{
    [SerializeField]
    private BlockCollision block = null;
    [SerializeField]
    private float zRotation = 0;
    [SerializeField]
    private RandomizedFloatVector randomizedFloatVector;
    BlockCollision instance = null;

    // Start is called before the first frame update
    void Start()
    {
        CreateOnePool();
        PositionBlock();
    }

    private void CreateOnePool()
    {
        if (block == null) return;
        instance = Instantiate(block, transform.position, Quaternion.identity);
        instance.transform.parent = transform;
        instance.transform.rotation = Quaternion.Euler(0, 0, zRotation);
        instance.Awake();
        instance.gameObject.SetActive(false);
    }

    public void PositionBlock()
    {
        if(randomizedFloatVector == RandomizedFloatVector.Horizontal)
        {
            instance.transform.position = new Vector2(Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x), transform.position.y);
            instance.gameObject.SetActive(true);
            return;
        }
        instance.transform.position = new Vector2(transform.position.x, Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y));
        instance.gameObject.SetActive(true);
    }

    public override void OnBlockCollision()
    {
        PositionBlock();
    }
}
