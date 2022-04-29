using UnityEngine.UI;
using UnityEngine;

namespace Pipelines
{
    public static class RedirectData
    {
        public static Sprite targetSprite { get; set; }
        public static ARModel targetModel { get; set; }

        public static GameObject targetPrefab { get; set; }

        public static GameObject[] prefabs { get; set; }

        // Prefab returned needs to be instantiated
        public static void SetTargetPrefab(string name) {
            if (prefabs != null) {
                foreach (var go in prefabs) {
                    if (name.Contains(go.name, System.StringComparison.OrdinalIgnoreCase)) {
                        targetPrefab = go;
                        Debug.Log($"Target prefab is now: {name}");
                    }
                }
            }else {
                targetPrefab = null;
                Debug.Log($"{name} not found or prefab list is null");
            }
        }
    }

    public class InfoPanel
    {
        public Text Header { get; }
        public Image InfoImg { get; }
        public Text ModelName { get; }
        public Text Description { get; }

        public InfoPanel(GameObject infoMenu)
        {
            if (infoMenu != null)
            {
                /* InfoMenu -> Header -> text_obj_name */
                Header = infoMenu.transform.GetChild(0).GetChild(1).GetComponent<Text>();
                /* InfoMenu -> Content */
                var content = infoMenu.transform.GetChild(1);
                /* InfoMenu -> Content -> Image*/
                InfoImg = content.GetChild(0).GetComponent<Image>();

                /* InfoMenu -> Content -> Panel */
                var panel = content.GetChild(1);
                ModelName = panel.GetChild(0).GetComponent<Text>();
                Description = panel.GetChild(1).GetComponent<Text>();
            }
        }

        public void SetInfo(Sprite modelSprite, ARModel model)
        {
            Header.text = model.Name;
            InfoImg.sprite = modelSprite;
            ModelName.text = model.Name;
            Description.text = model.Description;
        }
    }
}