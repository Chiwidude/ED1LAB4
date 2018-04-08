using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4ED1
{
    public class StickerLists
    {
        List<int> missing, collected, changes;

        public StickerLists()
        {
            Missing = new List<int>();
            Collected = new List<int>();
            Changes = new List<int>();
        }
        public StickerLists(List<int> miss, List<int> collect, List<int> change)
        {
            Missing = miss;
            Collected = collect;
            Changes = change;
        }

        public List<int> Missing { get => missing; set => missing = value; }
        public List<int> Collected { get => collected; set => collected = value; }
        public List<int> Changes { get => changes; set => changes = value; }
    }
}