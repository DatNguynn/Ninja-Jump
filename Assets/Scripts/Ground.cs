using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private Renderer groundRenderer;

    public string sortingLayerName = string.Empty; //initialization before the methods
    public int orderInLayer = 1;

    void SetSortingLayer()
    {
        if (sortingLayerName != string.Empty)
        {
            groundRenderer.sortingLayerName = sortingLayerName;
            groundRenderer.sortingOrder = orderInLayer;
        }
    }

    private void Awake()
    {
        groundRenderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        SetSortingLayer();
    }
    private void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        groundRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
