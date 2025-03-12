using System.Linq;
using UnityEngine;

namespace SmartManager.Orders
{
    public static class SupplyUtilities
    {
        public static void CorrectObjectPositions()
        {
            Debug.Log("[SmartManager] Correction des positions des objets...");
            CorrectFurnitureBoxPositions();
            CorrectBoxPositions();
            Debug.Log("[SmartManager] Positions des objets corrigées.");
        }

        private static void CorrectFurnitureBoxPositions()
        {
            foreach (FurnitureBox furnitureBox in Object.FindObjectsByType<FurnitureBox>(FindObjectsSortMode.None))
            {
                if (furnitureBox != null && furnitureBox.transform.position.y > 8f)
                {
                    furnitureBox.transform.position = new Vector3(furnitureBox.transform.position.x, 2f, furnitureBox.transform.position.z);
                }
            }
        }

        private static void CorrectBoxPositions()
        {
            foreach (Box box in Object.FindObjectsByType<Box>(FindObjectsSortMode.None).Where(box => box != null && !box.Racked && box.Full))
            {
                if (box.transform.position.y > 8f)
                {
                    box.transform.position = new Vector3(box.transform.position.x, 2f, box.transform.position.z);
                }
            }
        }
    }
}
