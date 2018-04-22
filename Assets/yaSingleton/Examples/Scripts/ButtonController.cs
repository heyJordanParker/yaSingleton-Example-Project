using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace yaSingleton.Examples {
    public class ButtonController : MonoBehaviour, IPointerClickHandler {

        public Text welcomeLabel;

        public Text versionLabel;

        private string _versionLabelText = null;
        
        public Text VersionLabel {
            get {
                if(_versionLabelText == null) {
                    _versionLabelText = versionLabel.text;
                }
                
                return versionLabel;
            }
        }

        private void Awake() {
            if(versionLabel) {
                
            }
        }

        public void OnPointerClick(PointerEventData eventData) {
            if(!welcomeLabel || !versionLabel) {
                return;
            }

            welcomeLabel.text = GameSettings.WelcomeLabel;

            VersionLabel.text = string.Format(_versionLabelText, GameSettings.GameVersion);
        }
    }
}