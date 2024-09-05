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
            DTODefence defences = JsonConvert.DeserializeObject<DTODefence>(File.ReadAllText("defenceStrategies.json"))!;
            List<DefenceStrategy> defencesList = defences.Defence;
            DefenceStrategiesBST treeDefences = new DefenceStrategiesBST();
            defencesList.ForEach(treeDefences.Insert);

            //Print UnBalancedtree
            Console.WriteLine("\n\n\n_______________UNBALANCED TREE_______________\n\n\n");
            treeDefences.Print();

            // Balancing the tree
            treeDefences = treeDefences.BalanceTree();

            //Printing the balanced tree
            Console.WriteLine("\n\n\n_______________BALANCED TREE_______________\n\n\n");
            treeDefences.Print();


            //InOrder list
            Console.WriteLine("\n\n\n_______________INORDER LIST_______________\n\n\n");
            List<DefenceStrategy> inOrderedList = treeDefences.InOrder();
            Console.WriteLine(string.Join(", ", inOrderedList));

            // convert PreOrderList to Json
            List<DefenceStrategy> preOrderdDefences = treeDefences.PreOrder();
            DTODefence defencesBalanced = new DTODefence() { Defence = preOrderdDefences};
            File.WriteAllText("./defenceStrategiesBalancedPini.json", JsonConvert.SerializeObject(defencesBalanced));


             //test convert PreOrderList to Json
/*            
            DTODefence defences1 = JsonConvert.DeserializeObject<DTODefence>(File.ReadAllText("defenceStrategiesBalancedPini.json"))!;
            List<DefenceStrategy> defencesList1 = defences1.Defence;
            DefenceStrategiesBST treeDefences1 = new DefenceStrategiesBST();
            defencesList1.ForEach(treeDefences1.Insert);
            treeDefences1.Print();*/


            // Import threts
            DTOThret thrests = JsonConvert.DeserializeObject<DTOThret>(File.ReadAllText("threats.json"))!;
            List<Threat> threatsList = thrests.Threts;
            Console.WriteLine("\n\n\n_______________START ATTACK_______________\n\n\n");
            foreach (Threat threat in threatsList)
            {
                Console.WriteLine($"threatType: {threat.ThreatType}, sevirty: {ThreatUtils.CalculateSeverity(threat)}");
                treeDefences.PreOrderSerach(threat);
                Thread.Sleep(2000);
                Console.WriteLine();
            }
            

        }
    }
}
