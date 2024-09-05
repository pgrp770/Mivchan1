using Mivchan1.Dto;
using Mivchan1.Models;
using Mivchan1.Tree;
using Mivchan1.Utils;
using Newtonsoft.Json;
namespace Mivchan1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating the binary tree from Json
            DefenceStrategiesBST treeDefences = FromJsonToBSTree();

            //Print UnBalancedtree
            PrintTree(treeDefences, "UNBALANCED");

            // Balancing the tree      
            treeDefences = BalancingTheTree(treeDefences);

            //Printing the balanced tree
            PrintTree(treeDefences, "BALANCED");

            //InOrder list
            PrintInOrderListFromTree(treeDefences);

            // convert PreOrderList to Json
            ConvertTreeToJson(treeDefences);

            // Import threts
            StartAttak(treeDefences);
        }
        public static DefenceStrategiesBST FromJsonToBSTree()
        {
            DTODefence defences = JsonConvert.DeserializeObject<DTODefence>(File.ReadAllText("defenceStrategies.json"))!;
            List<DefenceStrategy> defencesList = defences.Defence;
            DefenceStrategiesBST treeDefences = new DefenceStrategiesBST();
            defencesList.ForEach(treeDefences.Insert);

            Console.WriteLine("\n\n\n_______________CONVERT JSON TO TREE_______________\n\n\n");
            Console.WriteLine("The system loading the tree from json file...");
            Console.WriteLine("\n\n\n**********************************************");

            Thread.Sleep(4000);

            return treeDefences;
        }
        public static void PrintTree(DefenceStrategiesBST tree, string type)
        {
            Console.WriteLine($"\n\n\n_______________{type} TREE_______________\n\n\n");
            tree.Print();
            Console.WriteLine("\n\n\n**********************************************");

            Thread.Sleep(4000);
        }
        public static void PrintInOrderListFromTree(DefenceStrategiesBST tree)
        {
            List<DefenceStrategy> inOrderedList = tree.InOrder();

            Console.WriteLine("\n\n\n_______________INORDER LIST_______________\n\n\n");
            Console.WriteLine(string.Join(", ", inOrderedList));
            Console.WriteLine("\n\n\n**********************************************");

            Thread.Sleep(4000);
        }
        public static void ConvertTreeToJson(DefenceStrategiesBST tree)
        {
            Console.WriteLine("\n\n\n_______________CONVERT TREE TO JSON_______________\n\n\n");
            
            List<DefenceStrategy> preOrderdDefences = tree.PreOrder();
            DTODefence defencesBalanced = new DTODefence() { Defence = preOrderdDefences };
            File.WriteAllText("./defenceStrategiesBalancedPini.json", JsonConvert.SerializeObject(defencesBalanced));
            
            Console.WriteLine("The system converting your tree to json file...\n\n\n");
            Console.WriteLine("**********************************************");

            Thread.Sleep(4000);
        }
        public static void StartAttak(DefenceStrategiesBST tree)
        {
            DTOThret thrests = JsonConvert.DeserializeObject<DTOThret>(File.ReadAllText("threats.json"))!;
            List<Threat> threatsList = thrests.Threts;

            Console.WriteLine("\n\n\n_______________START ATTACK_______________\n\n\n");

            threatsList.ForEach(threat =>
            {
                Console.WriteLine($"threatType: {threat.ThreatType}, sevirty: {ThreatUtils.CalculateSeverity(threat)}");
                tree.PreOrderSerach(threat);
                Thread.Sleep(2000);
                Console.WriteLine();
            });

            Console.WriteLine("**********************************************");
        }
        public static DefenceStrategiesBST BalancingTheTree(DefenceStrategiesBST tree)
        {
            Console.WriteLine("\n\n\n_______________BALANCING THE TREE_______________\n\n\n");
            Console.WriteLine("The system balncing your tree...\n\n\n");
            Console.WriteLine("**********************************************");

            Thread.Sleep(4000);

            return tree.BalanceTree();
        }
    }
}
