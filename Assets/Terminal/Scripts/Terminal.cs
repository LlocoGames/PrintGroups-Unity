using System.Collections.Generic;
using UnityEngine;

namespace Terminal {
    public static class Terminal {
        /// <summary>
        /// General groups for separete prints!
        /// </summary>
        public enum PrintGroups {
            Misc,
            Player,
            Boss,
        }

        [System.Serializable]
        public class Printables {
            public PrintGroups group;
            public List<SubGroupData> subGroup = new();
            public string prefix = "";
        }

        [System.Serializable]
        public class SubGroupData {
            public string name;
            public string subPrefix;

            public SubGroupData(string name, string subPrefix) {
                this.name = name;
                this.subPrefix = subPrefix;
            }
        }

        //Custom print methods to keep things organized on groups

        // Terminal methods: Terminal.Print()
        static public void Print(string t, Object o, PrintGroups group = 0, System.Enum subGroup = null) {
            if(CheckPrintable(group, subGroup)) Debug.Log(GetPrefix(group, subGroup) + t, o);
        }


        static public void Print(string t, PrintGroups group = 0, System.Enum subGroup = null) {
            if(CheckPrintable(group, subGroup)) Debug.Log(GetPrefix(group, subGroup) + t);
        }

        // Extension methods: this.Print()

        /// <summary> If subGroup is null it will only require the group to be printable  </summary>
        static public void Print(this Object o, string t, PrintGroups group = 0, System.Enum subGroup = null) {
            if(CheckPrintable(group, subGroup)) Debug.Log(GetPrefix(group, subGroup) + t, o);
        }

        /// <summary> If subGroup is null it will only require the group to be printable  </summary>
        static public void Print(this Object o, object t, PrintGroups group = 0, System.Enum subGroup = null) {
            if(CheckPrintable(group, subGroup)) Debug.Log(GetPrefix(group, subGroup) + t, o);
        }


        static bool CheckPrintable(PrintGroups group = 0, System.Enum subGroup = null) { //Checks if the print groups and subgroup (if there is one) is active
            return TerminalManager._pG != null && TerminalManager._pG.ContainsKey(group) && (subGroup == null || TerminalManager._pG[group].subgroups.ContainsKey(subGroup.ToString()));
        }

        //                              g -> Group      sg -> SubGroup
        static string GetPrefix(PrintGroups g, System.Enum sG = null) {
            bool pExist = TerminalManager._pG != null && TerminalManager._pG.ContainsKey(g);            //prefix
            bool spExist = sG != null && TerminalManager._pG[g].subgroups.ContainsKey(sG.ToString());   //sub(group) prefix

            string p = pExist ? TerminalManager._pG[g].prefix : "";
            string sp = pExist && spExist ? TerminalManager._pG[g].subgroups[sG.ToString()] : "";

            return $"{p} -> {sp}: "; //example: "Player -> Inputs: ..."
        }
    }

}