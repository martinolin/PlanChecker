using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VMS.TPS.Common.Model.API;

namespace PlanCheckerGroup
{
    /// <summary>
    /// Only used when using filter from GroupInvestigation
    /// </summary>
    static public class Filtering
    {

        static public bool MatchSex { get; set; }
        static public bool MatchAge { get; set; }
        static public bool MatchCreationDate { get; set; }
        static public bool MatchId { get; set; }
        static public bool MatchAGivenNumber { get; set; }
        static string sex = "Male";
        static public string Sex { get { return sex; } set { sex = value; } }
        public static DateTime dt = DateTime.Now;
        static double upperAge = 120;
        static double lowerAge = 0;
        static int hits = 0;
        static public double UpperAge { set { upperAge = value; } get { return upperAge; } }
        static public double LowerAge { set { lowerAge = value; } get { return lowerAge; } }
        static public DateTime CreationUpperAge { set { creationUpperAge = value; } get { return creationUpperAge; } }
        static public DateTime CreationLowerAge { set { creationLowerAge = value; } get { return creationLowerAge; } }
        static public int Hits { get; set; }
        static DateTime creationUpperAge;
        static DateTime creationLowerAge;
        static public bool Done { get; set; }
        static string id = "";
        static public string ID { get { return id; } set { id = value; } }
        static public double AgeDays { get { return ageDays; } set { ageDays = value; } }
        static public DateTime CreationDate { get; set; }
        static bool pass = true;
        static double ageDays;
        static public void Reset()
        {
            hits = 0;
            dt = DateTime.Now;
        }
        static public void Start() {
            MatchAge = false;
            MatchAGivenNumber = false;
            MatchCreationDate = false;
            MatchId = false;
            MatchSex = false;
        }
        static public void AddAHit()
        {
            ++hits;
            if (hits > Hits - 1)
                Done = true;
        }
        static public bool Serach(PatientSummary ps)
        {
            pass = true;
            if (MatchAge)
            {
                if (!ps.DateOfBirth.HasValue)
                    return false;
                ageDays = dt.Subtract(ps.DateOfBirth.Value.Date).TotalDays;
                pass = lowerAge <= ageDays && ageDays <= upperAge;
            }
            if (MatchSex)
                pass = pass && sex == ps.Sex;
            if (MatchId)
                pass = pass && id == ps.Id;
            if (MatchCreationDate)
            {
                if (!ps.CreationDateTime.HasValue)
                    return false;
                CreationDate = (DateTime)ps.CreationDateTime;
                pass = pass && creationLowerAge <= CreationDate && CreationDate <= creationUpperAge;
            }
            return pass;
        }
    }
}
