using NodeClass;
using NodeInserts.Models;
using System.Runtime.CompilerServices;

namespace NodeInserts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<ShabatRecievers> shabatShalom = new Node<ShabatRecievers>(new ShabatRecievers("Shiri","Shira",18,1,2024));
            Node<ShabatRecievers> nextShabat = new Node<ShabatRecievers>(new ShabatRecievers("Ofek", "Aviv", 25, 1, 2024));
            shabatShalom.SetNext(nextShabat);

            ShabatRecievers sh = shabatShalom.GetValue();
            string p1 = sh.GetParent1();

        }
        public static Node<ShabatRecievers> DeleteShabat(Node<ShabatRecievers> ShabatLst,string parent)
        {
            if (ShabatLst == null) return null;
            if(ShabatLst.GetValue().GetParent1()==parent|| ShabatLst.GetValue().GetParent2() == parent)
            {
                Node<ShabatRecievers> otherHead = ShabatLst.GetNext();
                ShabatLst.SetNext(null);
                return otherHead;
            }
            Node<ShabatRecievers> head = ShabatLst;
            while (ShabatLst!=null&&ShabatLst.HasNext())
            {
                Node<ShabatRecievers> next = ShabatLst.GetNext();
                ShabatRecievers nextShabat = next.GetValue();
                if (nextShabat.GetParent1()==parent|| nextShabat.GetParent2() == parent)
                {
                    ShabatLst.SetNext(next.GetNext());
                    next.SetNext(null);
                }
                ShabatLst = ShabatLst.GetNext();
            }
            return head;
        }
        public static bool CheckShabat(Node<ShabatRecievers> ShabatLst,int day,int month,int year)
        {
            if (ShabatLst != null) return false;
            ShabatRecievers that = ShabatLst.GetValue();
            if (that.GetDay() == day && that.GetMonth() == month && that.GetYear() == year) return true;
            return CheckShabat(ShabatLst.GetNext(), day, month, year);
        }
    }
}