using System.Collections.Generic;
using UnityEngine;

namespace Terminal {
    public class TerminalManager : MonoBehaviour {
        [SerializeField] List<Terminal.Printables> printableGroups = new();
        public static Dictionary<Terminal.PrintGroups, (string prefix, Dictionary<string, string> subgroups)> _pG;

        private void Awake() {
            UpdateGroups();
        }

        [ContextMenu("Update print groups")]
        public void UpdateGroups() {
            _pG = new();

            for(int i = 0; i < printableGroups.Count; i++) {
                Dictionary<string, string> a = new();

                for(int j = 0; j < printableGroups[i].subGroup.Count; j++) {
                    a.Add(printableGroups[i].subGroup[j].name, printableGroups[i].subGroup[j].subPrefix);
                }

                _pG.Add(printableGroups[i].group, (printableGroups[i].prefix, a));
            }
        }
    }
}