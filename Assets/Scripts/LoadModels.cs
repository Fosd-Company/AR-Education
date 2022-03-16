using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pipelines;

public class LoadModels : MonoBehaviour
{
    public GameObject PrefabPanel;
    public GameObject InfoMenu;
    
    [SerializeField]
    private InfoPanel infoPanel;

    Dictionary<int, GameObject> ModelPanels;
    
    void Awake()
    {
        ModelPanels = new Dictionary<int, GameObject>();
        infoPanel = new InfoPanel(InfoMenu);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PrefabPanel != null) {
            foreach(var model in Data.models) {
                ModelPanels.Add(model.ID, LoadModel(model));
            }
        }
    }

    GameObject LoadModel(ARModel model)
    {
        /* model_grid -> ModelPanel */
        var panel = Instantiate(PrefabPanel, this.transform);
        panel.name = "Panel_" + model.Name;
        
        /* ModelPanel -> model_picture */
        var img = panel.transform.GetChild(0).GetComponent<Image>();
        /* ModelPanel -> info */
        var infoPanel = panel.transform.GetChild(1);
            var lbl_name = infoPanel.GetChild(0).GetComponent<Text>();
            var lbl_type = infoPanel.GetChild(1).GetComponent<Text>();
        /* ModelPanel -> btn_ref */
        var btnRef = panel.transform.GetChild(2).GetComponent<Button>();
        
        var targetSprite = Resources.Load<Sprite>("Sprites/ModelGrid/" + model.ID);
        img.sprite = targetSprite;
        lbl_name.text = model.Name;
        lbl_type.text = model.Type;

        btnRef.onClick.AddListener(() => ShowInfo(img.sprite, model));
        return panel;
    }

    void ShowInfo(Sprite modelSprite, ARModel model)
    {
        infoPanel.SetInfo(modelSprite, model);
        GameObject.Find("MainMenu").SetActive(false);
        InfoMenu.SetActive(true);
    }

    public void Search(InputField input) => SearchValue(input.text);

    public void SearchValue(string value)
    {
        var sizeFitter = this.GetComponent<ContentSizeFitter>();
        sizeFitter.enabled = false;

        var ids = Search(value);
        if (ids.Count == 0) /* nothing found */
        { 
            foreach(var panel in ModelPanels.Values)
                panel.SetActive(value.Length == 0);
        }else
        {
            foreach(var keypar in ModelPanels)
            {
                if (ids.Contains(keypar.Key))
                {
                    keypar.Value.SetActive(true);
                    ids.Remove(keypar.Key);
                }else {
                    keypar.Value.SetActive(false);
                }
            }
        }

        Canvas.ForceUpdateCanvases();
        sizeFitter.enabled = true;
        sizeFitter.SetLayoutVertical();
    }

    List<int> Search(string value)
    {
        var results = new List<int>();
        if (value.Length > 0) {
            foreach(var model in Data.models)
            {
                if (model.Name.Contains(value, System.StringComparison.OrdinalIgnoreCase)
                    || model.Type.Contains(value, System.StringComparison.OrdinalIgnoreCase)
                    || model.Book.Contains(value, System.StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(model.ID);
                }
            }
        }
        return results;
    }
}
