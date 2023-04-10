using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emart
{
    class ItemsBO
    {
        static List<Items> Ilist = new List<Items>();
        static List<Subcategory> Slist = new List<Subcategory>();
        static List<Category> Clist = new List<Category>();
        public void addCategoryItems(int id, string cname, string cdes)
        {
            Clist.Add(new Category(id, cname, cdes));
        }
        public void subCategoryItems(int c_id, int sid, string scname, string details)
        {
            foreach (Category c in Clist)
            {
                if (c.cid == c_id)
                {
                    Slist.Add(new Subcategory(c_id, sid, scname, details));
                }
            }

        }
        public void AddItems(int c_id, int s_id, int id, double pri, string item_nam, string des, int st, string rem, double gst)
        {
            foreach (Category c in Clist)
            {
                foreach (Subcategory s in Slist)
                {
                    if (c.cid == c_id && s.Sid == s_id)
                    {
                        Ilist.Add(new Items(id, pri, item_nam, des, st, rem, gst));
                    }
                }
            }
        }
        public void viewItems()
        {
            Console.WriteLine("Category List..");
            foreach (Category i in Clist)
            {
                Console.WriteLine("Category Id.." + i.cid + "\tCategory Name.." + i.cname + "\tAbout Catogery" + i.breifdetails);
            }
            Console.WriteLine("Enter Category Id..Which you want to view..");
            int opt = int.Parse(Console.ReadLine());
            int opt1 = 0;
            foreach (Category i in Clist)
            {
                if (i.cid == opt)
                {
                    opt1 = 1;
                }
            }
            int opt4 = 0;
            if (opt1 == 1)
            {
                Console.WriteLine("Subcatogery List..");
                foreach (Subcategory c in Slist)
                {
                    Console.WriteLine("Subcatogery id.." + c.Sid + "\tSubcatogery name.." + c.Scname + "\tAbout Subcatogery.." + c.Details);
                }
                Console.WriteLine("Enter Subcatogery id To View..");
                int opt3 = int.Parse(Console.ReadLine());
                foreach (Subcategory i in Slist)
                {
                    if (i.Sid == opt3)
                    {
                        opt4 = 1;
                    }
                }
            }

            if (opt4 == 1)
            {
                Console.WriteLine("ITEMS..");

                foreach (Items i in Ilist)
                {
                    Console.WriteLine(i.ToString());

                }
            }
        }
    }
}