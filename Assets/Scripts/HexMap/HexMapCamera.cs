using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapCamera : MonoBehaviour
{
    private Camera hexCamera;

    public float cameraMinSize, cameraMaxSize;
    public float cameraMoveSpeed;

    public HexGrid grid;

    public static HexMapCamera instance;

    public static bool Locked
    {
        set
        {
            instance.enabled = !value;
        }
    }

    public static void ValidatePosition()
    {
        instance.AdjustPosition(0f, 0f);
    }

    private void Awake()
    {
        hexCamera = GetComponent<Camera>();
    }

    void OnEnable()
    {
        instance = this;
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
        if (zoomDelta != 0f)
        {
            AdjustZoom(zoomDelta);
        }

        float xDelta = Input.GetAxis("Horizontal");
        float zDelta = Input.GetAxis("Vertical");
        if (xDelta != 0f || zDelta != 0f)
        {
            AdjustPosition(xDelta, zDelta);
        }
    }

    void AdjustZoom(float delta)
    {
        float newSize = hexCamera.orthographicSize - delta * 10f;
        hexCamera.orthographicSize = Mathf.Clamp(newSize, cameraMinSize, cameraMaxSize);
    }

    void AdjustPosition(float xDelta, float zDelta)
    {
        hexCamera.transform.position += new Vector3(xDelta, 0, zDelta);
    }

    Vector3 ClampPosition(Vector3 position)
    {
        float xMax = (grid.cellCountX - 0.5f) * (2f * HexMetrics.innerRadius);
        position.x = Mathf.Clamp(position.x, 0f, xMax);

        float zMax = (grid.cellCountZ - 1) * (1.5f * HexMetrics.outerRadius);
        position.z = Mathf.Clamp(position.z, 0f, zMax);

        return position;
    }
}