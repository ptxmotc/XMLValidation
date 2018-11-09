using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSDVAL.Praking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("開始產生Xml檔案");
            CreateXML();
            Console.WriteLine("產生Xml檔案結束");
            Console.ReadKey();
        }

        static void CreateXML()
        {
            var Availabilitys = new List<AvailabilityType>
            {
                new AvailabilityType()
                {
                    SpaceType = 1,
                    NumberOfSpaces =9,
                    AvailableSpaces = 37,
                }
            }.ToArray();

            List<ParkingAvailabilityType> ParkingAvailabilities = new List<ParkingAvailabilityType>
            {
                new ParkingAvailabilityType()
                {
                    CarParkID = "056",
                    CarParkName = new NameType {
                        Zh_tw="大安森林公園地下停車場",
                    },
                    Availabilities=Availabilitys,
                    ServiceStatus = 1,
                    FullStatus = 0,
                    ServiceAvailableLevel = 35,
                    AlmostFullLevel = 50,
                    FullLevel =55,
                    OverCrowdingLevel=56,
                    ChargeStatus=1,
                    Remark="",
                }
            };

            ParkingAvailabilityListType VDList = new ParkingAvailabilityListType()
            {
                UpdateTime = DateTime.Now,
                UpdateInterval = 86400,
                AuthorityCode = "TPE",
                ParkingAvailabilities = ParkingAvailabilities.ToArray(),
            };
            var Path = System.IO.Path.Combine(Directory.GetParent("..").FullName, @"XSD\ParkingAvailability.xml");
            Utility.Helper.XMLHelper.Serialize(VDList, Path);
        }
    }
}
