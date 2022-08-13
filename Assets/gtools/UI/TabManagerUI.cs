using UnityEngine;
using UnityEngine.UI;

namespace gtools.UI
{
    public class TabManagerUI : MonoBehaviour
    {
        [SerializeField] private Transform tabsContainer, contentContainer;
        [SerializeField] private Sprite deactivatedTabGraphic;
        [SerializeField] private Sprite activatedTabGraphic;

        private void Start() => SelectTab(0);

        public void SelectTab(int tab)
        {
            for(var i = 0; i < tabsContainer.childCount; i++)
            {
                tabsContainer.GetChild(i).GetComponent<Image>().sprite = tab == i ? activatedTabGraphic : deactivatedTabGraphic;
                contentContainer.GetChild(i).gameObject.SetActive(tab == i);
            }
        }
    }
}
