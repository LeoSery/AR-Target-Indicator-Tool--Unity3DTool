////////////////////////////////////////////////////////////////////////////////////
// AR-Target-Indicator-Tool -- Léo Séry
// ####
// Script to track a target object and display its position with a visual indicator.
// Script by Léo Séry - 08/02/2023
// ####
////////////////////////////////////////////////////////////////////////////////////

using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TargetFinderIndicator : MonoBehaviour
{
    public Image targetIndicatorUI;
    public GameObject targetObject;
    public GameObject helpBoxObject;
    public TextMeshProUGUI helpBoxText;
    public Camera Camera;
    public bool showHelpBox;
    public bool alwaysShowCursor;

    private Transform targetTransfom;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (targetObject != null)
        {
            UpdateCursorPosition();
            UpdateCursorRotation();

            if (showHelpBox)
                UpdateHelpBox();
            else
                helpBoxObject.SetActive(false);

            if (!alwaysShowCursor)
                if (IsObjectInFieldOfView(targetObject))
                    targetIndicatorUI.enabled = false;
                else
                    targetIndicatorUI.enabled = true;
            else
                targetIndicatorUI.enabled = true;
        }
    }

    public void Initialize()
    {
        targetTransfom = targetObject.transform;
        if (Camera == null)
            Camera = Camera.main;
    }

    private void UpdateCursorPosition()
    {
        float minX = targetIndicatorUI.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = targetIndicatorUI.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 targetPos = Camera.WorldToScreenPoint(targetTransfom.position);

        if (Vector3.Dot((targetTransfom.position - Camera.transform.position), Camera.transform.forward) < 0)
        {
            // Target is behind the player
            if (targetPos.x < Screen.width / 2)
                targetPos.x = maxX; // Target is on the left
            else
                targetPos.x = minX; // Target is on the right
        }

        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        targetIndicatorUI.transform.position = targetPos;
    }

    private void UpdateCursorRotation()
    {
        Vector2 targetPos = Camera.WorldToScreenPoint(targetTransfom.position);
        Vector2 cursorPos = targetIndicatorUI.transform.position;
        Vector2 direction = (targetPos - cursorPos).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        targetIndicatorUI.transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    private void UpdateHelpBox()
    {
        Vector2 targetPos = Camera.WorldToScreenPoint(targetTransfom.position);
        if (!IsObjectInFieldOfView(targetObject))
        {
            helpBoxObject.SetActive(true);
            string helpText = "";
            if (targetPos.x < Screen.width / 3)
            {
                helpText += "Aller vers la gauche";
                if (targetPos.y < Screen.height / 3)
                    helpText = "Aller en bas à gauche";
                else if (targetPos.y >= 2 * Screen.height / 3)
                    helpText = "Aller en haut à gauche";
            }
            else if (targetPos.x >= 2 * Screen.width / 3)
            {
                helpText += "Aller vers la droite";
                if (targetPos.y < Screen.height / 3)
                    helpText = "Aller en bas à droite";
                else if (targetPos.y >= 2 * Screen.height / 3)
                    helpText = "Aller en haut à droite";
            }
            else if (targetPos.y < Screen.height / 3)
                helpText = "Aller vers le bas";
            else
                helpText = "Aller vers le haut";

            UpdateHelpText(helpText);
        }
        else
            helpBoxObject.SetActive(false);
    }

    private void UpdateHelpText(string text)
    {
        helpBoxText.text = text.Trim();
    }

    private bool IsObjectInFieldOfView(GameObject target)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera);
        return GeometryUtility.TestPlanesAABB(planes, target.GetComponent<Collider>().bounds);
    }
}
