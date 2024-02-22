namespace TarHome1.BL
{
    public class Flat
    {

        string id;
        string city;
        string adress;
        double price;
        int numofRooms;
        static List<Flat> flatsList = new List<Flat>();

        public Flat(string id, string city, string adress, double price, int numofRooms)
        {
            Id = id;
            City = city;
            Adress = adress;
            NumofRooms = numofRooms;
            Price = price;
            
        }
        public Flat() { }

        public string Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Adress { get => adress; set => adress = value; }
        public int NumofRooms { get => numofRooms; set => numofRooms = value; }
        public double Price { get => price; set { price=Discount(value, NumofRooms); } }
        
        public static List<Flat> FlatsList { get => flatsList; }

        public bool Insert()
        {
            string id = this.Id;
            for (int i = 0; i < flatsList.Count; i++)
            {
                if (id==flatsList[i].Id)
                {
                    return false;
                }
            }
             flatsList.Add(this);
             return true;
 
        }
        public static List<Flat> Read()
        {
            return FlatsList;
        }

        public double Discount(double price,int noOfrooms)
        {
            if (price>100 && noOfrooms> 1)
            {
                return price * 0.9;
            }
            return price;
        }
        static public List<Flat> ReadbyCityandPrice(string city,double price)
        {
            List<Flat> templist=new List<Flat>();
            foreach (Flat f in flatsList)
            {
                if (f.City==city && f.Price<price)
                {
                    templist.Add(f);
                }
            }
            return templist;
        }


    }
}
