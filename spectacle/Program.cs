using System;
using System.Collections.Generic;

namespace spectacle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trick> lst = new List<Trick>();
            List<Trick> lst2 = new List<Trick>();
            lst.Add(new Trick(1,"acrobatie","marcher sur les mains"));
            lst.Add(new Trick(2, "musique", "danse"));
            lst2.Add(new Trick(1, "acrobatie", "marcher sur les mains"));
            lst2.Add(new Trick(2, "musique", "danse avec les mains"));
            lst2.Add(new Trick(3,"musique", "Piano"));
            Monkey mnk = new Monkey(1,lst);
            Monkey mnk2 = new Monkey(2, lst2);
            Spectator sp = new Spectator();
            Trainers tr = new Trainers(1);
            string name_trick = tr.request(2, mnk2);
            sp.React(name_trick);
            Trainers tr2 = new Trainers(2);
            string name_trick2 = tr2.request(1, mnk);
            sp.React(name_trick2);
        }
    }
    class Spectator
    {
         public void React(string name_trick)
        {
            switch (name_trick)
            {
                case "musique":
                    Console.WriteLine("Le spectateur siffle");
                    break;
                case "acrobatie":
                    Console.WriteLine("Le spectateur applaudit");
                    break;
                default:
                    Console.WriteLine("Le spectateur !!!!");
                    break;

            }

        }
    }
    class Trainers
    {
        public int id;
        public string request(int trick ,Monkey mnk )
        {
            Console.WriteLine("dresseur "+ this.id + " demande à singe "+ mnk.id+ " d'executer le tour "+trick);
            return mnk.Execute(trick);

        }

        public Trainers(int id)
        {
            this.id = id;
        }
    }
    class Monkey

    {
        public int id;
        public List<Trick> lst;

        public Monkey(int id, List<Trick> list)
        {
            this.id = id;
            this.lst = list;
        }

        public string Execute(int trink) 
        {
            string trk_name = "Ops !";
            foreach (var trk in lst)
            {
               if (trk.Id == trink)
                {
                    Console.WriteLine(trk.Discription);
                    trk_name = trk.Name;

                }
            }
            return trk_name;
        }
    }
    class Trick
    {
        private int id;
        private string name;
        private string discription;

        public Trick(int id, string name, string discription)
        {
            Id = id;
            Name = name;
            Discription = discription;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }
    }
}
