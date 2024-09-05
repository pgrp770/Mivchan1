using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mivchan1.Models;
using Mivchan1.Utils;

namespace Mivchan1.Tree
{
    internal class DefenceStrategiesBST
    {
        public Dictionary<DefenceStrategy, int> dictHelper = new Dictionary<DefenceStrategy, int>();
        public NodeP? Root { get; set; }
        public List<DefenceStrategy> Helper { get; set; } = [];
        public DefenceStrategiesBST(DefenceStrategy value)
        {
            Root = new NodeP(value);
        }
        public DefenceStrategiesBST() { }
        public void Insert(DefenceStrategy value)
        {
            Root = Insert(Root, value);
        }
        public NodeP Insert(NodeP? root, DefenceStrategy value)
        {
            if (root == null)
            {
                return new NodeP(value);
            }
            if (root.Defence > value)
            {
                root.Left = Insert(root.Left, value);
            }
            if (root.Defence < value)
            {
                root.Right = Insert(root.Right, value);
            }
            return root;
        }



        public void Print()
        {
            Console.WriteLine("Tree structure with left/right child distinctinos:");

            PreOrderPrint(Root, "Root");
        }
        public void PreOrderPrint(NodeP root, string dir, string indintation = "|---")
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine($"{indintation}{dir}: {root.Defence.ToString()}");
            PreOrderPrint(root.Left, "Left Child", "   " + indintation);
            PreOrderPrint(root.Right, "Right Child", "   " + indintation);

        }
        public List<DefenceStrategy> InOrder()
        {
            Helper = [];
            InOrder(Root);
            return Helper;
        }
        public void InOrder(NodeP root)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.Left);
            Helper.Add(root.Defence);
            InOrder(root.Right);
        }
        public DefenceStrategiesBST BalanceTree()
        {
            dictHelper = new();
            List<DefenceStrategy> list = InOrder();
            changeInOrderToBalanceListHelper(list);
            List<DefenceStrategy> BalanceList = dictHelper.OrderBy(a => a.Value).Select(i => i.Key).ToList();
            DefenceStrategiesBST balanceTree = new DefenceStrategiesBST();

            BalanceList.ForEach(balanceTree.Insert);


            return balanceTree;
        }
        public void changeInOrderToBalanceListHelper(List<DefenceStrategy> list, int i = 0)
        {
            if (list.Count == 1)
            {
                dictHelper.TryAdd(list[0], i);
                return;
            }
            if (list.Count == 0)
            {
                return;
            }
            int start = 0;
            int end = list.Count;
            int mid = list.Count % 2 == 1 ? (start + end) / 2 : (start + end) / 2 - 1;
            dictHelper.TryAdd(list[mid], i);
            changeInOrderToBalanceListHelper(list[start..mid], i + 1);
            changeInOrderToBalanceListHelper(list[(mid + 1)..end], i + 1);
        }
        public List<DefenceStrategy> PreOrder()
        {
            Helper = [];
            PreOrder(Root);
            return Helper;
        }
        public void PreOrder(NodeP root)
        {
            if (root == null)
            {
                return;
            }
            Helper.Add(root.Defence);
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
        public void PreOrderSerach(Threat target)
        {
            if (this.InOrder().FirstOrDefault()?.MinSeverity > ThreatUtils.CalculateSeverity(target))
            {
                Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
                return;
            }
            if (this.InOrder().LastOrDefault()?.MaxSeverity < ThreatUtils.CalculateSeverity(target))
            {
                Console.WriteLine("No suitable defence was found!. Brace for impact");
                return;
            }

            SearchHelper(Root, target);

            
            return;

        }
        public NodeP? SearchHelper(NodeP root, Threat target)
        {
            int a = ThreatUtils.CalculateSeverity(target);
            if (root == null)
            {
                return null;
            }
            if (ThreatUtils.IsThreatInTheSeverityRange(target, root.Defence))
            {
                Console.WriteLine(root.Defence.ToString());
                return root;
            }
            

            SearchHelper(root.Left, target);
            SearchHelper(root.Right, target);
            return root;

        }
    }
}
