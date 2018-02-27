using UnityEditor;
using System.Linq;

/// <summary>
/// Siblingを上下に移動させるエディタ拡張
/// </summary>
public class UniSiblingChanger : Editor
{

    /// <summary>
    /// Siblingを上げ、前方に移動する
    /// </summary>
    [MenuItem("GameObject/Set to Next Sibling %#+")]
    static void SetToNextSibling()
    {
        ChangeSibling(1);
    }

    /// <summary>
    /// Siblingを下げ、後方に移動する
    /// </summary>
    [MenuItem("GameObject/Set to Previous Sibling %#*")]
    static void SetToPreviousSibling()
    {
        ChangeSibling(-1);
    }

    /// <summary>
    /// Siblingを移動量変える
    /// </summary>
    /// <param name="count">移動量</param>
    static void ChangeSibling(int count)
    {
        var objects = Selection.gameObjects;
        if(objects == null) {
            return;
        }
        // ソート条件
        var desc = count > 0 ? -1 : 1;
        // 並び替え
        foreach(var obj in objects.OrderBy(x => desc * x.transform.GetSiblingIndex())) {
            var index = obj.transform.GetSiblingIndex();
            obj.transform.SetSiblingIndex(index + count);
        }
    }
}
