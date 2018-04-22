using System.Collections;
using UnityEngine;

namespace yaSingleton.Examples {
    [CreateAssetMenu(fileName = "UI Manager", menuName = "Singletons/UIManager")]
    public class UIManager : Singleton<UIManager> {

        [SerializeField]
        private bool _animate = true;
        
        [SerializeField]
        private readonly float _animationSpeed = 2f;

        [SerializeField]
        private float _animateYFrom = 0;

        [SerializeField]
        private float _animteYTo = 50;

        private const string AnimatedTag = "Animated";
        
        protected override void Initialize() {
            base.Initialize();
            
            StartCoroutine(AnimateObjects());
        }

        private IEnumerator AnimateObjects() {

            yield return null;

            var gameObjects = GameObject.FindGameObjectsWithTag(AnimatedTag);

            float progress = 0;

            while(true) {
                yield return null;

                if(!_animate) {
                    continue;
                }
                
                foreach(var gameObject in gameObjects) {
                    var pos = gameObject.transform.localPosition;

                    var from = _animateYFrom;
                    var to = _animteYTo;

                    if((int) progress % 2 != 0) {
                        from = _animteYTo;
                        to = _animateYFrom;
                    }

                    pos.y = Mathf.Lerp(from, to, progress - (int) progress);

                    gameObject.transform.localPosition = pos;
                }
                
                progress += Time.smoothDeltaTime * _animationSpeed;
            }
        }
    }
}