using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms; //meassageBox

namespace PlanChecker
{
    /// <summary>
    /// This class stores Protocol, it like the database or collection of templates for different plans. One protocol may be for a prostate with a surten fractionation while another scheme may be for prostate with another 
    /// </summary>
    [Serializable]
    public class DataBase
    {
        private double absDoseVolymBinWidth = 0.001;
        private List<Protocol> protocols;
        public int PrefixLength { get; set; }
        public string LastUpdated{get; set;}
        public double NameSimilarity { get; set; }
        public Protocol[] Protocols { get { return protocols.ToArray(); } set { protocols = new List<Protocol>(value); } }
        public List<Highlight> HighLight { get; set; }
        public double AbsDoseVolymBinWidth { get { return absDoseVolymBinWidth; } set { absDoseVolymBinWidth = value; } }
        public DataBase()
        {
            protocols = new List<Protocol>();
            LastUpdated = DateTime.Now.Date.ToShortDateString();
            HighLight = new List<Highlight>() { new Highlight("medulla", Color.DarkOrange) };
            NameSimilarity = 0.8;
        }
        public Protocol GetProtocol(string search)
        {
            foreach (Protocol protocol in protocols)
                if (String.Compare(protocol.Name, search) == 0)
                    return protocol;
            MessageBox.Show("error in protcol retrival");
            return protocols.First(); //defult med endast PTV
        }
        public Protocol GetProtocol(int Index) //ingen check out of bounds ty ej möjligt.
        {
            return protocols[Index];
        }
        public void AddProtocol(Protocol newProtocol)
        {
            protocols.Add(newProtocol);
        }
        public void RemoveProtocol(int index)
        {
            protocols.Remove(protocols.ElementAt(index));
        }
        public List<String> GetProtocolNames()
        {
            List<String> nameList = new List<String>();
            foreach (Protocol protocol in protocols)
                nameList.Add(protocol.Name);
            return nameList;
        }
        public List<String> GetProtocolListNames()
        {
            List<String> nameList = new List<String>();
            foreach (Protocol protocol in protocols)
                nameList.Add(protocol.GetListName());
            return nameList;
        }
        public void SortProtocolsAlpahbetic()
        {
            protocols = protocols.OrderBy(o => o.GetListName()).ToList();
        }
    }
}
