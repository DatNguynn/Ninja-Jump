using Unity.VisualScripting;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private Renderer backgroundRenderer;
    public string sortingLayerName = string.Empty; //initialization before the methods
    public int orderInLayer = 0;

    void SetSortingLayer()
    {
        if (sortingLayerName != string.Empty)
        {
            backgroundRenderer.sortingLayerName = sortingLayerName;
            backgroundRenderer.sortingOrder = orderInLayer;
        }
    }

    private void Start()
    {
        SetSortingLayer();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.GameSpeed / transform.localScale.x;
        backgroundRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}
