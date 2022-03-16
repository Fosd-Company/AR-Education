using UnityEngine.UI;
using UnityEngine;

namespace Pipelines
{
    public static class RedirectData
    {
        public static Sprite targetSprite { get; set; }
        public static ARModel targetModel { get; set; }
    }

    public class InfoPanel
    {
        public Image InfoImg { get; }
        public Text TypeName { get; }
        public Text Header { get; }
        public InputField BookField { get; }

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

                /* InfoMenu -> Content -> Panel -> panel_inner*/
                var panelInner = content.GetChild(1).GetChild(0);
                BookField = panelInner.GetChild(0).GetComponent<InputField>();
                TypeName = panelInner.GetChild(1).GetComponent<Text>();
            }
        }

        public void SetInfo(Sprite modelSprite, ARModel model)
        {
            Header.text = model.Name;
            InfoImg.sprite = modelSprite;
            TypeName.text = model.Type;
            BookField.text = model.Book;
        }
    }
}