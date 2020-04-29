using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using Harmony;
using UnityEngine;

namespace NaturalPlanters
{
    public class MainPatcher
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.sogekeeper.subnautica.naturalplanters.mod");    
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }

    [HarmonyPatch(typeof(Plantable))]  
    [HarmonyPatch("Spawn")]       
    internal class Plantable_Spawn_Patch
    {
        [HarmonyPostfix]      
        public static void Postfix(GameObject __result, Plantable __instance)
        {
            //if(!__instance.model.name.Equals("Coral_reef_purple_mushrooms_01_04(Clone)") || 
            //    !__instance.model.name.Equals("Coral_reef_jelly_plant_01_01(Clone)") || 
            //    !__instance.model.name.Equals("Coral_reef_small_blue_fans_01_01(Clone)"))
            //{}
                __result.transform.localRotation = Quaternion.Euler(__result.transform.localRotation.x, UnityEngine.Random.Range(0, 360), __result.transform.localRotation.z);
            
            
            ///ErrorMessage.AddMessage("Plant spawned "+__instance.model.name+"  Tag: "+__result.tag.ToString());       
            
        }
    }
}
