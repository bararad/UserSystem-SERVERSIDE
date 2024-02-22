namespace TarHome1.BL
{
    public class Vacation
    {
        string id;
        string userid;
        string flatid;
        DateTime startdate;
        DateTime enddate;
        
        static List<Vacation> vacationList=new List<Vacation>();

        public Vacation(string id, string userid, string flatid, DateTime startdate, DateTime enddate)
        {
            Id = id;
            Userid = userid;
            Flatid = flatid;
            Startdate = startdate;
            Enddate = enddate;
        }

        public string Id { get => id; set => id = value; }
        public string Userid { get => userid; set => userid = value; }
        public string Flatid
        {
            get => flatid;
            set
            {
                List<Flat> flatslist = Flat.FlatsList;
                foreach (Flat f in flatslist)
                {
                    if (f.Id == value)
                    {
                        flatid = value;
                        return;
                    }
                }
                flatid = "noflat";
            } 
        }
        public DateTime Startdate { get => startdate; set => startdate = value; }
        public DateTime Enddate
        {
            get => enddate; 
            set
            {
                if (Startdate<value)
                {
                    enddate = value;
                }
                else
                {
                    enddate = DateTime.MinValue;
                }
            } 
        }
        public static List<Vacation> VacationList { get => vacationList; set => vacationList = value; }

        public bool Insert()
        {
            if (this.Flatid=="noflat")  //if there is no such flat
            {
                return false;
            }
            if (this.Enddate == DateTime.MinValue)//invalid end date
            {
                return false;
            }
            foreach (Vacation v in VacationList)
            {
                if (v.Id==this.Id)//check if vID is unique
                {
                    return false;
                }  
            }
            foreach (Vacation v in VacationList)//check if there are vacations in this flat
            {
                if (v.Flatid==this.Flatid)//check if the specific flat is occupied
                {
                    if ((v.Startdate > this.Enddate || (v.Enddate < this.Startdate)))
                    {
                        continue;//check all reservations in this flat
                    }
                    return false;//rented
                }

                vacationList.Add(this);//if the flat is available after all checks
                return true;
            }
            vacationList.Add(this);//first vacay in this flat
            return true;

        }

        public static List<Vacation> Read()
        {
            return VacationList;
        }

        public static List<Vacation> ReadByDates(DateTime startDate, DateTime endDate)
        {
            List<Vacation> templist = new List<Vacation>();
            foreach (Vacation v in VacationList)
            {
                if (v.Startdate>=startDate &&v.Enddate<=endDate)
                {
                    templist.Add(v);
                }
            }
            return templist;
        }
    }
}
