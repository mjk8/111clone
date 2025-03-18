using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    
    public static GameObject root;
    public static GameObject sceneUI;
    public GameObject Root { get { return root; } }
    
    Stack<GameObject> _popupLinkedList = new Stack<GameObject>();
    
    /// <summary>
    /// UI들의 Parent가 될 Root가 없으면 생성.
    /// </summary>
    public void Init()
    {
        root = GameObject.Find("@UI_Root");
        if (root == null)
        {
            root = new GameObject { name = "@UI_Root" };
            Object.DontDestroyOnLoad(root);
            Canvas canvas = Util.GetOrAddComponent<Canvas>(root);
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler canvasScaler = Util.GetOrAddComponent<CanvasScaler>(root);
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            root.AddComponent<GraphicRaycaster>();
        }
    }
    /// <summary>
    /// 모든 Popup을 삭제한다.
    /// </summary>
    public void CloseAllPopup()
    {
        foreach (Transform child in root.transform)
        {
            if (child.gameObject != sceneUI)
            {
                Managers.Resource.Destroy(child.gameObject);
            }
        }
        _popupLinkedList.Clear();
    }
    
    public void Clear()
    {
        if (sceneUI != null)
        {
            Managers.Resource.Destroy(sceneUI);
        }
        CloseAllPopup();
    }
}
